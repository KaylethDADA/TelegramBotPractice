using TelegramBotPractice.Domain.Primitives.Enum;
using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.Authentications
{
    public sealed record LoginResponse(
        Guid Id,
        string Token,
        FullName FullName,
        EnumTypeRoles Role);
}
