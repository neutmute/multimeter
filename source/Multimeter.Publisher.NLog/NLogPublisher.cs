using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Multimeter.Publisher.NLog
{
    public class NLogPublisher : IPublisher
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        
        public void Publish(IMetric metric)
        {
            Log.Info(metric);
        }

        public void Publish(IEnumerable<IMetric> metrics)
        {
            var messsage = string.Join("\r\n", metrics);
            Log.Info(messsage);
        }
    }
}
