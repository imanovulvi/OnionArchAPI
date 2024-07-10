using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchAPI.Application.Abstractions.RedisCach;
using OnionArchAPI.Application.Abstractions.Services.Token;
using OnionArchAPI.Infrastructure.Concretes.RedisCach;
using OnionArchAPI.Infrastructure.Concretes.Services.Token;
using StackExchange.Redis;

namespace OnionArchAPI.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {


            services.AddScoped<ITokenService,TokenService>();

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration["RedisCachSettings:connectionString"]));
            services.AddScoped<IRedisCachService, RedisCachService>();
        }
    }
}
