using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace LocalSetting
{
    public class LocalSettingHandler
    {
        [DllImport("user32")]
        public static extern int GetSystemMetrics(int nIndex);

        public bool IsPointingDeviceAttached()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PointingDevice");

            int devCount = 0;

            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj["Status"].ToString().Contains("OK")) // if device is ready
                    devCount++;

                Console.WriteLine("Mouse Name: {0}", obj.GetPropertyValue("Description"));
            }
            return devCount > 0;
        }

        public bool IsKeyboardAttached()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Keyboard");

            int devCount = 0;

            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj["Status"].ToString().Contains("OK")) // if device is ready
                    devCount++;

                Console.WriteLine("KB Name: {0}", obj.GetPropertyValue("Description"));
            }


            return devCount > 0;
        }

        //private void isUseTouchScreen()
        //{
        //    int MAXTOUCHES_INDEX = 0x95;
        //    int maxTouches = 0;

        //    try
        //    {
        //        maxTouches = GetSystemMetrics(MAXTOUCHES_INDEX);
        //    }
        //    catch { }

        //    Console.WriteLine("터치 사용: " + ((maxTouches > 0) ? "예" : "아니요"));
        //}

        public void IsUseTouchScreen()
        {
            foreach (TabletDevice tabletDevice in Tablet.TabletDevices)
            {
                //Only detect if it is a touch Screen not how many touches (i.e. Single touch or Multi-touch)
                if (tabletDevice.Type == TabletDeviceType.Touch)
                {
                    Console.WriteLine("터치 사용: 예");
                    return;
                }
            }
        }
    }
}
