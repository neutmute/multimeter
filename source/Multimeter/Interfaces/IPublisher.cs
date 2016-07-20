using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multimeter
{
    public interface IPublisher
    {
        void Publish(IMetric metric);

        void Publish(IEnumerable<IMetric> metrics);
    }
}
