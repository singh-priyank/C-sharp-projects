using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.IO;
using static TrackerApp.Utilities;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.IdentityModel.Protocols;
using ReminderApp;

namespace TrackerApp
{
    class Program
    {
        public static Dictionary<string, Tuple<long, int>> applicationUsage = new Dictionary<string, Tuple<long, int>>();
        
        static void Main(string[] args)
        {
            Collector collector = new Collector();
            ToasterNotification toasterNotifications = new ToasterNotification();
            toasterNotifications.ShowNotification();
            var activeProcessOld = collector.GetCurrentProcess();
            applicationUsage[activeProcessOld.ProcessName] = Tuple.Create(timeNowMilliseconds(), 0);

            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(printDataToFile);
            myTimer.Interval = 3 * 1000;
            myTimer.Enabled = true;
            var sAttr = ConfigurationManager.AppSettings.Get("EnableReminderApp");
            Console.WriteLine(sAttr);
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
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\usage.txt";
            using (StreamWriter writer = new StreamWriter(desktopPath))
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

// by creating a new thread
// value out in a given time
// Make sepearate modules and it does specific job 
