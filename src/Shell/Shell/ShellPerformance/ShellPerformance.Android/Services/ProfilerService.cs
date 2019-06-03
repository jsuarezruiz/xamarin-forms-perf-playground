using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShellPerformance.Droid.Helpers;
using ShellPerformance.Models;

namespace ShellPerformance.Droid.Services
{
    public class ProfilerService : IProfilerService
    {
        private static Dictionary<string, DateTime?> _eventTimingsSinceStartup = new Dictionary<string, DateTime?>();

        public static void RegisterInternalEvent(string eventName)
        {
            if (_eventTimingsSinceStartup.ContainsKey(eventName))
            {
                return;
            }

            _eventTimingsSinceStartup.Add(eventName, DateTime.Now);
        }

        public void RegisterEvent(string eventName)
        {
            RegisterInternalEvent(eventName);
        }

        public async Task<Dictionary<string, TimeSpan?>> GetTimingsSinceStartup()
        {
            return await Task.Factory.StartNew(() =>
            {
                var timings = new Dictionary<string, TimeSpan?>();
                var startupTime = ProfilerTimeHelper.GetAppStartupTime();

                foreach (var eventInfo in _eventTimingsSinceStartup)
                {
                    timings.Add(eventInfo.Key, eventInfo.Value - startupTime);
                }
                return timings;
            });
        }

        public DateTime? GetStartupTime()
        {
            return ProfilerTimeHelper.GetAppStartupTime();
        }
    }
}