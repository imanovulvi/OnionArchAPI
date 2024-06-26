using MediatR;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Product.Commands.AddProduct
{
    public class AddProductCommandRequest:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public ICollection<int> CategoryIds { get; set; }

    }
}
