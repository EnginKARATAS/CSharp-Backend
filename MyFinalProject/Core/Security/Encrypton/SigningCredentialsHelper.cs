using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Encrypton
{
    class SigningCredentialsHelper
    {
        //email k.adı -> credential -> giriş billgileri demektir
        public static SigningCredentials CreatingSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
