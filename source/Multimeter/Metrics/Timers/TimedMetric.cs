namespace Multimeter
{
    public class TimedMetric : TimedMetricCore
    {
        private readonly string _type;

        public override string Type
        {
            get { return _type; }
        }

        public TimedMetric(string type)
        {
            _type = type;
        }
    }
}