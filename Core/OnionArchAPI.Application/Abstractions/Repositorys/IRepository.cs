using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Abstractions.Repositorys
{
    public interface IRepository<T> where T : class,IEntityBase
    {
        public DbSet<T> Table { get;  }
    }
}
