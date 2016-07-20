using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter.Config
{
    internal partial class MultimeterAppConfig
    {
        public static bool HasAppConfig => Instance != null;
    }
}
