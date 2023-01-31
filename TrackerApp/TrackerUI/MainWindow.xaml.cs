using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_quotes_Click(object sender, RoutedEventArgs e)
        {
            AddQuotes quotes = new AddQuotes();
            quotes.Show();
        }

        private void Update_Notification_Click(object sender, RoutedEventArgs e)
        {
            string message;
            if (Yes_Button.IsChecked == true)
            {
                Yes_Button.Foreground = Brushes.Blue;
                No_Button.Foreground = Brushes.Black;
                message = "You will start getting notification on the interval of 1hr.\n" +
                    "Add reminder quotes you want to see in the notification";
            }
            else if (No_Button.IsChecked == true)
            {
                No_Button.Foreground = Brushes.Blue;
                Yes_Button.Foreground = Brushes.Black;
                message = "Notification disabled.";
            }
            else
            {
                message = "No option is selected. Default value is NO";
            }
            MessageBox.Show(message);
        }
    }
}
