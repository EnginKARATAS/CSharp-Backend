using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.JWT
{
    //client kullanıcı adı ve şifre doğruysa token oluştur dbye yazar:, tokeni cliente gönderir
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> opreationClaims);
    }
}
