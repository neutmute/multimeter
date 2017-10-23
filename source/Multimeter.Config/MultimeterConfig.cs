using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Config
{
    public class PublisherConfig : IPublisherConfig
    {
        public string AssemblyName { get; set; }

        public string AssemblyType { get; set; }
    }

    public class KeenIOConfig : IKeenIOConfig
    {
        public string ProjectId { get; set; }
        public string WriteKey { get; set; }
    }

    public class MultimeterConfig : IMultimeterConfig
    {
        public bool HasValidConfig => Publishers != null && Publishers.Count > 0;

        public List<IPublisherConfig> Publishers { get; }

        public IKeenIOConfig KeenIO { get; }

        private static IMultimeterConfig _instance;

        public static IMultimeterConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetNullConfig();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public MultimeterConfig()
        {
            Publishers = new List<IPublisherConfig>();
        }

        private static IMultimeterConfig GetNullConfig()
        {
            return new MultimeterConfig();
        }
    }
}
