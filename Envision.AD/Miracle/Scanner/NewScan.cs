using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracle.Scanner
{
    public partial class NewScan : DevExpress.XtraBars.Ribbon.RibbonForm, IMessageFilter  
    {
        private bool msgfilter;
        private Twain tw;
        private int picnumber;
        private PointerStruct[] pIXBmp;

        public NewScan(PointerStruct[] PictureStruct)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            btnSaveClose.Enabled = false;
            tw = new Twain();
            tw.Init(this.Handle);
            if (PictureStruct == null)
                PictureStruct = PointerStruct.GetPointerStruct();
            else if(PictureStruct.Length==0)
                PictureStruct = PointerStruct.GetPointerStruct();
            pIXBmp = PictureStruct;
            initImage();
            btnScan.Focus();
        }

        public bool PreFilterMessage(ref Message m)
        {
            TwainCommand cmd = tw.PassMessage(ref m);
            if (cmd == TwainCommand.Not)
                return false;

            switch (cmd)
            {
                case TwainCommand.CloseRequest:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.CloseOk:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.DeviceEvent:
                    {
                        break;
                    }
                case TwainCommand.TransferReady:
                    {
                        ArrayList pics = tw.TransferPictures();
                        EndingScan();
                        tw.CloseSrc();
                        //for (int i = 0; i < pics.Count; i++)
                        //{
                            //IntPtr img = (IntPtr)pics[i];
                            //PictureForm newpic = new PictureForm(img);
                            //newpic.MdiParent = this;
                            //int picnum = tabMain.Pages.Count;
                            //newpic.Text = "Picture" + picnum;
                            ////pix.Add(newpic.PIX);
                            ////bmp.Add(newpic.BMP);
                            //pIXBmp[i].Pix = newpic.PIX;
                            //pIXBmp[i].Bmp = newpic.BMP;
                            //newpic.Show();
                        //}
                        picnumber++;
                        IntPtr img = (IntPtr)pics[0];
                        PictureForm newpic = new PictureForm(img);
                        newpic.MdiParent = this;
                        int picnum = tabMain.Pages.Count;
                        newpic.Text = "Picture" + picnum;
                        pIXBmp[picnumber - 1].Pix = newpic.PIX;
                        pIXBmp[picnumber - 1].Bmp = newpic.BMP;
                        newpic.IndexImage = picnumber - 1;
                        newpic.Show();

                        if (tabMain.Pages.Count==PointerStruct.MaxScanner){
                            btnScan.Enabled = false;
                        }
                        btnSaveClose.Focus();
                        break;

                    }
            }

            return true;
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            tw.Select();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            if(tabMain.Pages.Count>=PointerStruct.MaxScanner)
            {
                btnScan.Enabled = false;
                return;
            }
            if (!msgfilter)
            {
                this.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            bool flag = tw.Acquire(true);
            if (!flag)
                EndingScan();
            btnSaveClose.Enabled = true;
           
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

        private void EndingScan()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
                this.Enabled = true;
                this.Activate();
            }
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