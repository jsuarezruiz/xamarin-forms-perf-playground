using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using FastRenderersPerformance.Droid.Services;

namespace FastRenderersPerformance.Droid
{
    [Activity(
        Label = "FastRenderersPerformance",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public MainActivity()
        {
            ProfilerService.RegisterInternalEvent("MainActivity Constructor");
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ProfilerService.RegisterInternalEvent("MainActivity OnCreate Init");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Forms.SetFlags("FastRenderers_Experimental");
            Forms.Init(this, savedInstanceState);
            DependencyService.Register<ProfilerService>();
            LoadApplication(new App());

            ProfilerService.RegisterInternalEvent("MainActivity OnCreate End");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}