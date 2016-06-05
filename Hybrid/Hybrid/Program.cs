using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AES;
using RSA;
using static System.Console;
using System.Security.Cryptography;
using DigitalSignature;

namespace Hybrid
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = "Very secret and important information that can not fall into the wrong hands.";

            var hybrid = new HybridEncryption();

            var rsaParams = new RSAWithRSAParameterKey();
            rsaParams.AssignNewKey();

            var digitalSignature = new DigitalSignature.DigitalSignature();
            digitalSignature.AssignNewKey();

            WriteLine("Hybrid Encryption with Integrity Check Demonstration in .NET");
            WriteLine("---------------------------------------");
            WriteLine();

            try
            {
                var encryptedBlock = hybrid.EncryptData(Encoding.UTF8.GetBytes(original), rsaParams, digitalSignature);
                var decrypted = hybrid.DecryptData(encryptedBlock, rsaParams, digitalSignature);

                WriteLine($"Original Message  = {original}");
                WriteLine();
                WriteLine($"Message After Decryption = {Encoding.UTF8.GetString(decrypted)}");

            }
            catch (CryptographicException ex)
            {
                WriteLine($"Error : {ex.Message}");
            }

            ReadKey();
        }
    }
}
