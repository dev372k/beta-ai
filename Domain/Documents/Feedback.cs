using MongoDB.Bson.Serialization.Attributes;
using Shared.Enumerations;

namespace Domain.Documents;

public class Feedback : Base
{
    [BsonElement("email")]
    public required string Email { get; set; }
    
    [BsonElement("review")]
    public required string Review { get; set; }
    
    [BsonElement("rating")]
    public int Rating { get; set; }
    
    [BsonElement("sentiment")]
    public required string Sentiment { get; set; }
    
    [BsonElement("insight")]
    public string Insight { get; set; } = String.Empty;
}
