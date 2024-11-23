using Domain.Abstractions;
using Domain.Entities;
using Domain;
using Shared.Exceptions;
using Shared.Constants;
using System.Net;
using Shared.Enumerations;
using Microsoft.EntityFrameworkCore;
using Application.Apps.DTOs.Requests;

namespace Application.Apps;

public class AppServices(IApplicationDBContext _context, IGPTService gpt)
{

    public async Task<object> GetAsync(string key, GenericRequestDto dto, enService service)
    {
        var user = _context.Set<User>().FirstOrDefault(_ => _.APIKey == key)
            ?? throw new CustomException(HttpStatusCode.Unauthorized, ExceptionMessages.INVALID_API_KEY);
        if (service == enService.Sentiment_Analysis)
        {
            await UpsertConsumption(key, service);
            return await gpt.GetSentiment(dto.text);
        }
        else if (service == enService.Language_Translator)
        {
            await UpsertConsumption(key, service);
            return await gpt.GetLanguage(dto.text);
        }
        else if (service == enService.Text_Summary)
        {
            await UpsertConsumption(key, service);
            return await gpt.GetSummary(dto.text);
        }
        else if (service == enService.Language_Translator)
        {
            await UpsertConsumption(key, service);
            return await gpt.GetTranslation(dto.text);
        }
        else
            throw new CustomException(HttpStatusCode.NotFound, ExceptionMessages.UNKNOWN_SERVICE);
    }

    #region Private

    private async Task UpsertConsumption(string key, enService service)
    {
        var consumption = await _context.Set<Consumption>()
            .FirstOrDefaultAsync(_ => _.APIKey == key
            && _.CreatedAt.Month == DateTime.Now.Month
            && _.Service == service);

        if (consumption != null)
            consumption.Count = consumption.Count + 1;
        else
            _context.Set<Consumption>().Add(new Consumption
            {
                Service = service,
                APIKey = key,
                Count = 1,
            });
        await _context.SaveChangesAsync();
    }
    #endregion
}
