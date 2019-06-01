using VisualPerformance.Models;
using VisualPerformance.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VisualPerformance.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _timing;

        private readonly IProfilerService _profilerService;

        public MainViewModel(IProfilerService profilerService)
        {
            _profilerService = profilerService;
        }

        public string Timing
        {
            get => _timing;
            set
            {
                _timing = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadDataAsync()
        {
            var timings = await _profilerService.GetTimingsSinceStartup();

            Timing = timings
                .Select(t => new Timing(t.Key, t.Value))
                .FirstOrDefault().ElapsedTime;
        }
    }
}