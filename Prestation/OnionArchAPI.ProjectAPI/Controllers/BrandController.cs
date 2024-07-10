using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchAPI.Application.Features.Auth.Commands.AddUser;
using OnionArchAPI.Application.Features.Brand.Commands.AddBrands;
using OnionArchAPI.Application.Features.Brand.Commands.GetBrands;

namespace OnionArchAPI.ProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var brans=await mediator.Send(new GetBrandsCommandRequest());

            return StatusCode(StatusCodes.Status200OK, brans);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBrandCommandRequest request)
        {

            await mediator.Send(request);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
