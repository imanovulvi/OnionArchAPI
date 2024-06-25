using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Domen.Entitys
{
    public class Brand:EntityBase
    {
        public Brand()
        {
            
        }
        public Brand(string Name)
        {
            this.Name = Name;
        }
        public required string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
