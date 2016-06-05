using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            //RsaWithRsaParameterKey();
            //RsaWithXml();
            RsaWithCsp();

            ReadKey();
        }

        private static void RsaWithCsp()
        {
            var rsaCsp = new RSAWithCSPKey();
            string original = "Text to encrypt";

            rsaCsp.AssignNewKey();

            var encrypted = rsaCsp.EncryptData(Encoding.UTF8.GetBytes(original));
            var decrypted = rsaCsp.DecryptData(encrypted);

            rsaCsp.DeleteKeyInCsp();

            DisplayRsaDemonstration(original, encrypted, decrypted);
        }

        private static void RsaWithXml()
        {
            var rsa = new RSAWithXMLKey();

            string original = "Text to encrypt";
            string publicKeyPath = @"C:\Temp\publickey.xml";
            string privateKeyPath = @"C:\Temp\privatekey.xml";

            rsa.AssignNewKey(publicKeyPath, privateKeyPath);
            var encrypted = rsa.EncryptData(publicKeyPath, Encoding.UTF8.GetBytes(original));
            var decrypted = rsa.DecryptData(privateKeyPath, encrypted);

            DisplayRsaDemonstration(original, encrypted, decrypted);
        }

        private static void RsaWithRsaParameterKey()
        {
            var rsaParams = new RSAWithRSAParameterKey();
            string original = "Text to encrypt";

            rsaParams.AssignNewKey();

            var encryptedRsaParams = rsaParams.EncryptData(Encoding.UTF8.GetBytes(original));
            var decryptedRsaParams = rsaParams.DecryptData(encryptedRsaParams);

            DisplayRsaDemonstration(original, encryptedRsaParams, decryptedRsaParams);
        }

        private static void DisplayRsaDemonstration(string original, byte[] encryptedRsaParams, byte[] decryptedRsaParams)
        {
            WriteLine("RSA Encryption Demonstration in .NET");
            WriteLine("------------------------------------");
            WriteLine();
            WriteLine($"    Original Text = {original}");
            WriteLine();
            WriteLine($"    Encrypted Text = {Convert.ToBase64String(encryptedRsaParams)}");
            WriteLine();
            WriteLine($"    Decrypted Text = {Encoding.Default.GetString(decryptedRsaParams)}");
            WriteLine();
            WriteLine();
        }
    }
}
