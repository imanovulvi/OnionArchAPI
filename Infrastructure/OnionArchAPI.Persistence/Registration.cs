using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Persistence.Context;

namespace OnionArchAPI.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(configuration.GetConnectionString("sqlConnectionStr")));
        }
    }
}
