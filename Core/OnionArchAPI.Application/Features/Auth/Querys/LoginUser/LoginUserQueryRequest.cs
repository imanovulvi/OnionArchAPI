using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Querys.LoginUser
{
    public class LoginUserQueryRequest:IRequest<LoginUserQueryResponse>
    {
        [DefaultValue("imanov@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("U123456")]
        public string PasswordHash { get; set; }
    }
}
