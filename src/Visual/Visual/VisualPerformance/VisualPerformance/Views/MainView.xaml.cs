using VisualPerformance.Services;
using VisualPerformance.ViewModels;
using VisualPerformance.Views.Base;
using Xamarin.Forms;

namespace VisualPerformance.Views
{
    public partial class MainView : ProfilerPage
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
        }
    }
}