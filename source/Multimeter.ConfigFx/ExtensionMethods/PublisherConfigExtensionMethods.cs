using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Config
{
    public static class PublisherConfigExtensionMethods
    {
        public static void Add(this List<IPublisherConfig> target, string assemblyName, string assemblyType)
        {
            target.Add(new PublisherConfig {AssemblyName = assemblyName, AssemblyType = assemblyType});
        }
    }
}
