namespace Multimeter
{
    public class Host
    {
        public string Name { get; set; }

        public OperatingSystem OperatingSystem { get; set; }

        public Host()
        {
            OperatingSystem = new OperatingSystem();
        }

        //public override string ToString()
        //{
        //    //return $"Name={Name}, OperatingSystem={OperatingSystem}";
        //}
    }
}