using Application.Users.Models.Queries;
using Domain;
using MediatR;
using MongoDB.Driver;

namespace Application.Users.Handlers.Queries;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<Domain.Documents.User>>
{
    private readonly IApplicationDBContext _context;

    public GetUsersHandler(IApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Documents.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .Find(_ => true)
            .ToListAsync(cancellationToken);
    }
}
