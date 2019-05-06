namespace IoCPerformance.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new IoCPerformance.App());
        }
    }
}
