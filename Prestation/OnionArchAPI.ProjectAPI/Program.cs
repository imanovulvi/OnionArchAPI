using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnionArchAPI.Application;
using OnionArchAPI.Application.Exception;
using OnionArchAPI.Infrastructure;
using OnionArchAPI.Persistence;
using System.Text;

namespace OnionArchAPI.ProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(configure => configure.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters 
            { 
                ValidateLifetime = true,
                ValidateAudience= true,
                ValidateIssuer= true,
                ValidAudience = builder.Configuration["JWT:audience"],
                ValidIssuer= builder.Configuration["JWT:issuer"],
                IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"])),
                LifetimeValidator= (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)=>expires != null? expires>DateTime.UtcNow:false
            }
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionsMiddleWare>();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
