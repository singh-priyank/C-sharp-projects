using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReminderApp
{
    public class Message
    {
        private static List<string> messageList = new List<string>();
        private static readonly string defaultMessage = "Lets go on a walk for 5min.";
        public string GetMessage()
        {
            LoadMessagesFromFile();
            if (messageList.Count == 0) return defaultMessage; 
            Random random = new Random();
            int index = random.Next(messageList.Count);
            return messageList[index];
        }

        private static void LoadMessagesFromFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\messages.txt";

            string[] messages = System.IO.File.ReadAllLines(desktopPath);

            foreach (string message in messages)
            {
                messageList.Add(message);
            }
        }
    }
}
