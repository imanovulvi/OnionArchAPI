using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchAPI.Application.Features.Auth.Commands.AddUser;
using OnionArchAPI.Application.Features.Auth.Commands.Revoke;
using OnionArchAPI.Application.Features.Auth.Commands.RevokeAll;
using OnionArchAPI.Application.Features.Auth.Querys.LoginUser;
using OnionArchAPI.Application.Features.Auth.Querys.RefreshToken;

namespace OnionArchAPI.ProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Registr(AddUserCommandRequest request) 
        {

           await mediator.Send(request);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserQueryRequest request)
        {
            return StatusCode(StatusCodes.Status200OK, await mediator.Send(request));

        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenQueryRequest request)
        {
            return StatusCode(StatusCodes.Status200OK, await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
