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
using LifeLibrary;

namespace WPFPrinterLibrary
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private TimeController<GUIPrinter> _timeController = new TimeController<GUIPrinter>();
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnAddField233_Click(object sender, RoutedEventArgs e)
        {
            _timeController.GameControllers.Add(new GameController<GUIPrinter>(new Cell233<GUIPrinter>()));
        }

        private void btnAddField344_Click(object sender, RoutedEventArgs e)
        {
            _timeController.GameControllers.Add(new GameController<GUIPrinter>(new Cell344<GUIPrinter>()));
        }

        private void btnAddField234_Click(object sender, RoutedEventArgs e)
        {
            _timeController.GameControllers.Add(new GameController<GUIPrinter>(new Cell234<GUIPrinter>()));
        }

        private void btnGeneration_Click(object sender, RoutedEventArgs e)
        {
            ulong generation;
            if(ulong.TryParse(tbGeneration.Text, out generation))
            {
                _timeController.Generation = generation;
            }
        }

        private void btnSleepTime_Click(object sender, RoutedEventArgs e)
        {
            ushort time;
            if(ushort.TryParse(tbSleepTime.Text, out time))
            {
                _timeController.SleepMilliseconds = time;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if(_timeController.IsPaused)
            {
                btnPause.Content = "Pause";
                _timeController.IsPaused = false;
            }
            else
            {
                btnPause.Content = "Resume";
                _timeController.IsPaused = true;
            }
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            btnAddField233.IsEnabled = false;
            btnAddField234.IsEnabled = false;
            btnAddField344.IsEnabled = false;
            tbGeneration.IsReadOnly = true;
            btnGeneration.IsEnabled = false;
            tbSleepTime.IsReadOnly = true;
            btnSleepTime.IsEnabled = false;
            btnRun.IsEnabled = false;
            _timeController.SyncWindow = this;
            _timeController.Run();
        }
    }
}
