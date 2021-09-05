using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace OOPCodeCleanup
{
    static class Manager
    {

        public static void Process()
        {
            // The program is setup to run in this manner
            // Each method called in this logic layer, updates the value on the WMIStorage to the newer correct value
            // Then the method to print this updated data is called from the GUI methods.
            // The GUI is able to use the WMIStorage properties, as they now provide updates information.
            /*
             * OS Info
             * OS Print
             * Boot Device Info
             * Boot Device Print
             * CPU Info
             * CPU Print
             * Harddisk Serial Number Info
             * Harddisk Serial Number Print
             * Disk Metadata Info
             * Disk Metadata Print
             * RAM Info
             * RAM Print
             * Services Info
             * Services Print
            */

            UpdateOSInfo();
            GUI.OSPrinter();
            UpdateBootDeviceInfo();
            GUI.BootPrinter();
            UpdateCPUInfo();
            GUI.CPUPrinter();
            UpdateHarddiskSerialNumber();
            GUI.HarddiskSerialPrinter();
            UpdateDiskMetadata();
            GUI.DiskMetadataPrinter();
            UpdateRAMInfo();
            GUI.RAMPrinter();
            UpdateServicesInfo();
            GUI.ServicePrinter();
        }
        static void UpdateOSInfo()
        {
            WMIStorage.WinQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            WMIStorage.WinSearch = new ManagementObjectSearcher(WMIStorage.WinQuery);
        }
        static void UpdateBootDeviceInfo()
        {
            WMIStorage.SearchScope = new ManagementScope(@"\\.\ROOT\cimv2");
            WMIStorage.WinQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            WMIStorage.WinSearch = new ManagementObjectSearcher(WMIStorage.SearchScope, WMIStorage.WinQuery);
        }
        static void UpdateCPUInfo()
        {
            WMIStorage.WinQuery = new ObjectQuery("select * from Win32_PerfFormattedData_PerfOS_Processor");
            WMIStorage.WinSearch = new ManagementObjectSearcher(WMIStorage.WinQuery);
        }
        static void UpdateHarddiskSerialNumber(string drive = "C")
        {
            WMIStorage.Volume = drive;
            WMIStorage.VolumeSE = new ManagementObject($@"Win32_LogicalDisk.DeviceID=""{WMIStorage.Volume}:""");
        }
        static void UpdateDiskMetadata()
        {
            WMIStorage.SearchScope = new ManagementScope();
            WMIStorage.WinQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            WMIStorage.WinSearch = new ManagementObjectSearcher(WMIStorage.SearchScope, WMIStorage.WinQuery);
        }
        static void UpdateRAMInfo()
        {
            WMIStorage.WinQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            WMIStorage.WinSearch = new ManagementObjectSearcher(WMIStorage.WinQuery);
        }
        private static void UpdateServicesInfo()
        {
            WMIStorage.WinSearch = new ManagementObjectSearcher(@"root\cimv2", "select * from Win32_Service");
        }
    }
}
