﻿using System;
using System.Collections.Generic;
using Common.Logging;
using Multimeter.Config;

namespace Multimeter
{
    public class MultimeterService
    {
        private static readonly ILog Log = LogManager.GetLogger<MultimeterService>();

        public List<IPublisher> Publishers { get; private set; }

        public bool HasConfig => MultimeterConfig.Instance.HasValidConfig;

        #region Singleton

        private static readonly Lazy<MultimeterService> _lazy = new Lazy<MultimeterService>(() => new MultimeterService());

        public static MultimeterService Instance => _lazy.Value;

        private MultimeterService()
        {
            Publishers = new List<IPublisher>();

            if (HasConfig)
            { 
                foreach (var publisherConfig in MultimeterConfig.Instance.Publishers)
                {
                    var publisherType = Type.GetType($"{publisherConfig.AssemblyType}, {publisherConfig.AssemblyName}");
                    var publisher = (IPublisher)Activator.CreateInstance(publisherType);
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
