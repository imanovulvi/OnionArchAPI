using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Application.Base;
using OnionArchAPI.Application.Exception;
using OnionArchAPI.Application.Features.Product.Rules;
using System.Reflection;

namespace OnionArchAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(x=>x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient<ExceptionsMiddleWare>();

            services.AddRulesFromAssemblies();

        }

        public static void AddRulesFromAssemblies(this IServiceCollection services) 
        {
            var assembly=Assembly.GetExecutingAssembly();
            foreach (var item in assembly.GetTypes())
                if (item.IsClass && item.IsSubclassOf(typeof(BaseRules))&& item!=typeof(BaseRules))
                    services.AddTransient(item);


        }

    }
}
