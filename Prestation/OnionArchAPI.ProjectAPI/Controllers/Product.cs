using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using Ent=OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public Product(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await unitOfWork.GetReadRepository<Ent.Product>().GetAll().ToListAsync());
        }
    }
}
