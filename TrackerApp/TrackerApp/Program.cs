using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.IO;
using static TrackerApp.Utilities;

namespace TrackerApp
{
    class Program
    {
        public static Dictionary<string, Tuple<long, int>> applicationUsage = new Dictionary<string, Tuple<long, int>>();
        
        static void Main(string[] args)
        {
            Collector collector = new Collector();
            var activeProcessOld = collector.GetCurrentProcess();
            applicationUsage[activeProcessOld.ProcessName] = Tuple.Create(timeNowMilliseconds(), 0);

            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(printDataToFile);
            myTimer.Interval = 5 * 1000;
            myTimer.Enabled = true;

            while (true)
            {
                var activeProcessNew = collector.GetCurrentProcess();
                if(activeProcessNew.Id != activeProcessOld.Id)
                {
                    applicationUsage = collector.UpdateApplicationUsage(activeProcessOld, activeProcessNew, applicationUsage);
                    activeProcessOld = activeProcessNew;
                }
            }
        }

        private static void printDataToFile(object state, ElapsedEventArgs e)
        {
            string fullPath = "C:\\Users\\PriyankSingh\\C-sharp-projects\\TrackerApp\\output.txt";

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                foreach (var application in applicationUsage)
                {
                    var usageTime = application.Value.Item2;

                    writer.WriteLine(application.Key + " " + TimeSpan.FromMilliseconds(usageTime).ToString());
                }
            }
        }
    }
}
