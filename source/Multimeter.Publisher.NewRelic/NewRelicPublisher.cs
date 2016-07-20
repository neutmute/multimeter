using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewRelic.Api.Agent;
using NewRelicApi = NewRelic.Api.Agent.NewRelic;

namespace Multimeter.Publisher.NewRelic
{
    public class NewRelicPublisher : IPublisher
    {
        private void Publish(ITimedMetric metric)
        {
            NewRelicApi.RecordResponseTimeMetric(GetMetricPath(metric.Type, metric.Name), metric.Timer.ElapsedMilliseconds);
        }

        private void Publish(IGaugeMetric metric)
        {
            NewRelicApi.RecordMetric(GetMetricPath(metric.Type, metric.Name), (float) metric.Gauge.Value);
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
            var timedMetric = metric as ITimedMetric;
            var guageMetric = metric as IGaugeMetric;
            if (timedMetric != null)
            {
                Publish(timedMetric);
            }
            if (guageMetric != null)
            {
                Publish(guageMetric);
            }
        }

        internal static string GetMetricPath(IMetric metric)
        {
            return GetMetricPath(metric.Type, metric.Name);
        }

        internal static string GetMetricPath(params object[] paths)
        {
            var sb = new StringBuilder();
            foreach (var path in paths)
            {
                sb.AppendFormat("{0}/", path);
            }

            var final = sb.ToString();
            final = final.Remove(final.Length - 1);
            return final;
        }
    }
}
