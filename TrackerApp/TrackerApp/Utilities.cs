using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerApp
{
    public class Utilities
    {
        public static long timeNowMilliseconds()
        {
            DateTime now = DateTime.Now;
            return new DateTimeOffset(now).ToUnixTimeMilliseconds();
        }
    }
}
