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
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        private String _answer;

        public InputWindow(string message, String answer)
        {
            InitializeComponent();
            _answer = answer;
            lbMessage.Text = message;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            _answer = txInput.Text;
            Close();
        }
    }
}
