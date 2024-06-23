using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TelegramBotPractice.Application.Dtos.Authentications;
using TelegramBotPractice.Application.Interfaces.Authentications;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Domain.Primitives.Enum;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext db;
        
        public AuthRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {

            var user = await db.Users.FirstOrDefaultAsync(x => x.Username == request.UserName);
            if (user is null)
                throw new Exception("Неверный Email");

            if (user.PasswordHash != GetHash.GetHashPassword(request.Password, user.PasswordSalt))
                throw new Exception("Неверный Password");

            var tokenResult = GenerateToken(user.Id);

            return new LoginResponse(
                Token: tokenResult.Token,
                Id: user.Id,
                FullName: user.FullName,
                Role: user.Roles);
        }

        public async Task Registration(RegisterRequest request)
        {
            if (await db.Users.AnyAsync(x => x.Username == request.UserName.Trim()))
                throw new Exception("Данный UserName уже используется!");

            var guidEmail = Guid.NewGuid();
            var (hashedPassword, salt) = GetHash.GetHashPassword(request.Password);

            var user = new User
            {
                FullName = request.FullName,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                Roles = EnumTypeRoles.Admin,
                Username = request.UserName,
                ChatId = 1758196925
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }

        private TokenResponse GenerateToken(Guid Id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == Id);

            if (user is null)
                throw new Exception("Пользователь не найден!");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = AuthOptions.GetSymmetricSecurityKey();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.FullName.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME),
                Audience = AuthOptions.AUDIENCE,
                Issuer = AuthOptions.ISSUER,
                SigningCredentials = new(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponse(
                Id: user.Id,
                FullName: user.FullName,
                Token: $"Bearer {tokenHandler.WriteToken(token)}");
        }
    }
}
