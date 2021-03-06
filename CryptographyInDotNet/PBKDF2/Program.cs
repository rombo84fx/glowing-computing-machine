﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBKDF2
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwordToHash = "VeryComplexPassword";

            Console.WriteLine("Password Based Key Derivation Function Demonstration in .NET");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("PBKDF2 Hashes");
            Console.WriteLine();

            HashPassword(passwordToHash, 1000);
            HashPassword(passwordToHash, 10000);
            HashPassword(passwordToHash, 50000);
            HashPassword(passwordToHash, 100000);
            HashPassword(passwordToHash, 200000);
            HashPassword(passwordToHash, 500000);

            Console.ReadKey();
        }

        private static void HashPassword(string passwordToHash, int numberOfRounds)
        {
            var sw = new Stopwatch();
            sw.Start();

            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(passwordToHash),
                PBKDF2.GenerateSalt(), numberOfRounds);

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"Password to hash : {passwordToHash}");
            Console.WriteLine($"Hashed Password : {Convert.ToBase64String(hashedPassword)}");
            Console.WriteLine($"Iterations <{numberOfRounds}> Elapsed Time : {sw.ElapsedMilliseconds}");
        }
    }
}
