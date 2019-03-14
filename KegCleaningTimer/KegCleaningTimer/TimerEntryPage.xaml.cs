using System;
using System.IO;
using Xamarin.Forms;
using KegCleaningTimer.Models;

namespace KegCleaningTimer
{
	
	public partial class TimerEntryPage : ContentPage
	{
		public TimerEntryPage ()
		{
			InitializeComponent ();
		}

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var timer = (Timer)BindingContext;

            if (string.IsNullOrWhiteSpace(timer.FileName))
            {
                //Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.timers.txt");
                File.WriteAllText(filename, timer.Name);
            }
            else
            {
                //Update
                File.WriteAllText(timer.FileName, timer.Description);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var timer = (Timer)BindingContext;

            if (File.Exists(timer.FileName))
            {
                File.Delete(timer.FileName);
            }

            await Navigation.PopAsync();
        }


	}
}