using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Config
{
    public interface IMultimeterConfig
    {
        List<IPublisherConfig> Publishers { get; }

        bool HasValidConfig { get; }

        IKeenIOConfig KeenIO { get; }
    }

    public interface IPublisherConfig
    {
        string AssemblyName { get; set; }
        string AssemblyType { get; set; }
    }

    public interface IKeenIOConfig
    {
        string ProjectId { get; set; }

        string WriteKey { get; set; }
    }
    
}
