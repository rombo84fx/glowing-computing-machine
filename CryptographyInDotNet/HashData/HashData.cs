using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashData
{
    public enum HashAlgorithmType
    {
        SHA1,
        SHA256,
        SHA512,
        MD5 
    }

    public class HashData
    {
        public static byte[] ComputeHash(byte[] toBeHashed, HashAlgorithmType hashAlgorithm)
        {
            using (var hashFunction = HashAlgorithm.Create(hashAlgorithm.ToString()))
            {
                return hashFunction.ComputeHash(toBeHashed);
            }
        }
    }
}
