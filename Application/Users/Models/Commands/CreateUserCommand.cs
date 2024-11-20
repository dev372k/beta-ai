using MediatR;

namespace Application.Users.Models.Commands;

public record CreateUserCommand(string name) : IRequest<string>;
