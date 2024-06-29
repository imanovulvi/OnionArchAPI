using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArchAPI.Application.Features.Auth.Roles;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest>
    {
        private readonly UserManager<User> userManager;
        private readonly UserRoles userRoles;

        public RevokeCommandHandler(UserManager<User> userManager,UserRoles userRoles)
        {
            this.userManager = userManager;
            this.userRoles = userRoles;
        }
        public async Task Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email);
            userRoles.GetEmail(user);

            user.RefreshToken = null;
            user.RefreshTokenExpire = null;
            await userManager.UpdateAsync(user);


        }
    }
}
