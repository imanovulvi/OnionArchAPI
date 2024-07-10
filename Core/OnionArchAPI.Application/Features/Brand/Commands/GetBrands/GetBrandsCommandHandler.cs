using MediatR;
using OnionArchAPI.Application.Abstractions.RedisCach;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using ET = OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.Application.Features.Brand.Commands.GetBrands
{
    public class GetBrandsCommandHandler : IRequestHandler<GetBrandsCommandRequest, List<GetBrandsCommandResponse>>
    {
        private readonly IRedisCachService redisCachService;
        private readonly IUnitOfWork unitOfWork;

        public GetBrandsCommandHandler(IRedisCachService redisCachService,IUnitOfWork unitOfWork)
        {
            this.redisCachService = redisCachService;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<GetBrandsCommandResponse>> Handle(GetBrandsCommandRequest request, CancellationToken cancellationToken)
        {
         
            List<ET.Brand> brands;
            brands = await redisCachService.GetAsync<List<ET.Brand>>("Brands");
            if (brands == null) 
            {
                brands = unitOfWork.GetReadRepository<ET.Brand>().GetAll().ToList();
                await redisCachService.SetAsync<List<ET.Brand>>("Brands", brands);
            }

            List<GetBrandsCommandResponse> response = new();
            foreach (var item in brands)
            {
                response.Add(new GetBrandsCommandResponse { Name = item.Name });
            }

            return response;
        }
    }
}
