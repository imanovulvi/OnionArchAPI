using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Domen.Common;
using OnionArchAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Persistence.Concretes.Repositorys
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase
    {
        private readonly AppDBContext appDBContext;

        public ReadRepository()
        {
            
        }
        public ReadRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public DbSet<T> Table => this.appDBContext.Set<T>();

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool tracing = false)
        {
            if (!tracing)
               return await Table.AsNoTracking().CountAsync(predicate);

            return await Table.CountAsync(predicate);
        }

       
        public IQueryable<T> GetAll(bool tracing = false)
        {
            if (!tracing)
                return Table.AsNoTracking();
            return Table;
        }

      

        public async Task<List<T>> GetPaginationAsync(int page, int size, bool tracing = false)
        {
            if (!tracing)
                return await Table.AsNoTracking().Skip((page - 1) * size).Take(size).ToListAsync();
            return await Table.Skip((page-1)*size).Take(size).ToListAsync();

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracing = false)
        {
            if (!tracing)
                return Table.AsNoTracking().Where(predicate);
            return Table.Where(predicate);
        }

     
    }
}
