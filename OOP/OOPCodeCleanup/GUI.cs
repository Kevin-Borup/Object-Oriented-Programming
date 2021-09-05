using System;
using System.Collections.Generic;
using System.Management;

namespace OOPCodeCleanup
{
    static class GUI 
    {
        public static void CPUPrinter(ManagementObjectSearcher results)
        {
            foreach (ManagementObject obj in results.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine($"CPU{name} : {usage}");
            }
        }
        public static void OSPrinter(ManagementObjectCollection results)
        {
            foreach (ManagementObject result in results)
            {
                Console.WriteLine($"User:\t{result["RegisteredUser"]}\n" +
                                  $"Org.:\t{result["Organization"]}\n" +
                                  $"O/S :\t{result["Name"]}");
            }
        }
    }
}
