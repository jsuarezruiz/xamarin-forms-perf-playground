using System;
using System.Timers;

namespace ImagePerformance01.Helpers
{
    public class MemoryProfiler : IDisposable
    {
        public static MemoryProfiler Instance;

        readonly string _name;
        readonly Timer timer = new Timer();
        long _peakMemory;
        long _lowestMemory;

        public MemoryProfiler(string name)
        {
            _name = name;
            timer.Interval = 3000;
            timer.Elapsed += OnElapsed;
            timer.Start();
        }

        void OnElapsed(object sender, ElapsedEventArgs e)
        {
            var usedMemory = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            if (usedMemory > _peakMemory)
                _peakMemory = usedMemory;

            if (_lowestMemory == 0)
                _lowestMemory = usedMemory;

            if (usedMemory < _lowestMemory)
                _lowestMemory = usedMemory;

            var usedMemoryInMB = usedMemory / (1024 * 1024);
            Console.WriteLine(
                "ImagePerformance01|{0} Memory, Used: {1} ({2}MB), Peak: {3}, Lowest: {4}, MaxConsumed: {5}",
                _name,
                usedMemory,
                usedMemoryInMB,
                _peakMemory,
                _lowestMemory,
                _peakMemory - _lowestMemory);
        }

        public void Dispose()
        {
            timer.Stop();
        }
    }
}