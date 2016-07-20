using System;

namespace Multimeter
{
    public class GaugeProperties 
    {
        public Decimal Value { get; set; }

        public override string ToString()
        {
            return string.Format("Gauge={0}", Value);
        }
    }
}