using MediatR;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using ETY = OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ETY::Product product = new() {
            
                Id=request.Id,
                Title=request.Title,
                Description=request.Description,
                Price=request.Price,
                BrandId=request.BrandId,

            };
            await unitOfWork.GetWriteRepository<ETY.Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
           await unitOfWork.DisposeAsync();
        }
    }
}
