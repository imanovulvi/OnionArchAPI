using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArchAPI.Application.Features.Auth.Roles;
using OnionArchAPI.Domen.Entitys;

namespace OnionArchAPI.Application.Features.Auth.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest>
    {
        private readonly UserManager<User> usermanager;
        private readonly UserRoles userRoles;

        public AddUserCommandHandler(UserManager<User> usermanager,UserRoles userRoles)
        {
            this.usermanager = usermanager;
            this.userRoles = userRoles;
        }
        public async Task Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {

            User user = new User {
            FullName=request.FullName,
            Email=request.Email,
            PasswordHash=request.PasswordHash,
            UserName=request.UserName
            };
            userRoles.NotNull(user);

            await usermanager.CreateAsync(user);
            
        }
    }
}
