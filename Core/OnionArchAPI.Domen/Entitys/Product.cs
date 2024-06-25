using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Domen.Entitys
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string Title,string Description,int BrandId)
        {
            this.Title = Title;
            this.Description = Description;
            this.BrandId = BrandId;
        }
        public required string Title { get; set; }
        public required string  Description { get; set; }
        public required int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
