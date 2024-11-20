using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Documents;

public class User : Base
{
    [BsonElement("name")]
    public required string Name { get; set; }
}