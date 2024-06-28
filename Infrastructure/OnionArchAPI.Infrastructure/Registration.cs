using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Application.Abstractions.Services.Token;
using OnionArchAPI.Infrastructure.Concretes.Services.Token;

namespace OnionArchAPI.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {


            services.AddScoped<ITokenService,TokenService>();
        }
    }
}
