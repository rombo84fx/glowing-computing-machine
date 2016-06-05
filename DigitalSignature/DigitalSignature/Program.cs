using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static System.Console;

namespace DigitalSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = Encoding.UTF8.GetBytes("Document to Sign");
            byte[] hashedDocument;

            using (var sha256 = SHA256.Create())
            {
                hashedDocument = sha256.ComputeHash(document);
            }

            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            var signature = digitalSignature.SignData(hashedDocument);
            var verified = digitalSignature.VerifySignature(hashedDocument, signature);

            WriteLine("Digital Signature Demonstration in .NET");
            WriteLine("---------------------------------------");
            WriteLine();
            WriteLine();
            WriteLine($"Original Text = {Encoding.Default.GetString(document)}");
            WriteLine();
            WriteLine($"Digital Signature = {Convert.ToBase64String(signature)}");
            WriteLine();
            WriteLine(verified ? "The digital signature has been correctly verified." : "The digital signature has NOT been correctly verified");

            ReadKey();
        }
    }
}
