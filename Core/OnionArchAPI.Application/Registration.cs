using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Application.Exception;
using System.Reflection;

namespace OnionArchAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(x=>x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient<ExceptionsMiddleWare>();

        }
    }
}
