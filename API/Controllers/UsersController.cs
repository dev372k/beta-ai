using Application.Users;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;

namespace API.Controllers;

[Route(DevContants.BASE_ENDPOINT)]
[ApiController]
public class UsersController(UserServices _service) : ControllerBase
{
    //[HttpPost]
    //public async Task<IActionResult> Post(CreateUserCommand command) =>
    //    Ok(await _mediator.Send(command).ToResponseAsync());

    //[HttpGet]
    //public async Task<IActionResult> Get() =>
    //    Ok(await _mediator.Send(new GetUsersQuery()).ToResponseAsync());
}
