using Application.Users.Models.Commands;
using Domain;
using Domain.Documents;
using MediatR;

namespace Application.Users.Handlers.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IApplicationDBContext _context;

    public CreateUserHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.name,
            CreatedAt = DateTime.UtcNow,
        };

        await _context.Users.InsertOneAsync(user, cancellationToken: cancellationToken);
        return user.Id;
    }
}
