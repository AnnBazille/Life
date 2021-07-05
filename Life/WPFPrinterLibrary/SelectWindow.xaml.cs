using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFPrinterLibrary
{
    /// <summary>
    /// Interaction logic for SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        public string Answer { get; set; }
        private string _answer;

        public SelectWindow(List<string> options)
        {
            InitializeComponent();
            for(int i = 0; i < options.Count; i++)
            {
                Button button = new Button();
                button.Tag = (i + 1).ToString();
                button.Content = options[i];
                button.Margin = new Thickness(10);
                button.Padding = new Thickness(5);
                button.Background = new SolidColorBrush(Colors.White);
                button.BorderBrush = new SolidColorBrush(Colors.Black);
                button.Click += btnOption_Click;
                StackPanelMain.Children.Add(button);
            }
        }

        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            Answer = (sender as Button).Tag.ToString();
            Close();
        }
    }
}
