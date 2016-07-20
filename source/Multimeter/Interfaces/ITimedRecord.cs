using System;

namespace Multimeter
{
    /// <summary>
    /// For apps to feed the metric factory with metadata. not a metric
    /// </summary>
    public interface ITimedRecord
    {
        string Name { get; set; }

        TimeSpan Elapsed { get; set; }

        bool IsException { get; set; }
    }
}