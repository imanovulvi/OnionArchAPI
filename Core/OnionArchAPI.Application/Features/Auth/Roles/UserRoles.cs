using Microsoft.IdentityModel.Tokens;
using OnionArchAPI.Application.Base;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Features.Auth.Roles
{
    public class UserRoles:BaseRules
    {
        public void NotNull(User user) 
        {
            if (string.IsNullOrEmpty(user.Email)|| string.IsNullOrEmpty(user.PasswordHash))
                throw new ApplicationException("bos kecile bilmez");
            
        }

        public void Login(User user,bool isPassword)
        {
            if (user is not { })
                throw new ApplicationException("Bele istifadeci tapilmadi");
            else if(!isPassword)
                throw new ApplicationException("Sifre yanlisdir");
        }

        public void RefreshToken(User user)
        {

            if (user == null || user.RefreshTokenExpire <= DateTime.UtcNow)
                throw new ApplicationException("Token vaxdi bitin yeniden login olun");
        }

        public void GetEmail(User user)
        {

            if (user is null)
                throw new ApplicationException("Bu Emailde user tapilmadi");
        }

    }
}
