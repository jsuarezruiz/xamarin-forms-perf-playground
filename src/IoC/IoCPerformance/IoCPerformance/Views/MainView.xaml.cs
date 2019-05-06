using IoCPerformance.ViewModels;
using Xamarin.Forms;

namespace IoCPerformance.Views
{
    public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
            BindingContext = new MainViewModel();
		}
	}
}