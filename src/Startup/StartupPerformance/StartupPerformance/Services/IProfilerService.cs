﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupPerformance.Services
{
    public interface IProfilerService
    {
        void RegisterEvent(string eventName);
        Task<Dictionary<string, TimeSpan?>> GetTimingsSinceStartup();
        DateTime? GetStartupTime();
    }
}