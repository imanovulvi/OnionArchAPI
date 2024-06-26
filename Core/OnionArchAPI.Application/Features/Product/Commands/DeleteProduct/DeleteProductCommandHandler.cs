using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETY = OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
           ETY.Product? product= await unitOfWork.GetReadRepository<ETY::Product>().GetAll().FirstOrDefaultAsync(x=>x.Id==request.Id);

            await unitOfWork.GetWriteRepository<ETY::Product>().DeleteAsync(product);
            await unitOfWork.SaveAsync();
            await unitOfWork.DisposeAsync();
        }
    }
}
