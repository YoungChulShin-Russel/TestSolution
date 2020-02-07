using System;
using System.Threading;
using System.Windows.Forms;

namespace LocalSetting
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalSettingHandler localSettingHandler = new LocalSettingHandler();

            Console.WriteLine("---------------------마우스-------------------------");
            bool useMouse = localSettingHandler.IsPointingDeviceAttached();

            Console.WriteLine("---------------------키보드-------------------------");
            bool useKeyboard = localSettingHandler.IsKeyboardAttached();

            Console.WriteLine("---------------------터치--------------------------");
            
            Thread t = new Thread(new ThreadStart(() =>
            {
                localSettingHandler.IsUseTouchScreen();
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            
            Console.WriteLine("---------------------해상도-------------------------");
            Console.WriteLine(Screen.PrimaryScreen.Bounds.Width);
            Console.WriteLine(Screen.PrimaryScreen.Bounds.Height);

            Console.ReadLine();
        }
    }
}
