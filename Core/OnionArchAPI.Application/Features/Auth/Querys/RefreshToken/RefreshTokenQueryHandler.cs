using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnionArchAPI.Application.Abstractions.Services.Token;
using OnionArchAPI.Application.Features.Auth.Roles;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Querys.RefreshToken
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQueryRequest, RefreshTokenQueryResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly UserRoles userRoles;
        private readonly IConfiguration configuration;

        public RefreshTokenQueryHandler(UserManager<User> userManager,ITokenService tokenService,UserRoles userRoles,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.userRoles = userRoles;
            this.configuration = configuration;
        }
        public async Task<RefreshTokenQueryResponse> Handle(RefreshTokenQueryRequest request, CancellationToken cancellationToken)
        {
          

            User? user=await userManager.Users.FirstOrDefaultAsync(x=>x.RefreshToken==request.RefreshToken);

            userRoles.RefreshToken(user);

            IList<string> roles=await userManager.GetRolesAsync(user);
            var jwtSecurityToken=await tokenService.CreateAccessTokenAsync(user, roles);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string accessToken=jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            string refreshToken = tokenService.CreateRefreshToken();
            user.RefreshToken = refreshToken;
            int.TryParse(configuration["JWT:expires"], out int plusMinut);
            user.RefreshTokenExpire = DateTime.UtcNow.AddMinutes(2 * (plusMinut));
            await userManager.UpdateAsync(user);

            return new() {
                Token = new() 
                {
                AccesToken = accessToken,
                RefreshToken = refreshToken
                }
            };


        }
    }
}
