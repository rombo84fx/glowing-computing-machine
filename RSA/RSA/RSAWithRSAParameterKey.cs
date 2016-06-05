using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSA
{
    public class RSAWithRSAParameterKey
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                this._publicKey = rsa.ExportParameters(false);
                this._privateKey = rsa.ExportParameters(true);
            }
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(this._publicKey);

                cipherbytes = rsa.Encrypt(dataToEncrypt, true);
            }

            return cipherbytes;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(this._privateKey);

                plain = rsa.Decrypt(dataToDecrypt, true);
            }

            return plain;
        }
    }
}
