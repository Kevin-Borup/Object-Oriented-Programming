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
    }
}
