using Android.App;
using Android.Content.PM;
using Android.OS;
using VisualPerformance.Droid.Services;
using Xamarin.Forms;

namespace VisualPerformance.Droid
{
    [Activity(
        Label = "VisualPerformance", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            DependencyService.Register<ProfilerService>();
            LoadApplication(new App());
        }
    }
}