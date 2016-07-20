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
            return string.Format("{0}\\{1}:\t{2}", Type, Name, Timer);
        }
    }
}