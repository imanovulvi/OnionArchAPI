using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchAPI.Application.Features.Auth.Commands.AddUser;
using OnionArchAPI.Application.Features.Auth.Querys.LoginUser;

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
            
            return Ok(await mediator.Send(request));

        }

    }
}
