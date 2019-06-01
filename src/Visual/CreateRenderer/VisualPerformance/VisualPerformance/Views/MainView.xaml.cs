using System;
using System.Diagnostics;
using VisualPerformance.Services;
using VisualPerformance.ViewModels;
using VisualPerformance.Views.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace VisualPerformance.Views
{
    public partial class MainView : ProfilerPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            long count = 0;
            foreach (var datum in Profile.Data)
            {
                count += datum.Ticks;
                long ms = datum.Ticks / TimeSpan.TicksPerMillisecond;
                Debug.WriteLine($"{datum.Name}-{datum.Id}: {ms} ms {count}");
            }

            Navigation.PushModalAsync(new ContentPage().LoadProfile());
        }

        public MainView ()
		{
			InitializeComponent ();
            BindingContext = new MainViewModel(DependencyService.Get<IProfilerService>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as MainViewModel).LoadDataAsync();
        }
    }
}