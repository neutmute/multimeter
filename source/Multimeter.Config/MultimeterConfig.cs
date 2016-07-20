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

    public class MultimeterConfig  : IMultimeterConfig
    {
        //public static bool IsPresent
        //{
        //    get { return Instance != null; }
        //}
        
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
                    if (MultimeterAppConfig.HasAppConfig)
                    {
                        _instance = FromAppConfig();
                    }
                    else
                    {
                        _instance = GetNullConfig();
                    }
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
        
        private static IMultimeterConfig FromAppConfig()
        {
            var config = new MultimeterConfig();
            
            if (MultimeterAppConfig.Instance.Publishers != null)
            {
                foreach (PublisherAppConfig appPubConfig in MultimeterAppConfig.Instance.Publishers)
                {
                    var newConfig = new PublisherConfig();
                    newConfig.AssemblyName = appPubConfig.AssemblyName;
                    newConfig.AssemblyType = appPubConfig.AssemblyType;
                    config.Publishers.Add(newConfig);
                }
            }

            //todo: parse and add keenio config if ever required

            return config;
        }

    }
}
