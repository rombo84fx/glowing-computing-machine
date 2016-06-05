using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace RSA
{
    public class RSAWithXMLKey
    {
        public void AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKeyPath))
                {
                    File.Delete(privateKeyPath);
                }

                if (File.Exists(publicKeyPath))
                {
                    File.Delete(publicKeyPath);
                }

                var publicKeyFolder = Path.GetDirectoryName(publicKeyPath);
                var privateKeyFolder = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyFolder))
                {
                    Directory.CreateDirectory(publicKeyFolder);
                }

                if (!Directory.Exists(privateKeyFolder))
                {
                    Directory.CreateDirectory(privateKeyFolder);
                }

                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
            }
        }

        public byte[] EncryptData(string publicKeyPath, byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKeyPath));

                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }

        public byte[] DecryptData(string privateKeyPath, byte[] dataToDecrypt)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
    }
}
