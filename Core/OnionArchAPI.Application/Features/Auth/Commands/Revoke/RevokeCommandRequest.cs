using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandRequest:IRequest
    {
        public string Email { get; set; }
    }
}
