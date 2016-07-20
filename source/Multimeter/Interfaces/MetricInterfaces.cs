using System;

namespace Multimeter
{
    public interface IMetric
    {
        DateTimeOffset Timestamp { get; set; }
        string Type { get; }
        string Name { get; set; }
        //Solution Solution { get; set; }
        //Host Host { get; set; }
    }

    public interface ITimedMetric : IMetric
    {
        TimerProperties Timer { get; }
    }
    
    public interface IGaugeMetric : IMetric
    {
        GaugeProperties Gauge { get; }
    }

    public interface ICountMetric : IMetric
    {
        CountProperties Counter { get; }
    }

    public class CountProperties
    {
        public Decimal Value { get; set; }
    }
}