using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Infrastructure.Externals.OpenAI.DTOs.Responses;
using Infrastructure.Externals.OpenAI.DTOs.Requests;
using Shared.Constants;
using Shared.Helpers;
using Domain.Abstractions;
using Domain.Abstractions.DTOs.Responses;

namespace Infrastructure.Externals.OpenAI;

public class GPTService : IGPTService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public GPTService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["OpenAIKey"]);
    }

    public async Task<GetLanguageDto> GetLanguage(string text)
    {
        var request = new OpenAIRequestDto
        {
            Model = "gpt-4o",
            Messages = new List<OpenAIMessageRequestDto>{
                    new OpenAIMessageRequestDto
                    {
                        Role = "system",
                        Content = @"Extract the language and dialect both in json
                        {
                            ""language""
                        } for e language(dialect) example italian(Sicilian) etc"
                    },
                    new OpenAIMessageRequestDto
                    {
                        Role = "user",
                        Content = text
                    }
                },
            MaxTokens = 100
        };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Endpoints.CHAT_COMPLETION, content);
        var resjson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponseDto>(resjson)!;
            throw new Exception(errorResponse.Error.Message);
        }

        var data = JsonSerializer.Deserialize<OpenAIResponseDto>(resjson)!;

        var responseModel = JsonSerializer.Deserialize<OpenAICustomLanguageDetectorDto>(SanitizeHelper.SanitizeJsonString(data.choices[0].message.content));

        return new GetLanguageDto
        (
            responseModel!.language
        );
    }

    public async Task<GetSentimentDto> GetSentiment(string review)
    {
        var request = new OpenAIRequestDto
        {
            Model = "gpt-4o",
            Messages = new List<OpenAIMessageRequestDto>{
                    new OpenAIMessageRequestDto
                    {
                        Role = "system",
                        Content = @"Generate a response in json
                        {
                            ""insight""
                            ""sentiment""
                        }
                        and sentiment enum values [Very_Positive, Positive, Neutral, Negative, Very_Negative, Mixed]"
                    },
                    new OpenAIMessageRequestDto
                    {
                        Role = "user",
                        Content = review
                    }
                },
            MaxTokens = 100
        };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Endpoints.CHAT_COMPLETION, content);
        var resjson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponseDto>(resjson)!;
            throw new Exception(errorResponse.Error.Message);
        }

        var data = JsonSerializer.Deserialize<OpenAIResponseDto>(resjson)!;

        var responseModel = JsonSerializer.Deserialize<OpenAICustomInsightDto>(SanitizeHelper.SanitizeJsonString(data.choices[0].message.content));

        return new GetSentimentDto
        (
            responseModel!.sentiment,
            responseModel.insight
        );
    }
    
    public async Task<GetSummaryDto> GetSummary(string text)
    {
        var request = new OpenAIRequestDto
        {
            Model = "gpt-4o",
            Messages = new List<OpenAIMessageRequestDto>{
                    new OpenAIMessageRequestDto
                    {
                        Role = "system",
                        Content = @"Summarize the text and Generate a response in json
                        {
                            ""summary""
                        }"
                    },
                    new OpenAIMessageRequestDto
                    {
                        Role = "user",
                        Content = text
                    }
                },
            MaxTokens = 100
        };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Endpoints.CHAT_COMPLETION, content);
        var resjson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponseDto>(resjson)!;
            throw new Exception(errorResponse.Error.Message);
        }

        var data = JsonSerializer.Deserialize<OpenAIResponseDto>(resjson)!;

        var responseModel = JsonSerializer.Deserialize<OpenAICustomSummarizerDto>(SanitizeHelper.SanitizeJsonString(data.choices[0].message.content));

        return new GetSummaryDto
        (
            responseModel!.summary
        );
    }

    public async Task<GetTranslationDto> GetTranslation(string text)
    {
        var request = new OpenAIRequestDto
        {
            Model = "gpt-4o",
            Messages = new List<OpenAIMessageRequestDto>{
                    new OpenAIMessageRequestDto
                    {
                        Role = "system",
                        Content = @"Translate the language in json
                        {
                            ""translation""
                        }"
                    },
                    new OpenAIMessageRequestDto
                    {
                        Role = "user",
                        Content = text
                    }
                },
            MaxTokens = 100
        };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Endpoints.CHAT_COMPLETION, content);
        var resjson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponseDto>(resjson)!;
            throw new Exception(errorResponse.Error.Message);
        }

        var data = JsonSerializer.Deserialize<OpenAIResponseDto>(resjson)!;

        var responseModel = JsonSerializer.Deserialize<OpenAICustomLanguageTranslatorDto>(SanitizeHelper.SanitizeJsonString(data.choices[0].message.content));

        return new GetTranslationDto
        (
            responseModel!.translation
        );
    }
}
