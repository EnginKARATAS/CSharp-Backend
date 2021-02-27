using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Encrypton
{
    //şifreleme yapmak için onları byte attay yapmamız gerekiyor. asp net öyle anlıyır
    //bytea çevir. web tokenin ihtiyaç duyduğu şekilde byta çevir
    public class SecurityKeyHelper
    {
        public static  SecurityKey CreateSecurityKey (string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
