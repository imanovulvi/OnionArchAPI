using MediatR;
using OnionArchAPI.Application.Abstractions.RedisCach;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Domen.Entitys;
using ET=OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.Application.Features.Brand.Commands.AddBrands
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommandRequest, AddBrandCommandResponse>
    {
        private readonly IRedisCachService redisCachService;
        private readonly IUnitOfWork unitOfWork;

        public AddBrandCommandHandler(IRedisCachService redisCachService,IUnitOfWork unitOfWork)
        {
            this.redisCachService = redisCachService;
            this.unitOfWork = unitOfWork;
        }
        public async Task<AddBrandCommandResponse> Handle(AddBrandCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Brand brand = new ET.Brand() 
            {
            Name=request.Name
            };
            await unitOfWork.GetWriteRepository<ET.Brand>().AddAsync(brand);
           int entityCount= await unitOfWork.SaveAsync();
            bool isCach = false;
            if (entityCount > 0)
            {
                if (await redisCachService.ExistsAsync("Brands"))
                {
                    List<ET.Brand> brandsCach = await redisCachService.GetAsync<List<ET.Brand>>("Brands");
                    brandsCach.Add(brand);


                    isCach = await redisCachService.SetAsync<List<ET.Brand>>("Brands", brandsCach);
                }
            }

           

           
            return new AddBrandCommandResponse { IsCach= isCach, EntityCount=entityCount };
        }
    }
}
