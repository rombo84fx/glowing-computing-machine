using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using HashData;

namespace Hmac
{
    public enum HmacType
    {
        HMACMD5,
        HMACSHA1,
        HMACSHA256,
        HMACSHA512
    }

    public class Hmac
    {
        private static readonly int KeySize = 32;

        public static byte[] GenerateKey()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[KeySize];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] ComputeHmac(byte[] toBeHashed, byte[] key, HashAlgorithmType hashAlgorithm)
        {
            switch (hashAlgorithm)
            {
                case HashAlgorithmType.SHA1:
                    using (var hmac = new HMACSHA1(key))
                    {
                        return hmac.ComputeHash(toBeHashed);
                    }
                case HashAlgorithmType.SHA256:
                    using (var hmac = new HMACSHA256(key))
                    {
                        return hmac.ComputeHash(toBeHashed);
                    }
                case HashAlgorithmType.SHA512:
                    using (var hmac = new HMACSHA512(key))
                    {
                        return hmac.ComputeHash(toBeHashed);
                    }
                case HashAlgorithmType.MD5:
                    using (var hmac = new HMACMD5(key))
                    {
                        return hmac.ComputeHash(toBeHashed);
                    }
                default:
                    Console.WriteLine("Unknown hash algorithm");
                    return toBeHashed;
            }
        }

        public static byte[] ComputeHmac(byte[] toBeHashed, byte[] key, HmacType hmacAlgorithm)
        {
            using (var hmac = HMAC.Create(hmacAlgorithm.ToString()))
            {
                hmac.Key = key;
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
}
