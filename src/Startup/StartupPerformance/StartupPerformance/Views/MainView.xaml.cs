using StartupPerformance.Services;
using StartupPerformance.ViewModels;
using Xamarin.Forms;

namespace StartupPerformance.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(DependencyService.Get<IProfilerService>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as MainViewModel).LoadDataAsync();
        }
    }
}