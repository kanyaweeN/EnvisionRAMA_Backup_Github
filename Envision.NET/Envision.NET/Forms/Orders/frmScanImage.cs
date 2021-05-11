using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracle.Scanner;
using Miracle.Util;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
namespace Envision.NET.Forms.Orders
{
    public partial class frmScanImage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();

        public frmScanImage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private bool getDemographicData()
        {
            bool flag = false;
            ProcessGetRISOrder proc = new ProcessGetRISOrder();
            DataSet ds = proc.GetOrderByScan(txtHN.Text.Trim());
            if (Utilities.IsHaveData(ds) && ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                flag = true;
                txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                grdLookUpOrder.Properties.DisplayMember = "ORDER_ID";
                grdLookUpOrder.Properties.ValueMember = "ORDER_ID";
                grdLookUpOrder.Properties.DataSource = ds.Tables[1].DefaultView;
                grdLookUpOrder.Properties.View.Columns[0].Caption = "ID";
                grdLookUpOrder.Properties.View.Columns[1].Caption = "Order Date";
                grdLookUpOrder.Properties.View.Columns[2].Caption = "Exam Name";
                grdLookUpOrder.Properties.View.Columns[1].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                grdLookUpOrder.Properties.View.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                grdLookUpOrder.Properties.View.Columns[0].Width = 50;
                grdLookUpOrder.Properties.View.Columns[1].Width = 100;
                grdLookUpOrder.Properties.View.Columns[2].Width = 80;

                grdLookUpOrder.EditValue = ds.Tables[1].Rows[0][0].ToString();
            }
            return flag;
        }
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHN.Text.Trim().Length == 0)
                {
                    txtAccession.Focus();
                    return;
                }
                if (getDemographicData())
                    grdLookUpOrder.Focus();
                else
                {
                    msg.ShowAlert("UID009", env.CurrentLanguageID);
                    txtName.Text = string.Empty;
                    grdLookUpOrder.Properties.DataSource = null;
                    txtHN.Focus();
                }
            }
        }
        private void grdLookUpOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtName.Text.Trim().Length > 0)
                    openImageForm(Convert.ToInt32(grdLookUpOrder.EditValue), txtHN.Text.Trim());
                else
                    txtAccession.Focus();
            }
        }

        private void openImageForm(int orderId, string hn)
        {
            DataView dv_scan_image = new ScanImages().GetData(0, orderId);

            diagUploadFile diag = new diagUploadFile(dv_scan_image, false);
            if (diag.ShowDialog() == DialogResult.OK)
            {
                dv_scan_image = diag.OrderImages;
                new ScanImages().Invoke(txtHN.Text.Trim(), 0, Convert.ToInt32(grdLookUpOrder.EditValue), dv_scan_image);
            }
            else if (diag.ShowDialog() == DialogResult.Abort)
            {
                PointerStruct[] p = PointerStruct.GetPointerStruct();
                PointerStruct.ImageUrl = env.PacsUrl2;
                string mode = "Edit";

                ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
                process.RIS_ORDERIMAGE.ORDER_ID = orderId;
                process.RIS_ORDERIMAGE.SCHEDULE_ID = 0;
                process.Invoke();
                DataTable dtOrderImage = new DataTable();
                dtOrderImage = process.Result.Tables[0].Copy();
                if (dtOrderImage.Rows.Count > 0)
                {
                    Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(dtOrderImage, env.PixPicture);
                    editFrm.StartPosition = FormStartPosition.CenterScreen;
                    editFrm.ShowDialog();
                    if (editFrm.DialogResult == DialogResult.Yes)
                    {
                        env.PixPicture = editFrm.PictureStruct;
                        dtOrderImage = editFrm.Data;
                    }
                    else
                    {
                        txtAccession.Focus();
                        return;
                    }
                }
                else
                {
                    mode = "New";
                    Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                        env.PixPicture = frm.PictureStruct;
                    else
                    {
                        txtAccession.Focus();
                        return;
                    }
                }
                ScanImage save = null;
                if (mode == "New")
                    save = new ScanImage(hn, orderId);
                else
                    save = new ScanImage(hn, orderId, dtOrderImage);
                env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
                this.Close();
            }
        }
        private void openFromAccession()
        {
            ProcessGetRISOrderdtl processOrd = new ProcessGetRISOrderdtl();
            DataSet ds = processOrd.GetPreview(txtAccession.Text.Trim());
            if (Utilities.IsHaveData(ds))
            {
                int order_id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                string hn = ds.Tables[0].Rows[0]["HN"].ToString().Trim();
                openImageForm(order_id, hn);
            }
            else
            {
                msg.ShowAlert("UID009", env.CurrentLanguageID);
                txtAccession.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtHN.Text.Trim().Length > 0)
            {
                openImageForm(Convert.ToInt32(grdLookUpOrder.EditValue), txtHN.Text.Trim());
            }
            else
            {
                #region Search by Accession Number.
                if (txtAccession.Text.Trim().Length == 0)
                {
                    txtAccession.Focus();
                    return;
                }
                openFromAccession();
                #endregion
            }
        }

        private void txtAccession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txtAccession.Text.Trim().Length > 0)
                    openFromAccession();
                else
                    btnOK.Focus();
        }
    }
}
