using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Config
{
    public partial class MultimeterConfig
    {
        public static bool IsPresent
        {
            get { return Instance != null; }
        }
        
        public bool HasPublisherConfig
        {
            get { return Publishers != null; }
        }
    }
}
