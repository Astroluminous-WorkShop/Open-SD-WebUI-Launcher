using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
namespace 光源AI绘画盒子
{
    internal class hardinfo
    {

        public static string GetCpuName()
        {
            var CPUName = "";
            var management = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (var baseObject in management.Get())
            {
                var managementObject = (ManagementObject)baseObject;
                CPUName = managementObject["Name"].ToString();
            }
            return CPUName;
        }


        public static string GetComputerName()
        {
            return Environment.MachineName;
        }

        public static string GetSystemType()
        {
            var sysTypeStr = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementBaseObject o in moc)
            {
                ManagementObject mo = (ManagementObject)o;
                sysTypeStr = mo["SystemType"].ToString();
            }
            return sysTypeStr;
        }

        public static float GetPhysicalMemory()
        {
            float memoryCount = 0;
            var mc = new ManagementClass("Win32_ComputerSystem");
            var moc = mc.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;
                string str = mo["TotalPhysicalMemory"].ToString();//单位为 B
                float a = long.Parse(str);
                memoryCount = a / 1024 / 1024 / 1024;//单位换成GB
            }
            return memoryCount;
        }
        public static int MemoryNumberCount()
        {
            ManagementClass m = new ManagementClass("Win32_PhysicalMemory");//内存条
            ManagementObjectCollection mn = m.GetInstances();
            int count = mn.Count;
            return count;
        }
        public static string GPUName()
        {
            string DisplayName = "";
            ManagementClass m = new ManagementClass("Win32_VideoController");
            ManagementObjectCollection mn = m.GetInstances();
            DisplayName = "显卡数量：" + mn.Count.ToString() + "  " + "\n";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_VideoController");//Win32_VideoController 显卡
            int count = 0;
            foreach (ManagementObject mo in mos.Get())
            {
                count++;
                DisplayName += "显卡型号：" /*+ count.ToString() +*/  + mo["Name"].ToString() + "   " + "\n";
            }
            mn.Dispose();
            m.Dispose();
            return DisplayName;
        }

    }
}
