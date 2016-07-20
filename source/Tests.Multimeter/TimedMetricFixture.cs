using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimeter;
using NUnit.Framework;

namespace Tests.Multimeter
{
    public class TimedMetricFixture : Fixture
    {
        [Test]
        public void TheToString()
        {
            var metric = new SelfTimingTimedMetric("myType","myName");
            metric.Timer.Elapsed = TimeSpan.FromMilliseconds(123);
            var s = metric.ToString();
            Assert.AreEqual("myType\\myName:\t0123 ms", s);
        }

        [Test]
        public void MidMeasureReading()
        {
           var metric = new SelfTimingTimedMetric("myType", "myName");
           Assert.Greater(metric.Elapsed.TotalMilliseconds, 0);
        }
    }
}
