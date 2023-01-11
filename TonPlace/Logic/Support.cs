using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;


namespace TonPlace.Logic
{
    class Support
    {
        Logger log = LogManager.GetCurrentClassLogger();

        public bool TonCookie(string id)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.StackTrace, "Nạp cookie bị Error");
                return false;
            }
        }
    }
}
