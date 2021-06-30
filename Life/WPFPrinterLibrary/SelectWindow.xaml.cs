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
using System.Windows.Shapes;

namespace WPFPrinterLibrary
{
    /// <summary>
    /// Interaction logic for SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        private String _answer;

        public SelectWindow(List<string> options, String answer)
        {
            InitializeComponent();
            _answer = answer;
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
            _answer = (sender as Button).Tag.ToString();
            Close();
        }
    }
}
