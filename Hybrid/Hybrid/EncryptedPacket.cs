using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hybrid
{
    public class EncryptedPacket
    {
        public byte[] EncryptedSessionKey { get; set; }
        public byte[] EncryptedData { get; set; }
        public byte[] Iv { get; set; }
        public byte[] Hmac { get; set; }
        public byte[] Signature { get; set; }
    }
}
