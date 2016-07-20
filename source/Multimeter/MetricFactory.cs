using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimeter.Config;

namespace Multimeter
{
    public class MetricFactory
    {
        private Solution Solution { get; set; }
        private Host Host { get; set; }

        #region Singleton

        private static readonly Lazy<MetricFactory> _lazy = new Lazy<MetricFactory>(() => new MetricFactory());

        public static MetricFactory Instance
        {
            get { return _lazy.Value; }
        }

        private MetricFactory()
        {
            Solution = new Solution();
            //if (MultimeterConfig.IsPresent && MultimeterConfig.Instance.HasSolutionConfig)
            //{
            //    Solution.Name = MultimeterConfig.Instance.Solution.Name;
            //    Solution.Environment = MultimeterConfig.Instance.Solution.Environment;
            //    Solution.Project = MultimeterConfig.Instance.Solution.Project;
            //}

            Host = new Host();
            Host.Name = Environment.MachineName;
            Host.OperatingSystem.Version = Environment.OSVersion.VersionString;
        }

        internal void AssignEnvironmentDefaults(IMetric target)
        {
        }

        /// <summary>
        /// Create a stock standard metric
        /// </summary>
        public ITimedMetric CreateTimedMetric(string type, string name, TimeSpan elapsed, bool isException = false)
        {
            var timedMetric = new TimedMetric(type);
            var record = new TimedRecord {Name = name, Elapsed = elapsed, IsException = isException};
            var metric = AssignTimedMetric(timedMetric, record);
            return metric;
        }

        /// <summary>
        /// Create a timed metric of your own type (eg: may contain extra metadata)
        /// </summary>
        public ITimedMetric CreateTimedMetric<TMetric>(ITimedRecord record) where TMetric : ITimedMetric, IMetric, new()
        {
            return AssignTimedMetric(new TMetric(), record);
        }

        private ITimedMetric AssignTimedMetric<TMetric>(TMetric timedMetric, ITimedRecord record) where TMetric : ITimedMetric, IMetric
        {
            AssignEnvironmentDefaults(timedMetric);

            timedMetric.Name = record.Name;
            timedMetric.Timer.Elapsed = record.Elapsed;
            timedMetric.Timer.IsException = record.IsException;

            return timedMetric;
        }
        #endregion
    }
}
