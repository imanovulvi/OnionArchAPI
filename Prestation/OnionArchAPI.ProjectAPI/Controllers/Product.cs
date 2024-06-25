using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Application.Features.Product.Querys.GetAllProducts;
using Ent=OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly IMediator mediator;

        public Product(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await this.mediator.Send(new GetAllProductsQueryRequest()));
        }
    }
}
