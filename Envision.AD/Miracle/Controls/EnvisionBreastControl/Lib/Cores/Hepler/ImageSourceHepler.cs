///
/// PJ. Miracle (Ton) 4/12/2010
/// 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing.Drawing2D;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System;
namespace EnvisionBreastControl.Lib.Cores.Helper
{
    public class ImageSourceHepler
    {
        public static string ImageName { get; private set; }
        public static string ImagePath { get; private set; }

        public static ImageSource GetImageSourceFromUrl(string Url)
        {
            ImageName = System.IO.Path.GetFileName(Url);
            ImagePath = Url;
            ImageSourceConverter converter = new ImageSourceConverter();
            return converter.ConvertFromString(Url) as ImageSource;   
        }
        public static ImageSource GetImageSourceFromDropData(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap, true))
            {
                var bm = e.Data.GetData(DataFormats.Bitmap, true);
                var interopBitmap = bm as System.Windows.Interop.InteropBitmap;
                if (interopBitmap != null)
                {
                    return interopBitmap;
                }

                var bitmap = bm as System.Drawing.Bitmap;
                if (bitmap != null)
                {
                    return CreateBitmapSource(bitmap);
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                var bmp = new BitmapImage(new Uri("file:///" + fileNames[0].Replace("\\", "/")));
                ImageName = System.IO.Path.GetFileName(fileNames[0]);
                ImagePath = fileNames[0];
                return bmp;
            }
            return null;
        }
        public static System.Drawing.Bitmap CreateBitmap(BitmapSource source)
        {
            using (var memoryStream = new MemoryStream())
            {
                var bitmapEncoder = new BmpBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(source));
                bitmapEncoder.Save(memoryStream);
                memoryStream.Position = 0;
                return new System.Drawing.Bitmap(memoryStream);
            }
        }

        public static BitmapSource CreateBitmapSource(System.Drawing.Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSource bmpSrc = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero,
              Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            return bmpSrc;
        }
        
        /// <summary>
        /// Import gdi32 dll
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
    }
}
