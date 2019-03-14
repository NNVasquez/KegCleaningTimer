using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using KegCleaningTimer.Models;

namespace KegCleaningTimer
{
	
	public partial class TimersPage : ContentPage
	{
		public TimersPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var timers = new List<Timer>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.timers.txt");
            foreach (var filename in files)
            {
                timers.Add(new Timer
                {
                    FileName = filename,
                    Description = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            listView.ItemsSource = timers
                .OrderBy(t => t.Date)
                .ToList();
        }

        async void OnTimerAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerEntryPage
            {
                BindingContext = new Timer()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TimerEntryPage
                {
                    BindingContext = e.SelectedItem as Timer
                });
            }
        }
    }
}