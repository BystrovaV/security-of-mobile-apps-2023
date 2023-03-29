using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceInfo
{
    public class ProcessorItem
    {
        public string Name { get; set; }
        public string NumberOfCores { get; set; }
        public string NumberOfLogicalProcessors { get; set; }
        public string ProcessorType { get; set; }
        public string MaxClockSpeed { get; set; }

        public static Dictionary<int, string> ProcessorTypes = new Dictionary<int, string>
        {
            {1, "Other" },
            {2, "Unknown" },
            {3, "Central Processor" },
            {4, "Math Processor" },
            {5, "DSP Processor" },
            {6, "Video Processor" }
        };
    }
}
