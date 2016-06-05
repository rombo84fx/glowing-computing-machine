using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashData;

namespace Hmac
{
    class Program
    {
        static readonly string originalMessage = "Original Message to hash";
        static readonly string originalMessage2 = "This is another message to hash";

        static void Main(string[] args)
        {

            Console.WriteLine("HMAC Demonstration in .NET");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            var key = Hmac.GenerateKey();
            byte[] originalMessageBytes = Encoding.UTF8.GetBytes(originalMessage);
            byte[] originalMessage2Bytes = Encoding.UTF8.GetBytes(originalMessage2);

            var hmacMd5Message = Hmac.ComputeHmac(originalMessageBytes, key, HmacType.HMACMD5);
            var hmacMd5Message2 = Hmac.ComputeHmac(originalMessage2Bytes, key, HmacType.HMACMD5);

            var hmacSha1Message = Hmac.ComputeHmac(originalMessageBytes, key, HmacType.HMACSHA1);
            var hmacSha1Message2 = Hmac.ComputeHmac(originalMessage2Bytes, key, HmacType.HMACSHA1);

            var hmacSha256Message = Hmac.ComputeHmac(originalMessageBytes, key, HmacType.HMACSHA256);
            var hmacSha256Message2 = Hmac.ComputeHmac(originalMessage2Bytes, key, HmacType.HMACSHA256);

            var hmacSha512Message = Hmac.ComputeHmac(originalMessageBytes, key, HmacType.HMACSHA512);
            var hmacSha512Message2 = Hmac.ComputeHmac(originalMessage2Bytes, key, HmacType.HMACSHA512);

            Console.WriteLine();
            Console.WriteLine("MD5 HMAC");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(hmacMd5Message)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(hmacMd5Message2)}");

            Console.WriteLine();
            Console.WriteLine("SHA 1 HMAC");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(hmacSha1Message)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(hmacSha1Message2)}");


            Console.WriteLine();
            Console.WriteLine("SHA 256 HMAC");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(hmacSha256Message)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(hmacSha256Message2)}");


            Console.WriteLine();
            Console.WriteLine("SHA 512 HMAC");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(hmacSha512Message)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(hmacSha512Message2)}");
        }
    }
}
