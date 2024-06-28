using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Abstractions.Services.Token
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateAccessTokenAsync(User user, IList<string> roles);

        string CreateRefreshToken();

    }
}
