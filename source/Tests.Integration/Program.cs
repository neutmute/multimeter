using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Loggly;
using Loggly.Config;
using Multimeter;
using Multimeter.Config;

namespace Tests.Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLoggly();

            ConfigureMultimeter();

            CreateMetrics();
        }

        private static void ConfigureMultimeter()
        {
            MultimeterConfig.Instance.Publishers.Add("Multimeter.Publisher.Loggly", "Multimeter.Publisher.Loggly.LogglyPublisher");
        }

        private static void CreateMetrics()
        {
            using (new SelfPublishingTimedMetric("Multimeter", "self-publishing-test"))
            {
                Thread.Sleep(500);
            }
        }

        private static void ConfigureLoggly()
        {
            var config = LogglyConfig.Instance;
            config.CustomerToken = Environment.GetEnvironmentVariable("multimeter-loggly-customer-token");
            config.ApplicationName = "multimeter-integration-test";

            Console.WriteLine($"config.CustomerToken is {config.CustomerToken}");

            if (string.IsNullOrEmpty(config.CustomerToken))
            {
                throw new Exception("Please set loggly customer token via environment variable: multimeter-loggly-customer-token");
            }

            config.Transport.EndpointHostname = "logs-01.loggly.com";
            config.Transport.EndpointPort = 443;
            config.Transport.LogTransport = LogTransport.Https;
            
            var ct = new ApplicationNameTag();
            ct.Formatter = "application-{0}";
            config.TagConfig.Tags.Add(ct);
        }
    }
}
