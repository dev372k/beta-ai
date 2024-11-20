using System.Text.Json.Serialization;

namespace Infrastructure.Externals.OpenAI.DTOs.Requests;

public class OpenAIMessageRequestDto
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}