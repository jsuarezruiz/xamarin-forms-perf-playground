using Java.IO;
using Java.Lang;
using System;
using System.Globalization;

namespace VisualPerformance.Droid.Helpers
{
    // Based on: https://github.com/toomasz/XamarinAppStartupTime
    // By Tomasz Ścisłowicz
    public class ProfilerTimeHelper
    {
        const string LogcatTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        private static DateTime? StartupTime;
        private static bool _attemptedToGetStartupTime;

        public static DateTime? GetAppStartupTime()
        {
            if (_attemptedToGetStartupTime)
            {
                return StartupTime;
            }
            if (!StartupTime.HasValue)
            {
                StartupTime = GetStartupTimeFromLogcat();
                _attemptedToGetStartupTime = true;
            }
            return StartupTime;
        }

        private static DateTime? GetStartupTimeFromLogcat()
        {
            var pid = Android.OS.Process.MyPid();

            var process = new ProcessBuilder().
                RedirectErrorStream(true).
                Command("/system/bin/logcat", $"--pid={pid}", "-m", "1", "-v", "year").Start();

            using (var bufferedReader = new BufferedReader(new InputStreamReader(process.InputStream)))
            {
                string line = null;
                while ((line = bufferedReader.ReadLine()) != null)
                {
                    if (ParseLogDateTime(line, out DateTime date))
                    {
                        return date;
                    }
                }
            }

            return null;
        }

        private static bool ParseLogDateTime(string logLine, out DateTime dateTime)
        {
            if (logLine.Length < LogcatTimeFormat.Length)
            {
                dateTime = new DateTime();
                return false;
            }
            var timeStr = logLine.Substring(0, LogcatTimeFormat.Length);

            return DateTime.TryParseExact(timeStr, LogcatTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime);
        }
    }
}