using MediatR;

namespace Application.Users.Models.Queries;

public record GetUsersQuery() : IRequest<List<Domain.Documents.User>>;