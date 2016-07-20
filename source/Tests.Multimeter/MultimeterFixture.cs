using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimeter;
using NUnit.Framework;

namespace Tests.Multimeter
{
    public class MultimeterFixture : Fixture
    {
        [Test]
        public void NoConfig()
        {
            var metric = new GaugeMetric("foo", "bar");
            MultimeterService.Instance.Publish(metric);
        }
    }
}
