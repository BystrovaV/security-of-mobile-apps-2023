using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceInfo
{
    public class AntivirusItem
    {
        public string Name { get; set; }
        public string State { get; set; }

        public static Dictionary<int, string> ProductState = new Dictionary<int, string>()
        {
            {262144 , "disable and up to date" },
            {266240 , "enabled and up to date" },
            {266256 , "firewall enabled" },
            {262160 , "firewall disabled" },
            {393472 , "disabled and up to date" },
            {397584 , "enabled and out of date" },
            {397568 , "enabled and up to date" },
            {397312 , "enabled and up to date" },
            {393216 , "disabled and up to date" }
        };
    }
}
