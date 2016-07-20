using System;

namespace Multimeter
{
    public class SelfPublishingTimedMetric : SelfTimingTimedMetric, IDisposable
    {
        public SelfPublishingTimedMetric(string type, string name) : base(type, name)
        {
        }

        public virtual void Dispose()
        {
            Stop();
            MultimeterService.Instance.Publish(this);
        }
    }
}