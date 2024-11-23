using Shared.Enumerations;

namespace Domain.Entities;

public class Consumption : Base
{
    public enService Service { get; set; }
    public int Count { get; set; }
    public required string APIKey { get; set; }
}
