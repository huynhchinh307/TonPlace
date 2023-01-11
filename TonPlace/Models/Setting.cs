using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace.Models
{
    public class Setting
    {
        public string name_device { get; set; }
        public string key { get; set; }
        public int earn { get; set; }
        public string wallet { get; set; }
        public int? thread { get; set; }
        public Future future { get; set; }
    }

    public class Future
    {
        public string api_sms { get; set; }
        public string api_proxy { get; set; }
        public string api_captcha { get; set; }
        public string api_post { get; set; }
        public string agent { get; set; }
        public string path_profile { get; set; }
    }
}
