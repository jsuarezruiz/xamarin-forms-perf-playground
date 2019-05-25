using FastRenderersPerformance.Services;
using FastRenderersPerformance.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FastRenderersPerformance
{
    public partial class App : Application
    {
        public static IProfilerService ProfilerService { get; set; } = DependencyService.Get<IProfilerService>();

        public App()
        {
            ProfilerService.RegisterEvent("Xamarin.Forms App Constructor Init");
            InitializeComponent();
            MainPage = new MainView();
            ProfilerService.RegisterEvent("Xamarin.Forms App Constructor End");
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
