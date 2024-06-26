using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Domen.Entitys
{
    public class Product : EntityBase
    {
        public Product()
        {

        }
        public Product(string Title, string Description, decimal Price, int BrandId)
        {
            this.Title = Title;
            this.Description = Description;
            this.Price = Price;
            this.BrandId = BrandId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
