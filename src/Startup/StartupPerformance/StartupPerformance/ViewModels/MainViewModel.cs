using StartupPerformance.Models;
using StartupPerformance.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StartupPerformance.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _startupTime;
        private List<Timing> _timings;

        private readonly IProfilerService _profilerService;

        public MainViewModel(IProfilerService profilerService)
        {
            _profilerService = profilerService;
        }

        public string StartupTime
        {
            get => _startupTime;
            set
            {
                _startupTime = value;
                OnPropertyChanged();
            }
        }

        public List<Timing> Timings
        {
            get => _timings;
            set
            {
                _timings = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadDataAsync()
        {
            StartupTime = _profilerService.GetStartupTime()?.ToLocalTime().ToString() ?? "-";
            var timings = await _profilerService.GetTimingsSinceStartup();

            Timings = timings
                .Select(t => new Timing(t.Key, t.Value))
                .ToList();
        }
    }
}