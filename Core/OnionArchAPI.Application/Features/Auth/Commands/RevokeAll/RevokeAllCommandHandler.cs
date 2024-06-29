using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Commands.RevokeAll
{
    public class RevokeAllCommandHandler : IRequestHandler<RevokeAllCommandRequest>
    {
        private readonly UserManager<User> userManager;

        public RevokeAllCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpire = null;
                await userManager.UpdateAsync(user);
            }
        }
    }
}
