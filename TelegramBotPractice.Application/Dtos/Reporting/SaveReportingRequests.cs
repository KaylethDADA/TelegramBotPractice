using TelegramBotPractice.Reporting.MicrosoftOffice.Enums;

namespace TelegramBotPractice.Application.Dtos.Reporting
{
    public sealed record SaveReportingRequests(
        string FileName,
        string WebRootPath,
        string FilePath,
        FileExtensionTypeEnum FileExtension,
        byte[] fileContents);
}
