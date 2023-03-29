using NetFwTypeLib;
using System;
using System.Management;
using System.Collections.Generic;
using System.Windows;
using WUApiLib;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace DeviceInfo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HideAll();
        }

        private bool IsJson = false;

        private void showInfo_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            if (isJson.IsChecked == true)
            {
                IsJson = true;
                jsonInfo.Clear();
                jsonInfo.Visibility = Visibility.Visible;
                jsonInfo.AppendText("{\n");
            }
            else
            {
                IsJson = false;
                jsonInfo.Visibility = Visibility.Collapsed;
            }             

            if (isAntivirus.IsChecked == true)
                GetAntivirusName();

            if (isUpdates.IsChecked == true)
                UpdateInfo();

            if (isLogicalDisk.IsChecked == true)
                GetLogicalDiskInfo();

            if (isPhysicalMemory.IsChecked == true)
                GetPhysicalMemoryInfo();

            if (isProcessor.IsChecked == true)
                GetProcessorInfo();

            if (isFireWall.IsChecked == true)
                CheckFirewal1l();

            if (isGeneralInfo.IsChecked == true)
                GetHardwareInfo();

            if(IsJson)
                jsonInfo.AppendText("}");

            UncheckAll();
        }

        public void GetAntivirusName()
        {
            antivirusList.Items.Clear();
            antivirusText.Visibility = Visibility.Visible;
            antivirusList.Visibility = Visibility.Visible;

            try
            {
                ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
                ManagementObjectCollection data = wmiData.Get();

                foreach (ManagementObject virusChecker in data)
                {
                    var a = new AntivirusItem
                    {
                        Name = virusChecker["displayName"].ToString(),
                        State = AntivirusItem.ProductState[Convert.ToInt32(virusChecker["productState"])]
                    };
                    antivirusList.Items.Add(a);
                }

                if (IsJson)
                    JsonFormat(antivirusList.Items, "antiviruses");
            }
            catch(Exception ex)
            {

            }
        }

        private void CheckFirewal1l()
        {
            firewallText.Visibility = Visibility.Visible;
            firewallInfo.Visibility = Visibility.Visible;
            try
            {
                Type tpNetFirewall = Type.GetTypeFromProgID
                   ("HNetCfg.FwMgr", false);

                INetFwMgr mgrInstance = (INetFwMgr)Activator
                   .CreateInstance(tpNetFirewall);

                bool blnEnabled = mgrInstance.LocalPolicy
                   .CurrentProfile.FirewallEnabled;

                List<string> items = new List<string>();
                items.Add(blnEnabled ? "Firewall enable" : "Firewall disable");

                firewallInfo.Text = items[0] + "\n";

                items.Add(mgrInstance.LocalPolicy.CurrentProfile.NotificationsDisabled ? "Notifications disable"
                    : "Notifications enabled");
                firewallInfo.Text += items[1] + "\n";

                JsonFormat(items, "firewall");
            }
            catch (Exception)
            {
                firewallInfo.Text = "Firewall disable";
            }
        }

        private void UpdateInfo()
        {
            updatesList.Items.Clear();
            updatesText.Visibility = Visibility.Visible;
            updatesList.Visibility = Visibility.Visible;
            updatesNumberText.Visibility = Visibility.Visible;

            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            uSearcher.Online = false;
            try
            {
                ISearchResult sResult = uSearcher.Search("IsInstalled=1 And IsHidden=0");
                updatesNumberText.Text = "Found " + sResult.Updates.Count + " updates";
                foreach (IUpdate update in sResult.Updates)
                {
                    updatesList.Items.Add(update.Title);
                }

                if (IsJson)
                    JsonFormat(updatesList.Items, "updates");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        private void GetHardwareInfo()
        {
            hardwareText.Visibility = Visibility.Visible;
            hardwareInfo.Visibility = Visibility.Visible;

            HardwareInfo hardware = new HardwareInfo
            {
                MachineName = Environment.MachineName,
                UserName = Environment.UserName,
                BitOS = Environment.Is64BitOperatingSystem ? "64-bit operating system"
                : "32-bit operating system",
                OSVersion = Environment.OSVersion.ToString()
            };

            MachineNameText.Text = hardware.MachineName;
            UserNameText.Text = hardware.UserName;
            BitOSText.Text = hardware.BitOS;
            OSVersionText.Text = hardware.OSVersion;

            if (IsJson)
                JsonFormat(hardware, "hardwareInfo");
        }

        private void GetProcessorInfo()
        {
            processorsList.Items.Clear();
            processorText.Visibility = Visibility.Visible;
            processorsList.Visibility = Visibility.Visible;

            ManagementClass management = new ManagementClass("Win32_Processor");
            ManagementObjectCollection managementobject = management.GetInstances();

            foreach (ManagementObject mngObject in managementobject)
            {
                try
                {
                    processorsList.Items.Add(new ProcessorItem
                    {
                        Name = mngObject["Name"].ToString(),
                        NumberOfCores = mngObject["NumberOfCores"].ToString(),
                        NumberOfLogicalProcessors = mngObject["NumberOfLogicalProcessors"].ToString(),
                        ProcessorType = ProcessorItem.ProcessorTypes[
                        Convert.ToInt32(mngObject["ProcessorType"])],
                        MaxClockSpeed = mngObject["MaxClockSpeed"].ToString()
                    });
                } catch(Exception ex)
                {

                }
                
            }

            if (IsJson)
                JsonFormat(processorsList.Items, "processors");
        }

        private void GetLogicalDiskInfo()
        {
            logicalDisksList.Items.Clear();
            logicalDiskText.Visibility = Visibility.Visible;
            logicalDisksList.Visibility = Visibility.Visible;

            ManagementClass management = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection managementobject = management.GetInstances();

            foreach (ManagementObject mngObject in managementobject)
            {
                try
                {
                    logicalDisksList.Items.Add(new LogicalDiskItem
                    {
                        Name = mngObject["Name"].ToString(),
                        DriveType = LogicalDiskItem.LogicalDiskType[Convert.ToInt32(mngObject["DriveType"])],
                        FileSystem = mngObject["FileSystem"].ToString(),
                        Size = LogicalDiskItem.ConvertSpace(mngObject["Size"].ToString()),
                        FreeSpace = LogicalDiskItem.ConvertSpace(mngObject["FreeSpace"].ToString())
                    });
                } catch(Exception ex)
                {

                }
                
            }

            if (IsJson)
                JsonFormat(logicalDisksList.Items, "logicalDisks");
        }

        private void GetPhysicalMemoryInfo()
        {
            physicalMemoryItem.Items.Clear();
            physicalMemoryText.Visibility = Visibility.Visible;
            physicalMemoryItem.Visibility = Visibility.Visible;

            ManagementClass management = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection managementobject = management.GetInstances();

            foreach (ManagementObject mngObject in managementobject)
            {
                try
                {
                    physicalMemoryItem.Items.Add(new PhysicalMemoryItem
                    {
                        Name = mngObject["Name"].ToString(),
                        Capacity = Convert.ToInt64(mngObject.Properties["Capacity"].Value) / (1024 * 1024 * 1024),
                        ConfiguredClockSpeed = mngObject["ConfiguredClockSpeed"].ToString(),
                        DataWidth = mngObject["DataWidth"].ToString(),
                        Speed = mngObject["Speed"].ToString(),
                        SerialNumber = mngObject["SerialNumber"].ToString(),
                        SMBIOSMemoryType = mngObject["SMBIOSMemoryType"].ToString(),
                        DeviceLocator = mngObject["DeviceLocator"].ToString(),
                        Manufacturer = mngObject["Manufacturer"].ToString(),
                        Tag = mngObject["Tag"].ToString()
                    });
                } catch(Exception ex)
                {

                }
                
            }

            if (IsJson)
                JsonFormat(physicalMemoryItem.Items, "physicalMemory");
        }

        private void HideAll()
        {
            antivirusText.Visibility = Visibility.Collapsed;
            antivirusList.Visibility = Visibility.Collapsed;

            updatesText.Visibility = Visibility.Collapsed;
            updatesNumberText.Visibility = Visibility.Collapsed;
            updatesList.Visibility = Visibility.Collapsed;

            firewallText.Visibility = Visibility.Collapsed;
            firewallInfo.Visibility = Visibility.Collapsed;

            processorText.Visibility = Visibility.Collapsed;
            processorsList.Visibility = Visibility.Collapsed;

            logicalDiskText.Visibility = Visibility.Collapsed;
            logicalDisksList.Visibility = Visibility.Collapsed;

            physicalMemoryText.Visibility = Visibility.Collapsed;
            physicalMemoryItem.Visibility = Visibility.Collapsed;

            hardwareText.Visibility = Visibility.Collapsed;
            hardwareInfo.Visibility = Visibility.Collapsed;
        }

        public void UncheckAll()
        {
            isUpdates.IsChecked = false;
            isAntivirus.IsChecked = false;
            isLogicalDisk.IsChecked = false;
            isPhysicalMemory.IsChecked = false;
            isProcessor.IsChecked = false;
            isFireWall.IsChecked = false;
            isGeneralInfo.IsChecked = false;
            isJson.IsChecked = false;
        }

        private void JsonFormat(object o, string arrayName)
        {
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, 
                UnicodeRanges.Cyrillic)
            };
            jsonInfo.AppendText("\"" + arrayName + "\":"+ JsonSerializer.Serialize(o, options) + ",\n");
        }


    }
}
