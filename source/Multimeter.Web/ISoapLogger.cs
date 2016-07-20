namespace Multimeter.Web
{
    public interface ISoapLogger
    {
        void BeginRequest();
        SoapMetric EndRequest();
    }
}