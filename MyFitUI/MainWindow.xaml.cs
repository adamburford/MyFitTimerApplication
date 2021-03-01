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
using System.Diagnostics;
using System.Timers;

namespace MyFitUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch watch;
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            watch = new Stopwatch();
            timer = new Timer(100);
            timer.Elapsed += DisplayTimeEvent;
        }       

        private void startTimer(object sender, RoutedEventArgs e)
        {                      
            watch.Start();
            timer.Enabled = true;
        }

        public void DisplayTimeEvent(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => tbTimer.Text = (watch.ElapsedMilliseconds / 1000.0).ToString("0.00"));
        }

        private void stopTimer(object sender, RoutedEventArgs e)
        {
            if (watch.IsRunning)
            {
                watch.Stop();
                timer.Enabled = false;
                var elapsedTime = (watch.ElapsedMilliseconds / 1000.0).ToString("0.00");
                tbTimer.Text = elapsedTime;
               
                resultsLB.Items.Add(elapsedTime);
                watch.Reset();
            }
        }
    }
}
