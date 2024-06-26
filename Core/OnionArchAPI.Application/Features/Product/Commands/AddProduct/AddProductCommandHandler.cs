using MediatR;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Domen.Entitys;
using ETY = OnionArchAPI.Domen.Entitys;


namespace OnionArchAPI.Application.Features.Product.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            ETY::Product product = new()
            {
                Title = request.Title,
                BrandId = request.BrandId,
                Description = request.Description,
                Price = request.Price

            };

            await unitOfWork.GetWriteRepository<ETY::Product>().AddAsync(product);
         
            
            if (await unitOfWork.SaveAsync() > 0)
            {
                List<ProductCategory> lis = new();
                foreach (var item in request.CategoryIds)
                {
                    lis.Add(new ProductCategory { CategoryId = item, ProductId = product.Id });
                }
                await unitOfWork.GetWriteRepository<ProductCategory>().AddRangeAsync(lis);

                await unitOfWork.SaveAsync();
                await unitOfWork.DisposeAsync();
            }




        }

        
    }
}
