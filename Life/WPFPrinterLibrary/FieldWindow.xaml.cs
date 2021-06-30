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
    /// Interaction logic for FieldWindow.xaml
    /// </summary>
    public partial class FieldWindow : Window
    {
        private List<Button> _buttons = new List<Button>();
        public FieldWindow(int width, int height)
        {
            InitializeComponent();
            for(int i = 0; i < height; i++)
            {
                GridField.RowDefinitions.Add(new RowDefinition());
                for(int a = 0; a < width; a++)
                {
                    GridField.ColumnDefinitions.Add(new ColumnDefinition());
                    Button button = new Button();
                    button.Background = new SolidColorBrush(Colors.White);
                    button.BorderBrush = new SolidColorBrush(Colors.Black);
                    button.Width = 20;
                    button.Height = 20;
                    button.Click += btnOption_Click;
                    button.Tag = false;
                    _buttons.Add(button);
                    GridField.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, a);
                }
            }
        }

        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            if((bool)(sender as Button).Tag)
            {
                (sender as Button).Tag = false;
                (sender as Button).Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (sender as Button).Tag = true;
                (sender as Button).Background = new SolidColorBrush(Colors.Red);
            }
        }

        public void LockCells()
        {
            for(int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].Click -= btnOption_Click;
            }
        }
    }
}
