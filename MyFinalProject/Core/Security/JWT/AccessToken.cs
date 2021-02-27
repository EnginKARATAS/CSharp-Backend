using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.JWT
{
    //anlamsız kelimelerden oluşan bir dizi
    public class AccessToken
    {
        public string Token { get; set; }//json tokeni //client gönderecek
        public DateTime Expiration { get; set; }//bitiş tarihi

    }
}
