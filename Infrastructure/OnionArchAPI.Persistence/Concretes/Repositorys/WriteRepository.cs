using Microsoft.EntityFrameworkCore;
using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Domen.Common;
using OnionArchAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Persistence.Concretes.Repositorys
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase
    {
        private readonly AppDBContext context;

        public WriteRepository()
        {

        }
        public WriteRepository(AppDBContext context)
        {
            this.context = context;
        }
        public DbSet<T> Table => context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(ICollection<T> entitys)
        {
            await Table.AddRangeAsync(entitys);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
        }
    }
}
