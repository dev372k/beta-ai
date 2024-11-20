using Domain.Abstractions.DTOs.Responses;

namespace Domain.Abstractions;

public interface IGPTService
{
    Task<GetSentimentDto> GetSentiment(string review);
    Task<GetSummaryDto> GetSummary(string text);
    Task<GetTranslationDto> GetTranslation(string text);
    Task<GetLanguageDto> GetLanguage(string text);
}
