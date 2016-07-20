using System;

namespace Multimeter
{
    public class TimerProperties
    {
        public bool IsException { get; set; }

        public TimeSpan Elapsed { get; set; }

        public long ElapsedMilliseconds { get { return (long)Elapsed.TotalMilliseconds; } }

        public TimerProperties()
        {
            IsException = false;
        }

        public override string ToString()
        {
            return string.Format("{0} ms", ElapsedMilliseconds.ToString().PadLeft(4, '0'));
        }
    }
}