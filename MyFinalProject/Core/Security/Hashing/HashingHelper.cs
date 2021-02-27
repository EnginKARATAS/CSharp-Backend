using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        //verdiğimiz stringin hashini oluştur, saltını da ?
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //hmac == bizim kullandığımız gömülü hashing şeyi.
            //salt ve hash ☪
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //her bir kullanıcı için bir key oluşturur
                //bir stringin byte karşılığı =   Encoding.UTF8.GetBytes(password)
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }                      
        //salting..
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
            return true;
            }
        }
    }
}
