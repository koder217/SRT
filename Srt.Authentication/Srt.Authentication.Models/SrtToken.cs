using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srt.Authentication.Models
{
    public class SrtToken
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
