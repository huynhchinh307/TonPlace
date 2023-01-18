using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace.Models
{
    public class TonUser
    {
        public string id { get; set; }
        public string token { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public string mail_token { get; set; }
        public decimal ton { get; set; }
    }
}
