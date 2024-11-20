namespace Shared.Constants;

public class Endpoints
{
    public const string UPLOAD_BATCH = "https://api.openai.com/v1/files";
    public const string CREATE_BATCH = "https://api.openai.com/v1/batches";
    public const string CHECK_STATUS_BATCH = "https://api.openai.com/v1/batches/{0}";
    public const string GET_BATCH = "https://api.openai.com/v1/files/{0}/content";
    public const string CHAT_COMPLETION = "https://api.openai.com/v1/chat/completions";
    public const string TEXT_TO_SPEECH = "https://api.openai.com/v1/audio/speech";
}
