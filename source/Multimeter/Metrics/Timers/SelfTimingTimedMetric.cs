using System;
using System.Diagnostics;

namespace Multimeter
{
    public class SelfTimingTimedMetric : TimedMetricCore
    {
        private readonly string _type;
        public readonly Stopwatch _stopwatch;

        public override string Type { get { return _type; } }

        /// <summary>
        /// Expose for mid stream measurements. bit icky.
        /// </summary>
        public TimeSpan Elapsed
        {
            get { return _stopwatch.Elapsed; }
        }

        public SelfTimingTimedMetric(string type, string name)
        {
            MetricFactory.Instance.AssignEnvironmentDefaults(this);

            _type = type;
            Name = name;
            _stopwatch = Stopwatch.StartNew();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            Timer.Elapsed = _stopwatch.Elapsed;
        }
    }
}