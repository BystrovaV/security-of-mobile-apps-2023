using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceInfo
{
    class LogicalDiskItem
    {
        public string Name { get; set; }
        public string DriveType { get; set; }
        public string FileSystem { get; set; }
        public string Size { get; set; }
        public string FreeSpace { get; set; }

        public static string ConvertSpace(string s)
        {
            double a = Convert.ToInt64(s) / (1024.0 * 1024 * 1024);
            if (a < 1)
            {
                a *= 1024;
                return Math.Round(a, 1) + " MB";
            }
            else
            {
                return Math.Round(a, 1) + " GB";
            }
        }

        public static Dictionary<int, string> LogicalDiskType = new Dictionary<int, string>
        {
            {0, "Unknown" },
            {1, "No Root Directory" },
            {2, "Removable Disk" },
            {3, "Local Disk" },
            {4, "Network Device" },
            {5, "Compact Disc" },
            {6, "RAM Disk" }
        };
    }
}
