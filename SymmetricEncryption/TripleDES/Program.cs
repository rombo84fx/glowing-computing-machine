using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleDES
{
    class Program
    {
        static void Main(string[] args)
        {
            var tripleDes = new TripleDESEncryption();
            var key = tripleDes.GenerateRandomNumber(24);
            var iv = tripleDes.GenerateRandomNumber(8);

            string original = "Text to encrypt";

            var encrypted = tripleDes.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = tripleDes.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("Triple DES Encryption Demonstration in .NET");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Original Text = {original}");
            Console.WriteLine($"Encrypted Text = {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrypted Text = {decryptedMessage}");

            Console.ReadKey();
        }
    }
}
