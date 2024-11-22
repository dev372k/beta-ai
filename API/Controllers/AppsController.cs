using API.Attributes;
using Application.Apps;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Extensions;

namespace API.Controllers;

[Route(DevContants.BASE_ENDPOINT)]
[ApiController]
public class AppsController(AppServices _service) : ControllerBase
{
    [HttpPost("sentiment")]
    public async Task<IActionResult> Sentiment([FromHeader(Name = "x-api-key")] string key, string review) =>
        Ok(await _service.GetSentimentAsync(key, review).ToResponseAsync(message: CustomMessages.SUCCESS));

    [HttpPost("summary")]
    public async Task<IActionResult> Summary([FromHeader(Name = "x-api-key")] string key, string text) =>
        Ok(await _service.GetSummaryAsync(key, text).ToResponseAsync(message: CustomMessages.SUCCESS));

    [HttpPost("language-detector")]
    public async Task<IActionResult> LanguageDetector([FromHeader(Name = "x-api-key")] string key, string text) =>
        Ok(await _service.GetLanguageAsync(key, text).ToResponseAsync(message: CustomMessages.SUCCESS));

    [HttpPost("language-translator")]
    public async Task<IActionResult> LanguageTranslator([FromHeader(Name = "x-api-key")] string key, string text) =>
        Ok(await _service.GetTranslationAsync(key, text).ToResponseAsync(message: CustomMessages.SUCCESS));
}

