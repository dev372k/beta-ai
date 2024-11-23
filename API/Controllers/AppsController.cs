using API.Attributes;
using Application.Apps;
using Application.Apps.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Enumerations;
using Shared.Extensions;

namespace API.Controllers;

[Route(DevContants.BASE_ENDPOINT)]
[ApiController]
public class AppsController(AppServices _service) : ControllerBase
{
    [HttpPost("sentiment-analysis")]
    public async Task<IActionResult> Sentiment([FromHeader(Name = "x-api-key")] string key, GenericRequestDto request) =>
        Ok(await _service.GetAsync(key, request, enService.Sentiment_Analysis).ToResponseAsync(message: CustomMessages.SUCCESS));

    [HttpPost("text-summary")]
    public async Task<IActionResult> Summary([FromHeader(Name = "x-api-key")] string key, GenericRequestDto request) =>
        Ok(await _service.GetAsync(key, request, enService.Text_Summary).ToResponseAsync(message: CustomMessages.SUCCESS));

    [HttpPost("language-detector")]
    public async Task<IActionResult> LanguageDetector([FromHeader(Name = "x-api-key")] string key, GenericRequestDto request) =>
        Ok(await _service.GetAsync(key, request, enService.Language_Detector).ToResponseAsync(message: CustomMessages.SUCCESS));

    [HttpPost("language-translator")]
    public async Task<IActionResult> LanguageTranslator([FromHeader(Name = "x-api-key")] string key, GenericRequestDto request) =>
        Ok(await _service.GetAsync(key, request, enService.Language_Translator).ToResponseAsync(message: CustomMessages.SUCCESS));
}

