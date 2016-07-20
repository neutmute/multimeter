using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Wcf
{
    public class MultimeterMessageInspector : IDispatchMessageInspector
    {
        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var metadataService = new WcfMetadataService();
            var metadata = metadataService.GetMessageMetadata(request);

            var metric = new SelfTimingTimedMetric("WCF", metadata.Interface + "." + metadata.Operation);
            return metric;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var metric = (SelfTimingTimedMetric) correlationState;
            metric.Stop();
            MultimeterService.Instance.Publish(metric);
        }
        #endregion
    }
}
