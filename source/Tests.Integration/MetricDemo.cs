using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Multimeter;

namespace Tests.Integration
{
    class MetricDemo
    {
        public static void Go()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            // Metric publishes on dispose
            using (new SelfPublishingTimedMetric("Multimeter", "self-publishing-test"))
            {
                Thread.Sleep(random.Next(200, 500));
            }

            // Direct publish
            MultimeterService.Instance.Publish("Multimeter", "direct-publish", TimeSpan.FromMilliseconds(random.Next(300, 600)));

            // Custom metric
            var metric = new MyCustomMetric();
            MultimeterService.Instance.Publish(metric);
        }
    }
}
