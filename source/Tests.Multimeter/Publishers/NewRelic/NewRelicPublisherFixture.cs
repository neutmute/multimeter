using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimeter;
using Multimeter.Publisher.NewRelic;
using NUnit.Framework;

namespace Tests.Multimeter.Publishers.NewRelic
{
    public class NewRelicPublisherFixture : Fixture
    {
        [Test]
        public void GetPath()
        {
            var metric = new GaugeMetric("my type", "my name");
            var path = NewRelicPublisher.GetMetricPath(metric);
            Assert.AreEqual(path, "my type/my name");
        }
    }
}
