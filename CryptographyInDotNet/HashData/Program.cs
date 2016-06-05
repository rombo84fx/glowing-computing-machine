using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashData
{
    class Program
    {
        static readonly string originalMessage = "Original Message to hash";
        static readonly string originalMessage2 = "Original Message to hash";

        static void Main(string[] args)
        {
            Console.WriteLine("Secure HashData Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Original Message 1 : {originalMessage}");
            Console.WriteLine($"Original Message 2 : {originalMessage2}");
            Console.WriteLine();

            byte[] originalMessageBytes = Encoding.UTF8.GetBytes(originalMessage);
            byte[] originalMessage2Bytes = Encoding.UTF8.GetBytes(originalMessage2);

            var md5HashedMessage = HashData.ComputeHash(originalMessageBytes, HashAlgorithmType.MD5);
            var md5HashedMessage2 = HashData.ComputeHash(originalMessage2Bytes, HashAlgorithmType.MD5);
            
            var sha1HashedMessage = HashData.ComputeHash(originalMessageBytes, HashAlgorithmType.SHA1);
            var sha1HashedMessage2 = HashData.ComputeHash(originalMessage2Bytes, HashAlgorithmType.SHA1);

            var sha256HashedMessage = HashData.ComputeHash(originalMessageBytes, HashAlgorithmType.SHA256);
            var sha256HashedMessage2 = HashData.ComputeHash(originalMessage2Bytes, HashAlgorithmType.SHA256);

            var sha512HashedMessage = HashData.ComputeHash(originalMessageBytes, HashAlgorithmType.SHA512);
            var sha512HashedMessage2 = HashData.ComputeHash(originalMessage2Bytes, HashAlgorithmType.SHA512);

            Console.WriteLine();
            Console.WriteLine("MD5 Hashes");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(md5HashedMessage)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(md5HashedMessage2)}");
            Console.WriteLine();
            Console.WriteLine("SHA 1 Hashes");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(sha1HashedMessage)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(sha1HashedMessage2)}");
            Console.WriteLine();
            Console.WriteLine("SHA 256 Hashes");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(sha256HashedMessage)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(sha256HashedMessage2)}");
            Console.WriteLine();
            Console.WriteLine("SHA 512 Hashes");
            Console.WriteLine();
            Console.WriteLine($"Message 1 hash = {Convert.ToBase64String(sha512HashedMessage)}");
            Console.WriteLine($"Message 2 hash = {Convert.ToBase64String(sha512HashedMessage2)}");
            Console.WriteLine(); 
        }
    }
}
