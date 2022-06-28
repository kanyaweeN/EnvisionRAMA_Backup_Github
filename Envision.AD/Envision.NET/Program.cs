using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using Envision.Common;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using Envision.WebService;
using System.Threading;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Miracle.Util;

namespace Envision.NET
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.OfficeSkins.Register();
            Application.Run(new Login());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //Use e.Exception for any purpose.
            
            SaveScreen(e.Exception);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //Use ex for exception.
            Exception ex = (Exception)e.ExceptionObject;
            SaveScreen(ex);
        }

        private static void SaveScreen(Exception ex)
        {
            GBLEnvVariable env = new GBLEnvVariable();
            EnvisionWebService ws = new EnvisionWebService(env.WebServiceIP);
            if (env.DialogForm != null)
            {
                DevExpress.Utils.WaitDialogForm dd = env.DialogForm as DevExpress.Utils.WaitDialogForm;
                dd.Close();
            }
            if (env.ReportingObject != null)
            {
                Utilities.keepReportingLog(env.ReportingObject as DevExpress.XtraRichEdit.RichEditControl, env.AccessionReport);
            }
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp as Image);
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            string _path = ConfigurationSettings.AppSettings["errorImagesPath"].ToString();

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
            string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
            string errorMsg = ErrorDetails(ex);
            Utilities.keepLog(errorMsg, env.AccessionReport);
            ProcessAddGBLErrorLogs prc = new ProcessAddGBLErrorLogs();
            prc.GBL_ERRORLOGS.ERROR_MESSAGE = errorMsg;// ex.Message;
            prc.GBL_ERRORLOGS.ERROR_SOURCE = ex.Source;
            prc.GBL_ERRORLOGS.USER_HOST_ADDRESS = Utilities.IPAddress();
            prc.GBL_ERRORLOGS.ERROR_FORM = env.ErrorForm;
            prc.GBL_ERRORLOGS.USER_LOGIN = env.UserName;
            prc.GBL_ERRORLOGS.CREATED_BY = env.UserID;
            prc.Invoke();

            string image_path = string.Format(
            "{0}\\{1}\\{2:HHmmssfff}_{3}.jpg",
            year + month,
            year + month + day,
            DateTime.Now,
            prc.GBL_ERRORLOGS.ERROR_ID.ToString()
            );

            ProcessUpdateGBLErrorLogs prcUpdate = new ProcessUpdateGBLErrorLogs();
            prcUpdate.GBL_ERRORLOGS.ERROR_ID = prc.GBL_ERRORLOGS.ERROR_ID;
            prcUpdate.GBL_ERRORLOGS.PIC_PATH = image_path;
            prcUpdate.Invoke();

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    ms.Position = 0;
                    byte[] img = new byte[ms.Length];
                    ms.Read(img, 0, Convert.ToInt32(ms.Length));

                    ws.SavePicture(_path + image_path, img);
                }

            }
            catch (Exception exx)
            {
                image_path = string.Empty;

                ws.SaveClientLog("ScanImage", exx.Message);
            }
        }
        [DllImport("GdiPlus.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int GdipCreateBitmapFromGdiDib(IntPtr pDIB, IntPtr pPix, out IntPtr pBitmap);

        private static Bitmap ConvertBitmapFromDIB(IntPtr pDIB, IntPtr pPix)
        {
            MethodInfo method = typeof(Bitmap).GetMethod("FromGDIplus", BindingFlags.Static | BindingFlags.NonPublic);

            if (method == null) return null; // (permission problem)

            IntPtr bmp = IntPtr.Zero;
            int status = GdipCreateBitmapFromGdiDib(pDIB, pPix, out bmp);

            return ((status == 0) && (bmp != IntPtr.Zero)) ? (Bitmap)method.Invoke(null, new object[] { bmp }) : null;
        }
        private static string ErrorDetails(Exception exception)
        {
            string exceptionString = "";
            try
            {
                int i = 0;
                while (exception != null)
                {
                    exceptionString += "*** Exception Level " + i + "***\n";
                    exceptionString += "Message: " + exception.Message + "\n";
                    exceptionString += "Source: " + exception.Source + "\n";
                    exceptionString += "Target Site: " + exception.TargetSite + "\n";
                    exceptionString += "Stack Trace: " + exception.StackTrace + "\n";
                    exceptionString += "Data: ";
                    foreach (System.Collections.DictionaryEntry keyValuePair in
                    exception.Data)
                        exceptionString += keyValuePair.Key.ToString()
                        + ":" + keyValuePair.Value.ToString();
                    exceptionString += "\n***\n\n";

                    exception = exception.InnerException;

                    i++;
                }
            }
            catch { }

            return exceptionString;
        }
    }
}