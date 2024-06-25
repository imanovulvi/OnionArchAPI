using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Domen.Common
{
    public class EntityBase:IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.UtcNow;
        public bool IsDelete { get; set; }=false;
    }
}
