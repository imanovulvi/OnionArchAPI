using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Domen.Entitys
{
    public class Detail:EntityBase
    {
        public Detail()
        {
            
        }
        public Detail(string Title,string Dexription,int CategoryId)
        {
           this.Title = Title;
            this.Description = Dexription;
            this.CategoryId = CategoryId;
        }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
