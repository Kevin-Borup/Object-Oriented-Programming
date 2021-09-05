using System;
using System.Collections.Generic;
using System.Management;

namespace OOPCodeCleanup
{
    static class GUI 
    {
        public static void OSPrinter()
        {
            foreach (ManagementObject result in WMIStorage.WinSearch.Get())
            {
                Console.WriteLine($"User:\t{result["RegisteredUser"]}\n" +
                                  $"Org.:\t{result["Organization"]}\n" +
                                  $"O/S :\t{result["Name"]}");
            }
            Console.WriteLine("---------------------------------------------------");
        }
        public static void BootPrinter()
        {
            foreach (ManagementObject result in WMIStorage.WinSearch.Get())
            {
                // access properties of the WMI object
                Console.WriteLine($"BootDevice : {result["BootDevice"]}");
            }
            Console.WriteLine("---------------------------------------------------");
        }
        public static void CPUPrinter()
        {
            foreach (ManagementObject obj in WMIStorage.WinSearch.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine($"CPU{name}: {usage}");
            }
            Console.WriteLine("---------------------------------------------------");
        }
        public static void HarddiskSerialPrinter()
        {
            Console.WriteLine($"Drive {WMIStorage.Volume}: - SE: {WMIStorage.VolumeSE}");
        }
        public static void DiskMetadataPrinter()
        {
            foreach (ManagementObject result in WMIStorage.WinSearch.Get())
            {
                Console.WriteLine($"Disk Name: {result["Name"]}\n" +
                                  $"Disk Size: {result["Size"]}\n" +
                                  $"Free Space: {result["FreeSpace"]}\n" +
                                  $"---------------------------------------------------");
            }
        }
        public static void RAMPrinter()
        {
            Console.Write("RAM Information:");
            foreach (ManagementObject result in WMIStorage.WinSearch.Get())
            {
                Console.WriteLine($"\nTotal Visible Memory: {result["TotalVisibleMemorySize"]}KB\n" +
                                  $"Free Physical Memory: {result["FreePhysicalMemory"]}KB\n" +
                                  $"Total Virtual Memory: {result["TotalVirtualMemorySize"]}KB\n" +
                                  $"Free Virtual Memory: {result["FreeVirtualMemory"]}KB");
            }
            Console.WriteLine("---------------------------------------------------");
        }
        public static void ServicePrinter()
        {
            Console.WriteLine("Process Searching...");
            Console.WriteLine("There are {0} Windows services: ", WMIStorage.WinSearch.Get().Count);
            Console.WriteLine("Press any key to display all services");
            Console.ReadKey();

            foreach (ManagementObject windowsService in WMIStorage.WinSearch.Get())
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
