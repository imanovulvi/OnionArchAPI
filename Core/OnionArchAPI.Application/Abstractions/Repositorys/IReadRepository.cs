using OnionArchAPI.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Abstractions.Repositorys
{
    public interface IReadRepository<T> : IRepository<T> where T : class, IEntityBase
    {
        IQueryable<T> GetAll(bool tracing=false);

   

        Task<List<T>> GetPaginationAsync(int page, int size, bool tracing = false);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracing = false);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool tracing = false);


    }
}
