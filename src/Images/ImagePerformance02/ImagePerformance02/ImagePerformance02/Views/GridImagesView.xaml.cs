using FFImageLoading.Forms;
using ImagePerformance02.Helpers;
using ImagePerformance02.Views.Base;
using Xamarin.Forms;

namespace ImagePerformance02.Views
{
    public partial class GridImagesView : ProfilerPage
    {
        public GridImagesView()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition { Height = 50 });

                for (int j = 0; j < 4; j++)
                {
                    var image = new CachedImage
                    {
                        Aspect = Aspect.AspectFill,
                        Source = Images.RandomSource(),
                    };
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, j);
                    _grid.Children.Add(image);
                }
            }
        }
    }
}