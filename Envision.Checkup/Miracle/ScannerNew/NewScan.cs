using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.WinFroms;
using Miracle.ScannerNew;

namespace Miracle.Scanner
{
    public partial class NewScan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Twain tw;
        private int picnumber;
        private PointerStruct[] pIXBmp;
        private ScanSettings twSetting;

        public NewScan(PointerStruct[] PictureStruct)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            btnSaveClose.Enabled = false;

            try
            {
                tw = new Twain(new WinFormsWindowMessageHook(this));
                tw.TransferImageIntPtr += new EventHandler<TransferImageIntPtrEventArgs>(tw_TransferImageIntPtr);
                tw.ScanningComplete += new EventHandler<ScanningCompleteEventArgs>(tw_ScanningComplete);
            }
            catch (Exception ex)
            {
                btnSelectSource.Enabled = false;
                btnScan.Enabled = false;
                btnSaveClose.Enabled = false;
                //MessageBox.Show(ex.Message, ex.Source);
                MessageBox.Show("Your Scanner device was not found.", "Unpluging Scanner device.");
            }

            if (PictureStruct == null)
                PictureStruct = PointerStruct.GetPointerStruct();
            else if(PictureStruct.Length==0)
                PictureStruct = PointerStruct.GetPointerStruct();
            pIXBmp = PictureStruct;
            initImage();
            btnScan.Focus();


        }

        private void tw_TransferImageIntPtr(object sender, TransferImageIntPtrEventArgs e)
        {
            //ArrayList pics = tw.TransferPictures();
            //EndingScan();
            //tw.CloseSrc();
            picnumber++;
            IntPtr img = e.ImageIntPtr;//(IntPtr)pics[0];
            PictureForm newpic = new PictureForm(img);
            newpic.MdiParent = this;
            int picnum = tabMain.Pages.Count;
            newpic.Text = "Picture" + picnum;
            pIXBmp[picnumber - 1].Pix = newpic.PIX;
            pIXBmp[picnumber - 1].Bmp = newpic.BMP;
            newpic.IndexImage = picnumber - 1;
            newpic.Show();

            if (tabMain.Pages.Count == PointerStruct.MaxScanner)
            {
                btnScan.Enabled = false;
            }
            //btnSaveClose.Focus();
        }
        private void tw_ScanningComplete(object sender, ScanningCompleteEventArgs e)
        {
            btnSaveClose.Enabled = true;
            Enabled = true;
            btnSaveClose.Focus();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            tw.SelectSource();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            if(tabMain.Pages.Count>=PointerStruct.MaxScanner)
            {
                btnScan.Enabled = false;
                return;
            }

            twSetting = new ScanSettings();
            twSetting.Resolution = new ResolutionSettings();
            twSetting.Resolution.Dpi = 100;
            twSetting.Resolution.ColourSetting = ColourSetting.GreyScale;

            try
            {
                tw.StartScanning(twSetting);
            }
            catch (TwainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void initImage() {
            int j = 0;
            for (int i = 0; i < PointerStruct.MaxScanner; i++)
            {
                if (tabMain.Pages.Count >= PointerStruct.MaxScanner) break;
                if (pIXBmp[i].Bmp != IntPtr.Zero) {
                    PictureForm frm = new PictureForm(pIXBmp[i].Bmp);
                    frm.MdiParent = this;
                    j++;
                    frm.Text="Picture" + j.ToString();
                    frm.IndexImage = j - 1;
                    frm.Show();
                }
            }
            for (int i = 0; i < tabMain.Pages.Count; i++)
            {
                int count = i + 1;
                tabMain.Pages[i].Text = "Picture" + count.ToString();
            }
            picnumber = tabMain.Pages.Count;
            if (tabMain.Pages.Count == PointerStruct.MaxScanner)
            {
                btnScan.Enabled = false;
                btnSaveClose.Enabled = false;
            }
        }
        private void tabMain_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            picnumber--;
            PictureForm newpic = (PictureForm)e.Page.MdiChild;
            if (newpic.IndexImage == 0)
            {
                for (int i = 1; i < PointerStruct.MaxScanner; i++)
                {
                    pIXBmp[i - 1].Bmp = pIXBmp[i].Bmp;
                    pIXBmp[i - 1].Pix = pIXBmp[i].Pix;
                }
            }
            else if (newpic.IndexImage < PointerStruct.MaxScanner)
            {
                for (int i = newpic.IndexImage; i < PointerStruct.MaxScanner; i++)
                {
                    int index = i + 1;
                    if (index >= PointerStruct.MaxScanner)
                        index = PointerStruct.MaxScanner - 1;

                    pIXBmp[i].Bmp = pIXBmp[index].Bmp;
                    pIXBmp[i].Pix = pIXBmp[index].Pix;
                }
            }
            pIXBmp[PointerStruct.MaxScanner - 1].Bmp = IntPtr.Zero;
            pIXBmp[PointerStruct.MaxScanner - 1].Pix = IntPtr.Zero;
            for (int i = 0; i < tabMain.Pages.Count; i++)
            {
                int index = i + 1;
                tabMain.Pages[i].Text = "Picture" + index.ToString();
            }
            if (tabMain.Pages.Count < PointerStruct.MaxScanner)
            {
                btnScan.Enabled = true;
                btnSaveClose.Enabled = true;
            }
        }

        public PointerStruct[] PictureStruct {
            get { return pIXBmp; }
        }
        public int ImageCount {
            get { return tabMain.Pages.Count; }
        }
    }
}