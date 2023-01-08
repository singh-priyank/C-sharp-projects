using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Windows.UI.Notifications;

namespace ReminderApp
{
    public class ToasterNotification : INotifier
    {
        public void ShowNotification()
        {
            Message message = new Message();
            
            while (true)
            {
                var notification = new ToastContentBuilder();
                notification.AddArgument("action", "viewConversation");
                notification.AddArgument("conversationId", 9813);
                notification.AddText("Hey!!! Its time to take a break");
                notification.AddText(message.GetMessage());
                notification.Show();

                Thread.Sleep(10*1000);
                //if (notification != null) Marshal.Release(notification);
            }
        }
    }
}
