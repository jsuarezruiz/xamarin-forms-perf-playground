using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoShellPerformance.Services;

namespace NoShellPerformance.iOS.Services
{
    public class ProfilerService : IProfilerService
    {
        public DateTime? GetStartupTime()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, TimeSpan?>> GetTimingsSinceStartup()
        {
            throw new NotImplementedException();
        }

        public void RegisterEvent(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}