using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Infrastructure.Concretes.Services.Token
{
    public record TokenOptions(string issuer, string audience, DateTime expires,SigningCredentials signing)
    {
    
    }
}
