using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static TrackerApp.Utilities;

namespace TrackerApp
{
    public class Collector
    {
        // Import the necessary Win32 API functions
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        public Dictionary<string, Tuple<long, int>> UpdateApplicationUsage(Process processOld, Process processNew, Dictionary<string, Tuple<long, int>> applicationUsage)
        {
            var processNameOld = processOld.ProcessName;
            var processNameNew = processNew.ProcessName;


            long timeNow = timeNowMilliseconds();

            // Add new process to the dictonary 
            if (!applicationUsage.ContainsKey(processNameNew))
            {
                applicationUsage[processNameNew] = Tuple.Create(timeNow, 0);
            }
            else
            {
                applicationUsage[processNameNew] = Tuple.Create(timeNow, applicationUsage[processNameNew].Item2);
            }
            // Update the old process usage time 
            int usedTime = applicationUsage[processNameOld].Item2 + (int)(timeNow - applicationUsage[processNameOld].Item1);
            applicationUsage[processNameOld] = Tuple.Create(timeNow, usedTime);

            return applicationUsage;
        }

        public Process GetCurrentProcess()
        {
            int focusedProcessId;
            GetWindowThreadProcessId(GetForegroundWindow(), out focusedProcessId);
            return Process.GetProcessById(focusedProcessId);
        }
    }
}
