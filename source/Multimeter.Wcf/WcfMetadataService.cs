using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Wcf
{
    public class WcfMessageMetadata
    {
        public string Operation { get; set; }

        public string Interface { get; set; }
    }

    public class WcfMetadataService
    {
        public WcfMessageMetadata GetMessageMetadata(Message request)
        {
            string action = request.Headers.Action;
            return GetMessageMetadata(action);
        }

        public WcfMessageMetadata GetMessageMetadata(string action)
        {
            var context = new WcfMessageMetadata();

            string[] split = action.Split('/');
            context.Operation = split[split.Length - 1];
            context.Interface = split[split.Length - 2];

            return context;
        }
    }
}
