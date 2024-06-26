using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Application.Features.Product.Commands.AddProduct;
using OnionArchAPI.Application.Features.Product.Commands.DeleteProduct;
using OnionArchAPI.Application.Features.Product.Commands.UpdateProduct;
using OnionArchAPI.Application.Features.Product.Querys.GetAllProducts;
using OnionArchAPI.Domen.Entitys;
using OnionArchAPI.Persistence.Concretes.UnitOfWorks;

namespace OnionArchAPI.ProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly IUnitOfWork unitOfWork;

        public ProductController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {

            return Ok(await mediator.Send(new GetAllProductsQueryRequest()));

        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductCommandRequest request) 
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
