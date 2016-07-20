using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Keen.Core;
using Multimeter.Config;

namespace Multimeter.Publisher.KeenIO
{
    public class KeenIOPublisher : IPublisher
    {
        private readonly KeenClient _client;

        public KeenIOPublisher()
        {
            if (MultimeterConfig.Instance.KeenIO == null)
            {
                throw new ConfigurationErrorsException("KeenIO configuration is missing");
            }

            var projectId = MultimeterConfig.Instance.KeenIO.ProjectId;
            var writeKey = MultimeterConfig.Instance.KeenIO.WriteKey;
            var settings = new ProjectSettingsProvider(projectId, writeKey: writeKey);
            _client = new KeenClient(settings);
        }
        

        public void Publish(IMetric metric)
        {
            _client.AddEventAsync(metric.Type, metric);
        }
    

        public void Publish(IEnumerable<IMetric> metrics)
        {
            foreach (var metric in metrics)
            {
                Publish(metric);
            }
        }
    }
}
