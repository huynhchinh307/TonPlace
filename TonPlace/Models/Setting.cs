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

        public int num_tab { get; set; }
        public int num_post { get; set; }
        public int num_like { get; set; }
        public int num_comment { get; set; }

        public string link_ref { get; set; }
        public string path { get; set; }
        public API API { get; set; }
        public Future future { get; set; }
    }

    public class Future
    {
        public string agent { get; set; }
        public string path_profile { get; set; }
    }

    public class API
    {
        public string api_mail { get; set; }
        public string api_captcha { get; set; }
        public string api_proxy { get; set; }
        public string api_sms { get; set; }
        public string api_post { get; set; }
    }
}
