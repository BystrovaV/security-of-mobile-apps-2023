using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceInfo
{
    class PhysicalMemoryItem
    {
        public string Name { get; set; }
        public long Capacity { get; set; }
        public string ConfiguredClockSpeed { get; set; }
        public string DataWidth { get; set; }
        public string Speed { get; set; }
        public string SerialNumber { get; set; }
        public string SMBIOSMemoryType { get; set; }
        public string DeviceLocator { get; set; }
        public string Manufacturer { get; set; }
        public string Tag { get; set; }
    }
}
