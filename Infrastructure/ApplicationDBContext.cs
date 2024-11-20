using Domain;
using Domain.Documents;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure;

public class ApplicationDBContext : IApplicationDBContext
{
    private readonly IMongoDatabase _db;

    public ApplicationDBContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        _db = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<User> Users => _db.GetCollection<User>("users");

    public IMongoCollection<Feedback> Feedbacks => _db.GetCollection<Feedback>("feedbacks");
}
