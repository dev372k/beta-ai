using MongoDB.Driver;
using Domain.Documents;

namespace Domain;

public interface IApplicationDBContext
{
    IMongoCollection<User> Users { get; }
    IMongoCollection<Feedback> Feedbacks { get; }
}
