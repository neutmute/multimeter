namespace Multimeter
{
    public class OperatingSystem
    {
        public string Version { get; set; }

        public override string ToString()
        {
            return string.Format("Version={0}", Version);
        }
    }
}