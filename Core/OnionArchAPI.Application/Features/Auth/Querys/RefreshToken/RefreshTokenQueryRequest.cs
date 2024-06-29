using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Querys.RefreshToken
{
    public class RefreshTokenQueryRequest:IRequest<RefreshTokenQueryResponse>
    {
        public string RefreshToken { get; set; }
    }
}
