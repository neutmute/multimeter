﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimeter
{
    public abstract class Metric : IMetric
    {
        public DateTimeOffset Timestamp { get; set; }

        public abstract string Type { get; }
        
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Type='{GetType().Name}', Name='{Name}'";
        }
    }
}
