using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashPasswords
{
    class Hash
    {
        static readonly int saltLenght = 32;

        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLenght];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }   
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(toBeHashed, salt));
            }
        }
    }
}
