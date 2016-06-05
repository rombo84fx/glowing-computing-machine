using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            var aes = new AesEncryption();
            var key = aes.GenerateRandomNumber(32);
            var iv = aes.GenerateRandomNumber(16);
            string original = "Text to encrypt";

            var encrypted = aes.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = aes.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            WriteLine("AES Encryption Demonstration in .NET");
            WriteLine("------------------------------------");
            WriteLine();
            WriteLine($"Original Text = {original}");
            WriteLine($"Encrypted Text = {Convert.ToBase64String(encrypted)}");
            WriteLine($"Decrypted Text = {decryptedMessage}");

            ReadKey();
        }
    }
}
