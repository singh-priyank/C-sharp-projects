using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Notifications;

namespace ReminderApp
{
    public class ToasterNotification : INotifier
    {
        public bool ShowNotification()
        {
            var notification = new ToastContentBuilder();
            notification.AddArgument("action", "viewConversation");
            notification.AddArgument("conversationId", 9813);
            notification.AddText("Andrew sent you a picture");
            notification.AddText("Check this out, The Enchantments in Washington!");
            notification.Show();
            return true;
        }
/*
        static void Main(string[] args)
        {
            
        }*/
    }
}
