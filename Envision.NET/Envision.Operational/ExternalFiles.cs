using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Envision.Common;
using Envision.WebService;

namespace Envision.Operational
{
    public class ExternalFiles
    {
        [DllImport("GdiPlus.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int GdipCreateBitmapFromGdiDib(IntPtr pDIB, IntPtr pPix, out IntPtr pBitmap);

        private GBLEnvVariable env;
        private EnvisionWebService ws;

        public ExternalFiles()
        {
            env = new GBLEnvVariable();
            ws = new EnvisionWebService(env.WebServiceIP);
        }

        public string SendPicture(string fileName, IntPtr dib, IntPtr pix)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
            string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

            //string image_path = string.Format(
            //    "{0}\\{1}\\{2}_{3:HHmmssfff}.jpg",
            //    year+month,
            //    year+month+day,
            //    fileName,
            //    DateTime.Now);
            string image_path = string.Format(
                "{0}\\{1}\\{2}\\{3}_{4:HHmmssfff}.jpg",
                year,
                month,
                day,
                fileName,
                DateTime.Now);

            try
            {
                using (Bitmap bitmap = ConvertBitmapFromDIB(dib, pix))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Jpeg);
                        ms.Position = 0;
                        byte[] img = new byte[ms.Length];
                        ms.Read(img, 0, Convert.ToInt32(ms.Length));

                        ws.SavePicture(env.ScannedImagePath + image_path, img);
                    }
                }
            }
            catch (Exception ex)
            {
                image_path = string.Empty;

                ws.SaveClientLog("ScanImage", ex.Message);
            }

            return image_path;
        }

        private static Bitmap ConvertBitmapFromDIB(IntPtr pDIB, IntPtr pPix)
        {
            MethodInfo method = typeof(Bitmap).GetMethod("FromGDIplus", BindingFlags.Static | BindingFlags.NonPublic);

            if (method == null) return null; // (permission problem)

            IntPtr bmp = IntPtr.Zero;
            int status = GdipCreateBitmapFromGdiDib(pDIB, pPix, out bmp);

            return ((status == 0) && (bmp != IntPtr.Zero)) ? (Bitmap)method.Invoke(null, new object[] { bmp }) : null;
        }
    }
}
