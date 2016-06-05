using AES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSA;
using System.Security.Cryptography;
using DigitalSignature;

namespace Hybrid
{
    public class HybridEncryption
    {
        private readonly AesEncryption _aes = new AesEncryption();

        public EncryptedPacket EncryptData(byte[] original, RSAWithRSAParameterKey rsaParams, DigitalSignature.DigitalSignature digitalSignature)
        {
            // Generate our session key.
            var sessionKey = this._aes.GenerateRandomNumber(32);

            // Create the encrypted packet and generate the IV.
            var encryptedPacket = new EncryptedPacket { Iv = this._aes.GenerateRandomNumber(16) };

            // Encrypt our data with AES.
            encryptedPacket.EncryptedData = this._aes.Encrypt(original, sessionKey, encryptedPacket.Iv);

            // Encrypt the session key with RSA
            encryptedPacket.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);

            using (var hmac = new HMACSHA256(sessionKey))
            {
                encryptedPacket.Hmac = hmac.ComputeHash(encryptedPacket.EncryptedData);
            }

            encryptedPacket.Signature = digitalSignature.SignData(encryptedPacket.Hmac);

            return encryptedPacket;
        }

        public byte[] DecryptData(EncryptedPacket encryptedPacket, RSAWithRSAParameterKey rsaParams, DigitalSignature.DigitalSignature digitalSignature)
        {
            // Decrypt AES Key with RSA.
            var decryptedSessionKey = rsaParams.DecryptData(encryptedPacket.EncryptedSessionKey);

            using (var hmac = new HMACSHA256(decryptedSessionKey))
            {
                var hmacToCheck = hmac.ComputeHash(encryptedPacket.EncryptedData);

                if (!Compare(encryptedPacket.Hmac, hmacToCheck))
                {
                    throw new CryptographicException("HMAC for decryption does not match encrypted packet.");
                }

                if (!digitalSignature.VerifySignature(encryptedPacket.Hmac, encryptedPacket.Signature))
                {
                    throw new CryptographicException("Digital Signature can not be verified");
                }
            }

            // Decrypt our data with AES using the decrypted session key.
            var decryptedData = this._aes.Decrypt(encryptedPacket.EncryptedData, decryptedSessionKey, encryptedPacket.Iv);

            return decryptedData;
        }

        private static bool Compare(byte[] hmac, byte[] hmacToCheck)
        {
            var result = hmac.Length == hmacToCheck.Length;

            for (int i = 0; i < hmac.Length && i < hmacToCheck.Length; i++)
            {
                result &= hmac[i] == hmacToCheck[i];
            }

            return result;
        }
    }
}
