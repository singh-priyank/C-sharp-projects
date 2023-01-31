using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for AddQuotes.xaml
    /// </summary>
    public partial class AddQuotes : Window
    {
        string quotes;
        public AddQuotes()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            quotes = Quotes.Text;
            this.Close();
        }
    }
}
