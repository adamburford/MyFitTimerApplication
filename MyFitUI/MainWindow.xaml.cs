using System.Windows;
using System.Diagnostics;
using System.Timers;
using MyFitTimerAPI;
using MyFitTimerData;
using MyFitTimerData.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System;

namespace MyFitUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private StopWatchTracker watch;
		private Timer timer;
		private readonly TimerContext _context = new TimerContext();
		private CollectionViewSource runsViewSource;

		public MainWindow()
		{
			InitializeComponent();
			watch = new StopWatchTracker();
			timer = new Timer(1);
			timer.Elapsed += DisplayTimeEvent;
			runsViewSource = (CollectionViewSource)FindResource(nameof(runsViewSource));

		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			_context.Database.EnsureCreated();
			_context.Runs.Load();
			runsViewSource.Source = _context.Runs.Local.ToObservableCollection();
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			timer.Enabled = false;
			timer.Dispose();
		}

		public void DisplayTimeEvent(object sender, ElapsedEventArgs e)
		{
			Application.Current.Dispatcher.Invoke(UpdateTimer);
        }

		public void UpdateTimer()
		{
			if (timer.Enabled)
				tbTimer.Text = watch.Elapsed.ToString(@"mm\:ss\.ff");
		}

        private void startTimer(object sender, RoutedEventArgs e)
        {
			if (!watch.IsRunning)
			{
				watch.Start();
				timer.Enabled = true;
			}
        }

        private void stopTimer(object sender, RoutedEventArgs e)
        {
            if (watch.IsRunning)
            {
				timer.Enabled = false;               
				watch.Stop();


                tbTimer.Text = watch.LastRun.ToString(@"mm\:ss\.ff");

				_context.Runs.Add(new Run(watch.LastRun));

				_context.SaveChanges();

				results.SelectedIndex = results.Items.Count - 1;
				results.ScrollIntoView(results.SelectedItem);
			}
        }
	}
}
