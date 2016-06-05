using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random Number Demonstration in .NET");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random Number {i} : {Convert.ToBase64String(Random.GenerateRandomNumber(32))}");
            }

            Console.ReadLine();
        }
    }
}
