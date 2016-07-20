using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter
{
    /// <summary>
    /// Handy DTO for passing around
    /// </summary>
    public class TimedRecord : ITimedRecord
    {
        public string Name { get; set; }

        public TimeSpan Elapsed { get; set; }

        public bool IsException { get; set; }
    }
}
