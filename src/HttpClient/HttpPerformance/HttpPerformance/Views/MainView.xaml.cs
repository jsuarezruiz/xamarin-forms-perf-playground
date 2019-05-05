using HttpPerformance.ViewModels;
using Xamarin.Forms;

namespace HttpPerformance.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}