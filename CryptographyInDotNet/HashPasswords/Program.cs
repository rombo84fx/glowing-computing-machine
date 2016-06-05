using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HashPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "V3ryC0mpl3xP455w0rd";
            byte[] salt = Hash.GenerateSalt();

            Console.WriteLine("Hash Password with Salt Demonstration in .NET");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Password : {password}");
            Console.WriteLine($"Salt = {Convert.ToBase64String(salt)}");
            Console.WriteLine();

            var hashedPassword1 = Hash.HashPasswordWithSalt(
                Encoding.UTF8.GetBytes(password), salt);

            Console.WriteLine();
            Console.WriteLine($"Hashed Password = {Convert.ToBase64String(hashedPassword1)}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
