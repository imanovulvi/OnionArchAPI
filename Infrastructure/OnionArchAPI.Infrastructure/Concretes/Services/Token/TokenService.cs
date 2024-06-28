using OnionArchAPI.Application.Abstractions.Services.Token;
using OnionArchAPI.Domen.Entitys;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnionArchAPI.Infrastructure.Concretes.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly TokenOptions options;

        public TokenService(TokenOptions options)
        {
            this.options = options;
        }
        public async Task<JwtSecurityToken> CreateAccessToken(User user,List<string> roles)
        {
            var claims = new List<Claim>() { 
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName)
            };
            foreach (var claim in roles)
                claims.Add(new Claim(ClaimTypes.Role, claim));
            

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer:options.issuer,
                audience:options.audience,
                expires:options.expires,
                signingCredentials:options.signing,
                claims:claims
                );

            return  jwtToken;
        }
    }
}
