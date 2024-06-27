using ET = OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchAPI.Application.Base;

namespace OnionArchAPI.Application.Features.Product.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleAgain(List<ET.Product> products, string titleRequest)
        {
            if (products.Any(p => p.Title == titleRequest))
                throw new ApplicationException("Title eyni ola bilmez");

            return Task.CompletedTask;


        }
    }
}
