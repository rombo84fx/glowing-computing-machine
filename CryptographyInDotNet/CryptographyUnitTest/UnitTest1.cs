using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hmac;
using HashData;
using System.Text;

namespace CryptographyUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] message = Encoding.UTF8.GetBytes("This is a message");
            var key = Hmac.Hmac.GenerateKey();

            var computeHmac1 = Convert.ToBase64String(Hmac.Hmac.ComputeHmac(message, key, HashAlgorithmType.MD5));
            var computeHmac2 = Convert.ToBase64String(Hmac.Hmac.ComputeHmac(message, key, HmacType.HMACMD5));

            Assert.IsTrue(computeHmac1 == computeHmac2);
        }
    }
}
