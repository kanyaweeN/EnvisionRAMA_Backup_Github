using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using EnvisionIESender;
using EnvisionIEHelper;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using EnvisionInterfaceEngine.Connection;

namespace ConsoleTestService
{
    static class Program
    {
        static void Main()
        {
            //string[] configs = ConfigurationManager.AppSettings.AllKeys;

            //Console.WriteLine(string.Empty.PadRight(79, '*'));

            //foreach (string config in configs)
            //    Console.WriteLine(string.Format("{0}:{1}", config, ConfigurationManager.AppSettings[config]));

            //Console.WriteLine(string.Empty.PadRight(79, '*'));

            //Screen[] screens = Screen.AllScreens;

            //foreach (Screen screen in screens)
            //{
            //    using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
            //    {
            //        using (Graphics gfx = Graphics.FromImage(bmp))
            //        {
            //            gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            //            bmp.Save(string.Format("C:\\{0:yyyyMMddhhmmssffff}_Screenshot.png", DateTime.Now), ImageFormat.Png);
            //        }
            //    }
            //}

            using (Sender service = new Sender())
                service.Invoke();
            ////using (Helper service = new Helper())
            ////    service.Invoke();

            //while (Console.ReadKey().Key != ConsoleKey.Escape) ;

            //string accessionNo = "220405OERCR051";

            //RISConnection ris = new RISConnection();
            //DataTable dtRadiologistGroup = ris.selectDataRadiologistGroup(accessionNo);
        } 
    }
}