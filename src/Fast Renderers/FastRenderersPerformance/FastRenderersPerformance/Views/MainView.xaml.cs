using FastRenderersPerformance.Services;
using FastRenderersPerformance.ViewModels;
using Xamarin.Forms;

namespace FastRenderersPerformance.Views
{
    public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
            BindingContext = new MainViewModel(DependencyService.Get<IProfilerService>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as MainViewModel).LoadDataAsync();
            App.ProfilerService.RegisterEvent("Xamarin.Forms MainView OnAppearing");
        }
    }
}