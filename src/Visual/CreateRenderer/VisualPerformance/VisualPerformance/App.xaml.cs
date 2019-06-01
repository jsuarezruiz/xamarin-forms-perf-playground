using VisualPerformance.Services;
using VisualPerformance.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VisualPerformance
{
    public partial class App : Application
    {
        public static IProfilerService ProfilerService { get; set; } = DependencyService.Get<IProfilerService>();

        public App()
        {
            InitializeComponent();

            MainPage = new MainView();
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