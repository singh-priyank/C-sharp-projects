using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;

namespace TrackerApp
{
    class Program
    {
        public static Dictionary<string, Tuple<long, int>> applicationUsage = new Dictionary<string, Tuple<long, int>>();
        static async Task Main(string[] args)
        {
            Collector collector = new Collector();
            Console.WriteLine("Hello World!");
            var activeProcessOld = collector.GetProcessIdAndName();

            DateTime now = DateTime.Now;
            long unixTimeMilliseconds = new DateTimeOffset(now).ToUnixTimeMilliseconds();
            applicationUsage[activeProcessOld.ProcessName] = Tuple.Create(unixTimeMilliseconds, 0);

            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(printData);
            myTimer.Interval = 3 * 1000;
            myTimer.Enabled = true;

            while (true)
            {
                var activeProcessNew = collector.GetProcessIdAndName();
                if(activeProcessNew.Id != activeProcessOld.Id)
                {
                    applicationUsage = collector.UpdateApplicationUsage(activeProcessOld, activeProcessNew, applicationUsage);
                    activeProcessOld = activeProcessNew;
                }
                // if (applicationUsage.Count > 3) break;

            }
            
        }

        private static void printData(object state, ElapsedEventArgs e)
        {
            foreach (var application in applicationUsage)
            {
                var ms = application.Value.Item2;
                Console.WriteLine(application.Key + " " + TimeSpan.FromMilliseconds(ms).ToString());
            }
        }
    }
}
