using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Common.Logging;
using Multimeter;
using Multimeter.Config;

namespace Multimeter
{
    public class MultimeterService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public List<IPublisher> Publishers { get; private set; }

        public bool HasConfig 
        {
            get
            {
                return MultimeterConfig.IsPresent
                    && MultimeterConfig.Instance.HasPublisherConfig;
            } 
        }

        #region Singleton

        private static readonly Lazy<MultimeterService> _lazy = new Lazy<MultimeterService>(() => new MultimeterService());

        public static MultimeterService Instance
        {
            get { return _lazy.Value; }
        }

        private MultimeterService()
        {
            Publishers = new List<IPublisher>();

            if (HasConfig)
            { 
                foreach (PublisherConfig publisherConfig in MultimeterConfig.Instance.Publishers)
                {
                    var publisher = (IPublisher)Activator.CreateInstance(publisherConfig.AssemblyName, publisherConfig.AssemblyType).Unwrap();
                    Publishers.Add(publisher);
                }
            }
        }

        #endregion

        /// <summary>
        /// One line publish for simple cases
        /// </summary>
        public void Publish(string type, string name, TimeSpan elapsed, bool isException = false)
        {
            var metric = MetricFactory.Instance.CreateTimedMetric(type, name, elapsed, isException);
            Publish(metric);
        }

        /// <summary>
        /// This could be done better
        /// </summary>
        public void Publish(List<IMetric> metrics)
        {
            metrics.ForEach(Publish);
        }

        public void Publish(IMetric metric)
        {
            Publishers.ForEach(
                p =>
                {
                    try
                    {
                        metric.Timestamp = DateTimeOffset.Now;
                        p.Publish(metric);
                    }
                    catch (Exception e)
                    {
                        Log.Error(m=>m("Failed to publish multimeter metric '{0}' to {1}", metric, p.GetType().Name), e);
                    }
                });
        }
    }
}
