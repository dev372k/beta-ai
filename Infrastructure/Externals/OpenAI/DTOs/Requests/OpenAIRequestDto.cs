using System.Text.Json.Serialization;

namespace Infrastructure.Externals.OpenAI.DTOs.Requests;

public class OpenAIRequestDto
{
    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("messages")]
    public List<OpenAIMessageRequestDto> Messages { get; set; }

    [JsonPropertyName("temperature")]
    public float Temperature { get; set; }

    [JsonPropertyName("max_tokens")]
    public int MaxTokens { get; set; }
}