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

namespace auto_anzeige
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gauge_Handler gauge;
        public MainWindow()
        {
            InitializeComponent();
            gauge = new Gauge_Handler();
            gauge.RaiseTimeEvent += HandleClockEvent;
        }

        public void printTime(string time)
        {
            timeLabel.Content = time;
        }

        void HandleClockEvent(object sender, CustomEventArgs e)
        {
            timeLabel.Content = e.Message;
        }

    }
}
