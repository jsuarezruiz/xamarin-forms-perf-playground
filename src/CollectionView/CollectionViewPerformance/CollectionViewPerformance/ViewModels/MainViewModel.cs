using CollectionViewPerformance.Models;
using CollectionViewPerformance.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollectionViewPerformance.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _timing;
        private List<Monkey> _monkeys;

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

        public List<Monkey> Monkeys
        {
            get { return _monkeys; }
            set
            {
                _monkeys = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadDataAsync()
        {
            var data = await _profilerService.GetTimingsSinceStartup();
            var timing = data
                .Select(t => new Timing(t.Key, t.Value))       
                .First();
            Timing = timing.ElapsedTime;
            Monkeys = MonkeyService.GetMonkeys();
        }
    }
}