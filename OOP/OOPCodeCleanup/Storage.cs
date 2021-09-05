using System;
using System.Management;

namespace OOPCodeCleanup
{
    static class WMIStorage 
    {
        private static string volume;
        private static ManagementObject volumeSE;
        private static ObjectQuery winQuery;
        private static ManagementObjectSearcher winSearch;
        private static ManagementScope searchScope;
        public static string Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        public static ManagementObject VolumeSE
        {
            get { return volumeSE; }
            set { volumeSE = value; }
        }
        public static ObjectQuery WinQuery
        {
            get { return winQuery; }
            set { winQuery = value; }
        }
        public static ManagementObjectSearcher WinSearch
        {
            get { return winSearch; }
            set { winSearch = value; }
        }
        public static ManagementScope SearchScope
        {
            get { return searchScope; }
            set { searchScope = value; }
        }
    }
}
