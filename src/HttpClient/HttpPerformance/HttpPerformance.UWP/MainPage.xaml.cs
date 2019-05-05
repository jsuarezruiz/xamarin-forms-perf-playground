namespace HttpPerformance.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new HttpPerformance.App());
        }
    }
}
