using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    public class Random
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
