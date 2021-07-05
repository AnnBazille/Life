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
        public string Answer { get; set; }

        public InputWindow(string message)
        {
            InitializeComponent();
            lbMessage.Text = message;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Answer = txInput.Text;
            Close();
        }
    }
}
