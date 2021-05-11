using System;
using System.Drawing;

namespace TwainDotNet
{
    public class TransferImageEventArgs : EventArgs
    {
        public Bitmap Image { get; private set; }
        public bool ContinueScanning { get; set; }

        public TransferImageEventArgs(Bitmap image, bool continueScanning)
        {
            this.Image = image;
            this.ContinueScanning = continueScanning;
        }
    }

    public class TransferImageIntPtrEventArgs : EventArgs
    {
        public IntPtr ImageIntPtr { get; private set; }
        public bool ContinueScanning { get; set; }

        public TransferImageIntPtrEventArgs(IntPtr imageIntPtr, bool continueScanning)
        {
            this.ImageIntPtr = imageIntPtr;
            this.ContinueScanning = continueScanning;
        }
    }
}
