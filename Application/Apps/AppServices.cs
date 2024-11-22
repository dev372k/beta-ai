using Domain.Abstractions;
using Domain.Abstractions.DTOs.Responses;
using Domain.Entities;
using Domain;
using Shared.Exceptions;
using Shared.Constants;
using System.Net;

namespace Application.Apps;

public class AppServices(IApplicationDBContext _context, IGPTService gpt)
{
    public async Task<GetLanguageDto> GetLanguageAsync(string key, string text)
    {
        var user = _context.Set<User>().FirstOrDefault(_ => _.APIKey == key)
            ?? throw new CustomException(HttpStatusCode.Unauthorized, ExceptionMessages.INVALID_API_KEY);
        return await gpt.GetLanguage(text);
    }

    public async Task<GetSentimentDto> GetSentimentAsync(string key, string review)
    {
        var user = _context.Set<User>().FirstOrDefault(_ => _.APIKey == key) ??
            throw new CustomException(HttpStatusCode.Unauthorized, ExceptionMessages.INVALID_API_KEY);
        return await gpt.GetSentiment(review);
    }

    public async Task<GetSummaryDto> GetSummaryAsync(string key, string text)
    {
        var user = _context.Set<User>().FirstOrDefault(_ => _.APIKey == key) ??
            throw new CustomException(HttpStatusCode.Unauthorized, ExceptionMessages.INVALID_API_KEY);
        return await gpt.GetSummary(text);
    }

    public async Task<GetTranslationDto> GetTranslationAsync(string key, string text)
    {
        var user = _context.Set<User>().FirstOrDefault(_ => _.APIKey == key) ??
            throw new CustomException(HttpStatusCode.Unauthorized, ExceptionMessages.INVALID_API_KEY);
        return await gpt.GetTranslation(text);
    }
}
