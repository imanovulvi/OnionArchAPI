﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Product.Querys.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, ICollection<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ICollection<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await this.unitOfWork.GetReadRepository<OnionArchAPI.Domen.Entitys.Product>().GetAll().ToListAsync();

            List<GetAllProductsQueryResponse> response = new List<GetAllProductsQueryResponse>();
            foreach (var item in products)
            {
                response.Add(
                    new GetAllProductsQueryResponse
                    {
                        Title = item.Title,
                        Price = item.Price,
                        Description = item.Description,
                        BrandId = item.BrandId
                    }
                    );
            }
            return response;
        }
    }
}