namespace Multimeter
{
    /// <summary>
    /// Consumers can provide their own timed metric
    /// </summary>
    public abstract class TimedMetricCore : Metric, ITimedMetric
    {
        public TimerProperties Timer { get; private set; }
        
        protected TimedMetricCore()
        {
            Timer = new TimerProperties();
        }

        public override string ToString()
        {
            return $"{Type}\\{Name}:\t{Timer}";
        }
    }
}