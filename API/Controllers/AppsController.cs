using Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Extensions;

namespace API.Controllers;

[Route(DevContants.BASE_ENDPOINT)]
[ApiController]
public class AppsController(IGPTService gpt) : ControllerBase
{
    [HttpPost("sentiment")]
    public async Task<IActionResult> Sentiment(string review) => Ok(await gpt.GetSentiment(review).ToResponseAsync());

    [HttpPost("summary")]
    public async Task<IActionResult> Summary(string text) => Ok(await gpt.GetSummary(text).ToResponseAsync());
    
    [HttpPost("language-detector")]
    public async Task<IActionResult> LanguageDetector(string text) => Ok(await gpt.GetLanguage(text).ToResponseAsync());

    [HttpPost("language-translator")]
    public async Task<IActionResult> LanguageTranslator(string text) => Ok(await gpt.GetTranslation(text).ToResponseAsync());
}

