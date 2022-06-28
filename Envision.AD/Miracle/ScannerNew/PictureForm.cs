using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Miracle.Scanner
{
    public partial class PictureForm : Form
    { 
        BITMAPINFOHEADER bmi;
        Rectangle bmprect;
        IntPtr dibhand;
        IntPtr bmpptr;
        IntPtr pixptr;

        public PictureForm(IntPtr dibhandp)
        {
            InitializeComponent();

            bmprect = new Rectangle(0, 0, 0, 0);
            dibhand = dibhandp;
            bmpptr = GlobalLock(dibhand);
            pixptr = GetPixelInfo(bmpptr);
            this.AutoScrollMinSize = new System.Drawing.Size(bmprect.Width, bmprect.Height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle cltrect = ClientRectangle;
            Rectangle clprect = e.ClipRectangle;
            Point scrol = AutoScrollPosition;

            Rectangle realrect = clprect;
            realrect.X -= scrol.X;
            realrect.Y -= scrol.Y;

            SolidBrush brbg = new SolidBrush(Color.Black);
            if (realrect.Right > bmprect.Width)
            {
                Rectangle bgri = clprect;
                int ovri = bmprect.Width - realrect.X;
                if (ovri > 0)
                {
                    bgri.X += ovri;
                    bgri.Width -= ovri;
                }
                e.Graphics.FillRectangle(brbg, bgri);
            }

            if (realrect.Bottom > bmprect.Height)
            {
                Rectangle bgbo = clprect;
                int ovbo = bmprect.Height - realrect.Y;
                if (ovbo > 0)
                {
                    bgbo.Y += ovbo;
                    bgbo.Height -= ovbo;
                }
                e.Graphics.FillRectangle(brbg, bgbo);
            }

            realrect.Intersect(bmprect);
            if (!realrect.IsEmpty)
            {
                int bot = bmprect.Height - realrect.Bottom;
                IntPtr hdc = e.Graphics.GetHdc();
                SetDIBitsToDevice(hdc, clprect.X, clprect.Y, realrect.Width, realrect.Height,
                        realrect.X, bot, 0, bmprect.Height, pixptr, bmpptr, 0);
                e.Graphics.ReleaseHdc(hdc);
            }
        }

        protected IntPtr GetPixelInfo(IntPtr bmpptr)
        {
            try
            {
                bmi = new BITMAPINFOHEADER();
                Marshal.PtrToStructure(bmpptr, bmi);

                bmprect.X = bmprect.Y = 0;
                bmprect.Width = bmi.biWidth;
                bmprect.Height = bmi.biHeight;

                if (bmi.biSizeImage == 0)
                    bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

                int p = bmi.biClrUsed;
                if ((p == 0) && (bmi.biBitCount <= 8))
                    p = 1 << bmi.biBitCount;
                p = (p * 4) + bmi.biSize + (int)bmpptr;
                return (IntPtr)p;
            }
            catch { }
            return (IntPtr)0;
        }
        public IntPtr BMP { get { return bmpptr; } }
        public IntPtr PIX { get { return pixptr; } }
        public int IndexImage { get; set; }

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst,int width, int height, int xsrc, int ysrc, int start, int lines,IntPtr bitsptr, IntPtr bmiptr, int color);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string outstr);


        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal class BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }
    }
}