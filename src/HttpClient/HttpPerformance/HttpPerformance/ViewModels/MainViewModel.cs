using HttpPerformance.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HttpPerformance.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<string> _results;

        public MainViewModel()
        {
            Results = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                OnPropertyChanged();
            }
        }

        public ICommand InitTestCommand => new Command(async () => await ExecuteTest());

        private async Task ExecuteTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < AppSettings.NumberOfRequests; i++)
            {
                await NonReuseHttpClientService.Instance.GetPhotosAsync();
            }

            sw.Stop();
            TimeSpan nonReuseHttpTimeSpan = sw.Elapsed;
            Results.Add($"NonReuseHttpClientService: {nonReuseHttpTimeSpan.TotalMilliseconds} ms");

            sw.Restart();

            for (int i = 0; i < AppSettings.NumberOfRequests; i++)
            {
                await ReuseHttpClientService.Instance.GetPhotosAsync();
            }

            sw.Stop();
            TimeSpan reuseHttpTimeSpan = sw.Elapsed;
            Results.Add($"ReuseHttpClientService: {reuseHttpTimeSpan.TotalMilliseconds} ms");

            sw.Restart();

            for (int i = 0; i < AppSettings.NumberOfRequests; i++)
            {
                await ReuseStreamHttpClientService.Instance.GetPhotosAsync();
            }

            sw.Stop();
            TimeSpan reuseStreamHttpTimeSpan = sw.Elapsed;
            Results.Add($"ReuseStreamHttpClientService: {reuseStreamHttpTimeSpan.TotalMilliseconds} ms");
        }
    }
}