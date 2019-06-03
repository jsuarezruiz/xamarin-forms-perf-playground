using CollectionViewPerformance.Services;
using CollectionViewPerformance.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CollectionViewPerformance
{
    public partial class App : Application
    {
        public static IProfilerService ProfilerService { get; set; } = DependencyService.Get<IProfilerService>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CollectionPerfView());
            //MainPage = new NavigationPage(new ListViewPerfView());
        }

        protected override void OnStart()
        {
            ProfilerService.RegisterEvent("Xamarin.Forms App OnStart");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
