using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_pkcs11admin
{
    public class TokenInfo
    {
        public ulong SlotId { get; set; }
        public string SerialNumber { get; set; }
        public string TokenLabel { get; set; }
        public string TokenModel { get; set; }
    }
}
