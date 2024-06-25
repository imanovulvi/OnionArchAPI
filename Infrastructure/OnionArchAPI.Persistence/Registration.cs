using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Persistence.Concretes.Repositorys;
using OnionArchAPI.Persistence.Context;

namespace OnionArchAPI.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(configuration.GetConnectionString("sqlConnectionStr")));
            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
}
