using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DigitalSignature
{
    public class DigitalSignature
    {
        private RSAParameters _publicKey; 
        private RSAParameters _privateKey;
        private readonly string hashAlgorithm = "SHA256";

        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                this._publicKey = rsa.ExportParameters(false);
                this._privateKey = rsa.ExportParameters(true);
            }
        }

        public byte[] SignData(byte[] hashOfDataToSign)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(this._privateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm(this.hashAlgorithm);

                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }

        public bool VerifySignature(byte[] hashOfDataToSign, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(this._publicKey);

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm(this.hashAlgorithm);

                return rsaDeformatter.VerifySignature(hashOfDataToSign, signature);
            }
        }
    }
}
