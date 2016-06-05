using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Program
    {
        static void Main(string[] args)
        {
            var des = new DesEncryption();
            var key = des.GenerateRandomNumber(8);
            var iv = des.GenerateRandomNumber(8);
            string original = "Text to encrypt";

            var encrypted = des.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = des.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("DES Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Original Text = {original}");
            Console.WriteLine($"Encrypted Text = {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrypted Text = {decryptedMessage}");

            Console.ReadKey();
        }
    }
}
