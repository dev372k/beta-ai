using Domain.Abstractions.DTOs.Responses;

namespace Domain.Abstractions;

public interface IGPTService
{
    Task<object> GetSentiment(string review);
    Task<object> GetSummary(string text);
    Task<object> GetTranslation(string text);
    Task<object> GetLanguage(string text);
}
