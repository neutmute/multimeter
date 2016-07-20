/*
 * This stopped us decorating with other properties in consumer project
 */
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Multimeter.Publisher.KeenIO
//{
//    /// <summary>
//    /// Don't pollute Keen with TimeSpans (Elapsed) which they can't handle so convert the object first
//    /// </summary>
//    public class KeenElapsedMetric
//    {
//        public string Name { get; set; }

//        public long ElapsedMilliseconds { get; set; }

//        public Solution Solution { get; set; }

//        public Host Host { get; set; }

//        public KeenElapsedMetric(ITimedMetric source)
//        {
//            Solution = source.Solution;
//            Host = source.Host;
//            Name = source.Name;
//            ElapsedMilliseconds = (long) source.Elapsed.TotalMilliseconds;
//        }
//    }
//}
