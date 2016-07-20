using System;
using Multimeter;

namespace Tests.Integration
{
    public class MyCustomMetric : IMetric
    {
        public DateTimeOffset Timestamp { get; set; }
        public string Type => "MyCustomMetric";
        public string Name { get; set; }

        public string CrazyProperty { get; set; }

        public MyCustomMetric()
        {
            Timestamp = DateTimeOffset.Now;
            Name = "MySuperCusomMetric";
            CrazyProperty = "This will log too!";
        }
    }
}