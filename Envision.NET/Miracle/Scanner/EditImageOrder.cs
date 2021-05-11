using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace Miracle.Scanner
{
    public partial class EditImageOrder : DevExpress.XtraBars.Ribbon.RibbonForm, IMessageFilter  //  DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataView dv;
        private bool msgfilter;
        private Twain tw;
        private int picnumber;
        private bool isResizeForm;

        private DataTable dttImg;
        private DataTable dttBefore;
        private PointerStruct[] pIXBmp;

        public EditImageOrder(DataTable tableImage, PointerStruct[] PictureStruct) {
            InitializeComponent();
            picnumber = 0;
            isResizeForm = false;
            tw = new Twain();
            tw.Init(this.Handle);
            if (PictureStruct == null)
                PictureStruct = PointerStruct.GetPointerStruct();
            else if (PictureStruct.Length == 0)
                PictureStruct = PointerStruct.GetPointerStruct();
            pIXBmp = PictureStruct;
            dttImg = tableImage.Copy();
            dttBefore = tableImage.Copy();
            OrderImageDelete = new List<int>();
            initControl();
        }

        #region Scan Work 
        bool IMessageFilter.PreFilterMessage(ref Message m)
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
                        picnumber++;
                        if (picnumber >= PointerStruct.MaxScanner) btnScan.Enabled = false;
                        explanScanForm();
                        IntPtr img = (IntPtr)pics[0];
                        PictureForm newpic = new PictureForm(img);
                        pIXBmp[picnumber - 1].Bmp = newpic.BMP;
                        pIXBmp[picnumber - 1].Pix = newpic.PIX;
                        newpic.IndexImage = picnumber - 1;
                        int count = tabMain.Pages.Count;
                        count++;
                        newpic.Text = "ScanPass " + count.ToString();
                        newpic.MdiParent = this;
                        newpic.Show();
                        btnSaveAndClose.Enabled = true;
                        break;
                    }
            }
            if (tabMain.Pages.Count >= PointerStruct.MaxScanner) btnScan.Enabled = false;
            return true;
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
        #endregion

        private void initControl() {
            btnSaveAndClose.Enabled = false;
            setGridImage();
            bool flag = false;
            for (int i = 0; i < PointerStruct.MaxScanner; i++)
            {
                if (pIXBmp[i].Bmp != IntPtr.Zero)
                {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                for (int i = 0; i < PointerStruct.MaxScanner; i++) {
                    if (pIXBmp[i].Bmp != IntPtr.Zero)
                    {
                        picnumber++;
                        PictureForm newpic = new PictureForm(pIXBmp[i].Bmp);
                        newpic.IndexImage = picnumber - 1;
                        newpic.MdiParent = this;
                        newpic.Show();
                    }
                    if (tabMain.Pages.Count >= PointerStruct.MaxScanner) break;
                }
                enableDisableScan();
                explanScanForm();
                for (int i = 0; i < tabMain.Pages.Count; i++)
                {
                    int index = i + 1;
                    tabMain.Pages[i].Text = "ScanPass " + index.ToString();
                }
            }
            if (picnumber >= PointerStruct.MaxScanner)
            {
                btnScan.Enabled = false;
                btnSaveAndClose.Enabled = false;
            }
        }
        private void setGridImage()
        {
            if (dv == null) {
                DataTable dttTmp = dttImg.Copy();
                dttTmp.Columns.Add("colDelete");
                foreach (DataRow dr in dttTmp.Rows)
                {
                    dr["colDelete"] = "N";
                    if (string.IsNullOrEmpty(dr["IS_DELETED"].ToString())) dr["IS_DELETED"] = "N";
                }
                dttTmp.AcceptChanges();
                dv = new DataView(dttTmp);
            }

            dv.RowFilter = "IS_DELETED<>'Y'";
            grdImage.DataSource = dv;
            //picnumber = dv.Table.Rows.Count;
            picnumber = dv.Count;
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;
            view1.Columns["SL_NO"].OptionsColumn.ReadOnly = true;
            view1.Columns["SL_NO"].Visible = true;
            view1.Columns["SL_NO"].Caption = "SL No.";
            view1.Columns["SL_NO"].BestFit();

            RepositoryItemHyperLinkEdit link = new RepositoryItemHyperLinkEdit();
            link.Click += new EventHandler(link_Click);
            view1.Columns["IMAGE_NAME"].Caption = "Image File Name";
            view1.Columns["IMAGE_NAME"].Visible = true;
            view1.Columns["IMAGE_NAME"].Width = 200;
            view1.Columns["IMAGE_NAME"].ColumnEdit = link;
           


            view1.Columns["CREATED_ON"].Caption = "Create Date";
            view1.Columns["CREATED_ON"].Visible = true;
            view1.Columns["CREATED_ON"].OptionsColumn.ReadOnly = true;
            view1.Columns["CREATED_ON"].BestFit();

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDeleteRow_Click);
            view1.Columns["colDelete"].ColumnEdit = btn;
            view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["colDelete"].Width = 50;
            view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["colDelete"].Visible = true;
            view1.Columns["colDelete"].Caption =" ";

            enableDisableScan();
        }
        private void explanScanForm() {
            if (!isResizeForm)
            {
                isResizeForm = true;
                Size s = new Size(654, 518);
                this.Size = s;
                this.CenterToScreen();
            }
        }
        private void collapseScanForm() {
            this.CenterToScreen();
            isResizeForm = false;
            Size s = new Size(467, 235);
            this.Size = s;
            this.CenterToScreen();
        }
        private void enableDisableScan() {
            int count = view1.RowCount;
            count += tabMain.Pages.Count;
            btnScan.Enabled = true;
            btnSaveAndClose.Enabled = true;
            if (count >= PointerStruct.MaxScanner)
            {
                btnScan.Enabled = false;
                btnSaveAndClose.Enabled = false;
            }
        }

        private void link_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                if (dr != null)
                {
                    string url = PointerStruct.ImageUrl + "/" + dr["IMAGE_NAME"].ToString();
                    System.Diagnostics.Process.Start(url);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            #region OLDCODE.
            //DataRow drN = view1.GetDataRow(view1.FocusedRowHandle);
            //if (MessageBox.Show("Do you want to delete?", "Alert", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{

            //    ProcessUpdateRISOrderimages upImage = new ProcessUpdateRISOrderimages();
            //    upImage.RISOrderimages.ORDER_IMAGE_ID = Convert.ToInt32(drN["ORDER_IMAGE_ID"].ToString());
            //    upImage.RISOrderimages.LAST_MODIFIED_BY = env.UserID;
            //    upImage.RISOrderimages.IS_DELETED = "Y";
            //    upImage.Invoke();

            //    DataTable dtImage = new DataTable();

            //        ProcessGetRISOrderimages geImage = new ProcessGetRISOrderimages();
            //        if (string.IsNullOrEmpty(drN["ORDER_ID"].ToString()))
            //            geImage.RISOrderimages.ORDER_ID = 0;
            //        else
            //            geImage.RISOrderimages.ORDER_ID = Convert.ToInt32(drN["ORDER_ID"].ToString());

            //        geImage.RISOrderimages.SCHEDULE_ID = -1;
            //        geImage.Invoke();

            //        dtImage = geImage.Result.Tables[0];
            //    dv = new DataView(dtImage);
            //}
            //SetGridImage(); 
            #endregion

            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            if (row != null) {
                if (MessageBox.Show("Do you want to delete?", "Delete Image", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int id = Convert.ToInt32(row["ORDER_IMAGE_ID"].ToString());
                    OrderImageDelete.Add(id);
                    row["IS_DELETED"] = "Y";


                    foreach (DataRow dr in dttImg.Rows)
                        if (dr["ORDER_IMAGE_ID"].ToString() == id.ToString())
                        {
                            dr["IS_DELETED"] = "Y";
                            break;
                        }
                    dttImg.AcceptChanges();
                    //dv = new DataView(dttImg);
                }
                setGridImage();
            }
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!msgfilter)
            {
                this.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            bool flag = tw.Acquire(true);
            if(!flag)
                EndingScan();
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            OrderImageDelete = new List<int>();
            this.Close();
        }
        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            tw.Select();
        }
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            for (int i = 0; i < dttImg.Rows.Count; i++)
                dttBefore.Rows[i]["IS_DELETED"] = dttImg.Rows[i]["IS_DELETED"];

            Close();
        }
        private void tabMain_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            enableDisableScan();
            if (tabMain.Pages.Count == 0)
                collapseScanForm();
            picnumber--;
            if (picnumber < PointerStruct.MaxScanner) {
                btnScan.Enabled = true;
                btnSaveAndClose.Enabled = true;
            }

            PictureForm newpic = (PictureForm)e.Page.MdiChild;
            if (newpic.IndexImage == 0) {
                for (int i = 1; i < PointerStruct.MaxScanner; i++) {
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
                tabMain.Pages[i].Text = "ScanPass " + index.ToString();
            }
        }
        private void tabMain_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
           // PictureForm newpic = (PictureForm)e.Page;
           
        }


        public DataTable Data {
            get
            {
                return dttBefore;
            }
        }
        public PointerStruct[] PictureStruct
        {
            get { return pIXBmp; }
        }
        public List<int> OrderImageDelete { get; set; }

        public DataTable DataBack { get; set; }
        public int ImageCount {
            get { return picnumber; }
        }
       
    }
}