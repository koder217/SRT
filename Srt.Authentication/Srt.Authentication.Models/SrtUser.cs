using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srt.Authentication.Models
{
    public class SrtUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
    }
}
