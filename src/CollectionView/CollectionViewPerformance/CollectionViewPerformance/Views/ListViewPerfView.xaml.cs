using CollectionViewPerformance.Services;
using CollectionViewPerformance.ViewModels;
using CollectionViewPerformance.Views.Base;
using Xamarin.Forms;

namespace CollectionViewPerformance.Views
{
    public partial class ListViewPerfView : ProfilerPage
    {
		public ListViewPerfView ()
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