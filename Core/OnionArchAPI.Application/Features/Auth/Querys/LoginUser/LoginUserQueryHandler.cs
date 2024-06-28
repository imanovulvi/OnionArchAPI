using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArchAPI.Application.Abstractions.Services.Token;
using OnionArchAPI.Application.Features.Auth.Roles;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Querys.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQueryRequest, LoginUserQueryResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly UserRoles userRoles;
        private readonly ITokenService tokenService;

        public LoginUserQueryHandler(UserManager<User> userManager,UserRoles userRoles, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.userRoles = userRoles;
            this.tokenService = tokenService;
        }
        public async Task<LoginUserQueryResponse> Handle(LoginUserQueryRequest request, CancellationToken cancellationToken)
        {

           User? user=await userManager.FindByEmailAsync(request.Email);

            bool isPasword = user.PasswordHash == request.PasswordHash;
            userRoles.Login(user,isPasword);

            if (isPasword)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                JwtSecurityToken jwt = await tokenService.CreateAccessTokenAsync(user, roles);
                string token = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new LoginUserQueryResponse()
                {
                    Token = new()
                    {
                        AccesToken = token,
                        Expires = DateTime.UtcNow,
                        RefreshToken = tokenService.CreateRefreshToken()
                    }

                };

            }
            return new LoginUserQueryResponse();
        }
    }
}
