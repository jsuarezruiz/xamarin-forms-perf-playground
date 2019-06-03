using CollectionViewPerformance.UWP.Services;
using Xamarin.Forms;

namespace CollectionViewPerformance.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            DependencyService.Register<ProfilerService>();
            LoadApplication(new CollectionViewPerformance.App());
        }
    }
}
