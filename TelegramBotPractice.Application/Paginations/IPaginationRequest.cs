﻿namespace TelegramBotPractice.Application.Paginations
{
    public interface IPaginationRequest
    {
        public PageRequest? Page { get; set; }
    }
}
