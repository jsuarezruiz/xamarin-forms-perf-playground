using Android.App;
using Android.Content.PM;
using Android.OS;
using CollectionViewPerformance.Droid.Services;
using Xamarin.Forms;

namespace CollectionViewPerformance.Droid
{
    [Activity(
        Label = "CollectionViewPerformance", 
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
            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            DependencyService.Register<ProfilerService>();
            LoadApplication(new App());
        }
    }
}