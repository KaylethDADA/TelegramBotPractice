﻿using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.User
{
    public sealed record UserUpdateRequests(
        Guid Id,
        FullName FullName,
        string UserName);
}
