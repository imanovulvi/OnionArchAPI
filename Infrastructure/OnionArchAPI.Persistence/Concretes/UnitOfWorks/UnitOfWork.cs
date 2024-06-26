using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Persistence.Concretes.Repositorys;
using OnionArchAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Persistence.Concretes.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext context;

        public UnitOfWork(AppDBContext context)
        {
            this.context = context;
         
        }



        public async ValueTask DisposeAsync() =>  await context.DisposeAsync();

        public int Save() => this.context.SaveChanges();

        public async Task<int> SaveAsync() => await this.context.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
            => new ReadRepository<T>(context);
        

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        =>new WriteRepository<T>(context);
    }
}
