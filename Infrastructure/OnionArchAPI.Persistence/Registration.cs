using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Application.Abstractions.Repositorys;
using OnionArchAPI.Application.Abstractions.UnitOfWorks;
using OnionArchAPI.Domen.Entitys;
using OnionArchAPI.Persistence.Concretes.Repositorys;
using OnionArchAPI.Persistence.Concretes.UnitOfWorks;
using OnionArchAPI.Persistence.Context;

namespace OnionArchAPI.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(configuration.GetConnectionString("sqlConnectionStr")));
            _ = services.AddIdentityCore<User>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
            }
             ).AddRoles<Role>().AddEntityFrameworkStores<AppDBContext>();




            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
