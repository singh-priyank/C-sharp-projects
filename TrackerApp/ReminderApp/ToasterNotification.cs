using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace ReminderApp
{
    public class ToasterNotification : INotifier
    {
        public void ShowNotification()
        {
            Message message = new Message();
            
            while (true)
            {
                Thread.Sleep(4 * 1000);
            }
        }
    }
}
