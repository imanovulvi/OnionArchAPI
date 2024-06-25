using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Abstractions.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>()where T : class,IEntityBase;
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase;

        int Save();
        Task<int> SaveAsync();
    }
}
