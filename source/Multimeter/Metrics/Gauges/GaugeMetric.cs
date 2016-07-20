namespace Multimeter
{
    public class GaugeMetric : Metric, IGaugeMetric
    {
        private readonly string _type;

        public GaugeProperties Gauge { get; private set; }

        public override string Type
        {
            get { return _type; }
        }

        public GaugeMetric(string type, string name =null)
        {
            _type = type;
            Name = name;
            Gauge = new GaugeProperties();
        }

        public override string ToString()
        {
            return base.ToString() + " " + Gauge;
        }
    }
}