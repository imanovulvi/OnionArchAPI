using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Domen.Entitys
{
    public class Category:EntityBase
    {
        public Category()
        {
            
        }
        public Category(int ParentId,string Name,int Priorty)
        {
            this.ParentId = ParentId;
            this.Name = Name;
            this.Priorty = Priorty;
        }
        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priorty { get; set; }

        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
