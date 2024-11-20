namespace Infrastructure.Externals.OpenAI.DTOs.Responses;

public class OpenAICustomInsightDto
{
    public string insight { get; set; } = String.Empty;
    public string sentiment { get; set; } = String.Empty;
}

public class OpenAICustomSummarizerDto
{
    public string summary { get; set; } = String.Empty;
}

public class OpenAICustomLanguageDetectorDto
{
    public string language { get; set; } = String.Empty;
}

public class OpenAICustomLanguageTranslatorDto
{
    public string translation { get; set; } = String.Empty;
}
