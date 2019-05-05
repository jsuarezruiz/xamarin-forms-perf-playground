using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMLCPerformance.ViewModels;

namespace XAMLCPerformance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfileView : ContentPage
	{
		public UserProfileView ()
		{
            Stopwatch watch = Stopwatch.StartNew();
			InitializeComponent ();
            BindingContext = new UserProfileViewModel();
            watch.Stop();
            Debug.WriteLine("Initialize");
            Debug.WriteLine($"Elapsed {watch.ElapsedMilliseconds} ms");
        }
	}
}