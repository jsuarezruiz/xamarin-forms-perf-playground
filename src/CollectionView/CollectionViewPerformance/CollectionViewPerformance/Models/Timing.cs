using CollectionViewPerformance.Extensions;
using System;

namespace CollectionViewPerformance.Models
{
    public class Timing
    {
        public Timing(string eventName, TimeSpan? elapsedTime)
        {
            EventName = eventName;
            ElapsedTime = elapsedTime?.ToCanonicString();
        }

        public string EventName { get; }
        public string ElapsedTime { get; }
    }
}