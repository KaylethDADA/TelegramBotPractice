using MapsterMapper;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Application.Interfaces;
using User = TelegramBotPractice.Domain.Entities.User;

namespace TelegramBotPractice.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public UserResponse Create(UserCreateRequests request)
        {
            var user = _mapper.Map<User>(request);
            _userService.Create(user);
            return _mapper.Map<UserResponse>(user);
        }
        public UserResponse Update(UserUpdateRequests request)
        {
            var user = _userService.GetById(request.Id);

            if (user == null)
                throw new Exception();

            user.Update(
                request.FullName.FirstName,
                request.FullName.LastName,
                request.FullName.MiddleName,
                request.UserName);

            _userService.Update(user);

            return _mapper.Map<UserResponse>(user);
        }
        public UserResponse GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return _mapper.Map<UserResponse>(user);
        }
        public UserResponse AddFavoritBook(long chatId, Guid bookId)
        {
            var user = _userService.AddFavoritBook(chatId, bookId);
            return _mapper.Map<UserResponse>(user);
        }
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }
    }
}
