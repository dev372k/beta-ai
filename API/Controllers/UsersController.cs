using Application.Users.Models.Commands;
using Application.Users.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Extensions;

namespace API.Controllers;

[Route(DevContants.BASE_ENDPOINT)]
[ApiController]
public class UsersController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command) =>
        Ok(await _mediator.Send(command).ToResponseAsync());

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _mediator.Send(new GetUsersQuery()).ToResponseAsync());
}
