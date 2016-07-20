namespace Multimeter.Web
{
    public class SoapMetric : SelfTimingTimedMetric
    {
        public SoapMetric(string name) : base ("WebService", name)
        {
            
        }

        public string Message { get; set; }
    }
}