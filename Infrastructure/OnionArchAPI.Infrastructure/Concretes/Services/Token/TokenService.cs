using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionArchAPI.Application.Abstractions.Services.Token;
using OnionArchAPI.Domen.Entitys;
using SendGrid.Helpers.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnionArchAPI.Infrastructure.Concretes.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<JwtSecurityToken> CreateAccessTokenAsync(User user,IList<string> roles)
        {
            var claims = new List<Claim>() { 
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName)
            };
            foreach (var claim in roles)
                claims.Add(new Claim(ClaimTypes.Role, claim));

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["JWT:key"]));

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:audience"],
                expires:DateTime.Now.AddMinutes(int.Parse(configuration["JWT:expires"])),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims:claims
                );

            return  jwtToken;
        }

        public string CreateRefreshToken()
        {
            byte[] bytes = new byte[128];
            RandomNumberGenerator.Create().GetBytes(bytes); 
            return Convert.ToBase64String(bytes);
         
        }

     
    }
}
