using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace
{
    class RSS
    {
        public static string feed_following = "https://ton.place/feed?section=following";
        public static string search = "https://ton.place/search";
        public static string inbox = "https://ton.place/im{0}";
        public static string profile = "https://ton.place/id{0}";
        public static string create_post = "https://ton.place/feed?section=following&w=post";
        public static string add_like = "https://api.ton.place/likes/{0}/post/add";
        public static string add_status = "https://ton.place/{0}?w=status";
    }
}
