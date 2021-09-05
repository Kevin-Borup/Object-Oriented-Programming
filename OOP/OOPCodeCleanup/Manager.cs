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
            /*
            1. GetDiskMetadata
            2. GetHardDiskSerialNumber
            3. CPUUsage
            4. MainStorage
            5. GetOSInfo
            6. TestHest
            7. ListAllService
            */

            GetDiskMetadata();
            GetHardDiskSerialNumber();

            GUI.CPUPrinter(new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor"));
            
            hovedLager();
            GetOSInfo();
            GetBootDeviceInfo();

            Console.WriteLine("process søgning");
            LISTAllServices();
            Console.ReadKey();
        }

        static void GetOSInfo()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            GUI.OSPrinter(searcher.Get());
        }

        static void GetBootDeviceInfo()
        {
            ManagementScope scope = new ManagementScope(@"\\.\ROOT\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);
            }
        }
        static List<string> PopulateDisk()
        {
            List<string> disk = new List<string>();

            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");

            ManagementObjectSearcher mnagementObjectSearcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject managementObject in mnagementObjectSearcher.Get())
            {
                disk.Add(managementObject.ToString());
            }
            return disk;
        }

        static void hovedLager()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine($"Total Visible Memory: {result["TotalVisibleMemorySize"]}KB\n" +
                                  $"Free Physical Memory: {result["FreePhysicalMemory"]}KB\n" +
                                  $"Total Virtual Memory: {result["TotalVirtualMemorySize"]}KB\n" +
                                  $"Free Virtual Memory: {result["FreeVirtualMemory"]}KB\n");
            }
        }


        static void GetDiskMetadata()
        {
            ManagementScope managementScope = new ManagementScope();

            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                Console.WriteLine($"Disk Name: {managementObject["Name"]}\n" +
                                  $"FreeSpace: {managementObject["FreeSpace"]}\n" +
                                  $"Disk Size: {managementObject["Size"]}\n" +
                                  $"---------------------------------------------------\n");
            }
        }

        static string GetHardDiskSerialNumber(string drive = "C")
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();
            Console.WriteLine(managementObject["VolumeSerialNumber"].ToString());

            return managementObject["VolumeSerialNumber"].ToString();
        }

        private static void LISTAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            Console.WriteLine("There are {0} Windows services: ", objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
