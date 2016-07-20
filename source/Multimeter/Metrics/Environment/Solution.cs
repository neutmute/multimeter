namespace Multimeter
{
    public class Solution
    {
        /// <summary>
        /// Polecat, Packman, Hero2. Application might be a better name but aligns with Mercury.Project but I think this is better
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// WebUI, WCF, Marshal
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// UAT, PROD, CI
        /// </summary>
        public string Environment { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Project={1}, Environment={2}", Name, Project, Environment);
        }
    }
}