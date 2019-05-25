using System;

namespace StartupPerformance.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToCanonicString(this TimeSpan? timeSpan)
        {
            if (!timeSpan.HasValue)
            {
                return "-";
            }
            return timeSpan.Value.ToCanonicString();
        }

        public static string ToCanonicString(this TimeSpan timeSpan, int secondsToSkipMsPart = 40)
        {
            int totalDays = (int)timeSpan.TotalDays;

            if (totalDays > 0)
            {
                return $"{totalDays}d{timeSpan.Hours}h{timeSpan.Minutes}m{timeSpan.Seconds}s";
            }

            if (timeSpan.Hours > 0)
            {
                return $"{timeSpan.Hours}h{timeSpan.Minutes}m{timeSpan.Seconds}s";
            }

            if (timeSpan.Minutes > 0)
            {
                return $"{timeSpan.Minutes}m{timeSpan.Seconds}s";
            }

            if (timeSpan.Seconds < 1)
            {
                return $"{timeSpan.Milliseconds}ms";
            }

            if (timeSpan.Seconds < secondsToSkipMsPart)
            {
                return $"{timeSpan.Seconds}s{timeSpan.Milliseconds}ms";
            }

            return $"{timeSpan.Seconds}s";
        }
    }
}