using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loggly;
using Multimeter.Config;
using Newtonsoft.Json;

namespace Multimeter.Publisher.Loggly
{
    public class LogglyPublisher : IPublisher
    {
        internal ILogglyClient LogglyClient { get; set; }

        public LogglyPublisher()
        {
            LogglyClient = new LogglyClient();
        }

        public void Publish(IEnumerable<IMetric> metrics)
        {
            foreach (var metric in metrics)
            {
                Publish(metric);
            }
        }

        public void Publish(IMetric metric)
        {
            var logglyEvent = new LogglyEvent();
            logglyEvent.Timestamp = metric.Timestamp;
            logglyEvent.Data.Add("metric", metric);
            logglyEvent.Data.Add("isMetric", true);
            logglyEvent.Data.Add("type", metric.GetType().Name);
            LogglyClient.Log(logglyEvent);
        }
    }
}
