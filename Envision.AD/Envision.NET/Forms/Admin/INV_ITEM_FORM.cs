using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class INV_ITEM_FORM : MasterForm
    {
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();
        DataTable allloadtable = new DataTable();

        public INV_ITEM_FORM()//(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            //CloseControl = closecontrol;

            ProcessGetInvItem select = new ProcessGetInvItem();
            select.Invoke();
            gridControl1.DataSource = select.ResultTable.Copy();
            allloadtable = select.ResultTable.Copy();

            EnablePropertySetup(false);

            gridView1.BestFitColumns();
        }
        private void INV_ITEM_FORM_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {

                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                btnAdd.Text = "Save";

                ClearText();

                EnablePropertySetup(true);
            }
            else
            {
                if (!Control_Checking()) return;

                btnAdd_Process();
                btnCancel_Process();
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Process()
        {
            if (!Control_Checking()) return;

            using (ProcessAddInvItem insert = new ProcessAddInvItem())
            {
                INV_ITEM common = new INV_ITEM();
                common.ITEM_UID = txtUID.Text;
                common.ITEM_NAME = txtName.Text;
                common.ITEM_DESC = txtDescription.Text;

                try { common.RE_ORDER_DAYS = Convert.ToByte(txtReOrderDay.Value); }
                catch (Exception) { common.RE_ORDER_DAYS = 255; }
                common.RE_ORDER_QTY = Convert.ToDecimal(txtReOrderQty.Value);
                common.GL_CODE = Convert.ToInt32(txtGlCode.Value);
                common.PURCHASE_PRICE = Convert.ToDecimal(txtPurchase.Value);
                common.SELLING_PRICE = Convert.ToDecimal(txtSelling.Value);

                common.IS_FOREIGN = chkIsForeign.Checked ? 'Y' : 'N';
                common.INCLUDE_IN_AUTO_PR = chkInclude.Checked ? 'Y' : 'N';
                common.IS_FA = chkIsFa.Checked ? 'Y' : 'N';
                common.IS_REUSABLE = chkIsReusable.Checked ? 'Y' : 'N';
                common.ALLOW_PARTIAL_DELIVERY = chkAllowPartialDelivery.Checked ? 'Y' : 'N';
                common.ALLOW_PARTIAL_RECIEVE = chkAllowPartialRecieve.Checked ? 'Y' : 'N';

                common.ORG_ID = new GBLEnvVariable().OrgID;
                common.CATEGORY_ID = Convert.ToInt32(txtCategory1.Tag);
                common.VENDOR_ID = Convert.ToInt32(txtVendor1.Tag);
                common.TXN_UNIT = Convert.ToInt32(txtTxnUnit1.Tag);
                common.TYPE_ID = Convert.ToInt32(txtTypeID1.Tag);

                try
                {
                    ImageConverter imcon = new ImageConverter();
                    common.ITEM_IMG = (byte[])imcon.ConvertTo(pictureEdit1.Image, typeof(byte[]));
                }
                catch (Exception)
                {
                    common.ITEM_IMG = null;
                }

                common.REUSE_PRICE_PERC = Convert.ToDecimal(txtReusePrice.Text);
                try
                {
                    insert.INV_ITEM = common;
                    insert.Invoke();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Please, refill your information.", "Oops very sorry!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //mymsb.ShowAlert("UID1110", new GBLEnvVariable().CurrentLanguageID);
                    mymsb.ShowAlert("UID4006", new GBLEnvVariable().CurrentLanguageID);
                }
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                if (gridView1.RowCount == 0) return;

                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;
                
                btnEdit.Text = "Save";

                EnablePropertySetup(true);
            }
            else
            {
                if (!Control_Checking()) return;

                btnEdit_Process();
                btnCancel_Process();
                btnEdit.Text = "Edit";
            }
        }

        private void btnEdit_Process()
        {
            if (!Control_Checking()) return;

            using (ProcessUpdateInvItem update = new ProcessUpdateInvItem())
            {
                INV_ITEM common = new INV_ITEM();

                common.ITEM_ID = int.Parse(txtID.Text);
                common.ITEM_UID = txtUID.Text;
                common.ITEM_NAME = txtName.Text;
                common.ITEM_DESC = txtDescription.Text;

                try { common.RE_ORDER_DAYS = Convert.ToByte(txtReOrderDay.Value); }
                catch (Exception) { common.RE_ORDER_DAYS = 255; }
                common.RE_ORDER_QTY = Convert.ToDecimal(txtReOrderQty.Value);
                common.GL_CODE = Convert.ToInt32(txtGlCode.Value);
                common.PURCHASE_PRICE = Convert.ToDecimal(txtPurchase.Value);
                common.SELLING_PRICE = Convert.ToDecimal(txtSelling.Value);

                common.IS_FOREIGN = chkIsForeign.Checked ? 'Y' : 'N';
                common.INCLUDE_IN_AUTO_PR = chkInclude.Checked ? 'Y' : 'N';
                common.IS_FA = chkIsFa.Checked ? 'Y' : 'N';
                common.IS_REUSABLE = chkIsReusable.Checked ? 'Y' : 'N';
                common.ALLOW_PARTIAL_DELIVERY = chkAllowPartialDelivery.Checked ? 'Y' : 'N';
                common.ALLOW_PARTIAL_RECIEVE = chkAllowPartialRecieve.Checked ? 'Y' : 'N';

                common.ORG_ID = new GBLEnvVariable().OrgID;
                common.CATEGORY_ID = Convert.ToInt32(txtCategory1.Tag);
                common.VENDOR_ID = Convert.ToInt32(txtVendor1.Tag);
                common.TXN_UNIT = Convert.ToInt32(txtTxnUnit1.Tag);
                common.TYPE_ID = Convert.ToInt32(txtTypeID1.Tag);

                try
                {
                    ImageConverter imcon = new ImageConverter();
                    common.ITEM_IMG = (byte[])imcon.ConvertTo(pictureEdit1.Image, typeof(byte[]));
                }
                catch (Exception)
                {
                    common.ITEM_IMG = null;
                }

                common.REUSE_PRICE_PERC = Convert.ToDecimal(txtReusePrice.Text);

                try
                {
                    update.INV_ITEM = common;
                    update.Invoke();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Please, refill your information.","Oops very sorry!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    mymsb.ShowAlert("UID4006", new GBLEnvVariable().CurrentLanguageID);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_ITEM common = new INV_ITEM();
                common.ITEM_ID = int.Parse(txtID.Text);

                ProcessDeleteInvItem delete = new ProcessDeleteInvItem();
                delete.INV_ITEM = common;
                delete.Invoke();

                btnCancel_Process();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Process();
        }

        private void btnCancel_Process()
        {
            ClearText();

            ProcessGetInvItem select = new ProcessGetInvItem();
            select.Invoke();
            gridControl1.DataSource = select.ResultTable.Copy();
            allloadtable = select.ResultTable.Copy();

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            EnablePropertySetup(false);

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";

            gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);

            gridView1.BestFitColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.RemoveAt(index);
            this.Close();
        }

        private void NumericChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit sd = (DevExpress.XtraEditors.TextEdit)sender;

            if (e.KeyChar == (char)Keys.Back)
            {
                sd.Text = string.Empty;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            { 
                
            }
            else
            {
                string str = e.KeyChar.ToString();
                int outnum;
                if (!int.TryParse(str, out outnum))
                {
                    sd.Text = int.Parse(sd.Text).ToString();
                    e.Handled = true;
                }
            }
        }

        #region KeyPress Event

        //private void txtUID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtName.Focus();
        //}

        //private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtDescription.Focus();
        //}

        //private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtAuthLevel.Focus();
        //}

        //private void txtReOrderDay_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtReOrderQty.Focus();
        //}

        //private void txtReOrderQty_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtGlCode.Focus();
        //}

        //private void txtGlCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtFreqDay.Focus();
        //}

        //private void txtPurchase_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtSelling.Focus();
        //}

        //private void txtSelling_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        chkIsForeign.Focus();
        //}

        //private void chkIsForeign_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        chkInclude.Focus();
        //}

        //private void chkInclude_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        chkIsFa.Focus();
        //}

        //private void chkIsFa_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        chkIsReusable.Focus();
        //}

        //private void chkIsReusable_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        chkAllowPartialDelivery.Focus();
        //}

        //private void chkAllowPartialDelivery_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        chkAllowPartialRecieve.Focus();
        //}

        //private void chkAllowPartialRecieve_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //        txtTypeId.Focus();
        //}

        #endregion KeyPress Event

        private void btnchoosepic_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK) && !openFileDialog1.FileName.Trim().Equals(""))
            {
                this.pictureEdit1.Image = Image.FromFile(openFileDialog1.FileName.Trim());
            }
        }

        private void EnablePropertySetup(bool enable)
        {
            txtUID.Enabled = enable;
            txtName.Enabled = enable;
            txtDescription.Enabled = enable;

            //txtAuthLevel.Enabled = enable;
            txtReOrderQty.Enabled = enable;
            txtReOrderDay.Enabled = enable;

            txtGlCode.Enabled = enable;

            //txtFreqDay.Enabled = enable;
            txtSelling.Enabled = enable;
            txtPurchase.Enabled = enable;

            chkIsForeign.Enabled = enable;
            chkInclude.Enabled = enable;

            chkIsFa.Enabled = enable;
            chkIsReusable.Enabled = enable;

            chkAllowPartialDelivery.Enabled = enable;
            chkAllowPartialRecieve.Enabled = enable;

            btnchoosepic.Enabled = enable;

            txtSearch.Enabled = !enable;

            //btnOrgId.Enabled = enable;
            btnCategory.Enabled = enable;
            btnVendor.Enabled = enable;
            btnTxnUnit.Enabled = enable;

            btnTypeID.Enabled = enable;

            txtReusePrice.Enabled = enable;

            //gridControl1.Enabled = !enable;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                DataTable table = (DataTable)gridControl1.DataSource;
                DataRow row = table.Rows[e.FocusedRowHandle];

                AddNewText(row);
            }
        }

        private void gridView1_FocusedRowChanged(int focusrowhandle)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs param
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(focusrowhandle, focusrowhandle);
            gridView1_FocusedRowChanged(new Object(), param);
        }

        private void btnOrgId_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnOrgId_Clicks);

//            string qry = @"
//                            select
//                                ORG_ID,ORG_UID,ORG_NAME,ORG_ALIAS
//                            from
//                                GBL_ENV
//                            where 
//                                ORG_ID like '%%' OR ORG_UID like '%%' OR
//                                ORG_NAME like '%%' OR ORG_ALIAS like '%%'
//                            order by ORG_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Alias";
//            string con = "";
//            lv.getData(qry, fields, con, "Global Environtment");
//            lv.Show();
        }

        private void btnOrgId_Clicks(object sender,ValueUpdatedEventArgs e)
        {
            //string[] retValue = e.NewValue.Split(new Char[] { '^' });

            //txtOrdID1.Tag = retValue[0];
            //txtOrdID1.Text = retValue[1];
            //txtOrdID2.Text = retValue[2];
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnCategory_Clicks);

//            string qry = @"
//                            select
//                                CATEGORY_ID,CATEGORY_UID,CATEGORY_NAME,CATEGORY_DESC
//                            from
//                                dbo.INV_CATEGORY
//                            where 
//                                CATEGORY_ID like '%%' OR CATEGORY_UID like '%%' OR
//                                CATEGORY_NAME like '%%' OR CATEGORY_DESC like '%%'
//                            order by CATEGORY_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Description";
//            string con = "";
//            lv.getData(qry, fields, con, "Category List");
//            lv.Show();

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnCategory_Clicks);
            lv.AddColumn("CATEGORY_ID", "ID", false, true);
            lv.AddColumn("CATEGORY_UID", "Code", true, true);
            lv.AddColumn("CATEGORY_NAME", "Name", true, true);
            lv.AddColumn("CATEGORY_DESC", "Description", true, true);
            lv.Text = "Category List";

            //ProcessGetRISExamType pg = new ProcessGetRISExamType();
            //pg.Invoke();
            ProcessGetInvCategory getData = new ProcessGetInvCategory();
            getData.Invoke();
            lv.Data = getData.ResultTable;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }

        private void btnCategory_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtCategory1.Tag = retValue[0];
            txtCategory1.Text = retValue[1];
            txtCategory2.Text = retValue[2];
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnVendor_Clicks);

//            string qry = @"
//                            select
//                                VENDOR_ID,VENDOR_UID,VENDOR_NAME,ORG_ID
//                            from
//                                INV_VENDOR
//                            where 
//                                VENDOR_ID like '%%' OR VENDOR_UID like '%%' OR
//                                VENDOR_NAME like '%%' OR ORG_ID like '%%'
//                            order by VENDOR_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Org ID";
//            string con = "";
//            lv.getData(qry, fields, con, "Vendor List");
//            lv.Show();

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnVendor_Clicks);
            lv.AddColumn("VENDOR_ID", "ID", false, true);
            lv.AddColumn("VENDOR_UID", "Code", true, true);
            lv.AddColumn("VENDOR_NAME", "Name", true, true);
            lv.Text = "Vendor List";

            ProcessGetInvVendor getData = new ProcessGetInvVendor();
            getData.Invoke();
            lv.Data = getData.ResultTable;
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }

        private void btnVendor_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtVendor1.Tag = retValue[0];
            txtVendor1.Text = retValue[1];
            txtVendor2.Text = retValue[2];
        }

        private void btnTxnUnit_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnTxnUnit_Clicks);

//            string qry = @"
//                            select
//                                TXN_UNIT_ID,TXN_UNIT_UID,TXN_UNIT_NAME,TXN_UNIT_DESC
//                            from
//                                dbo.INV_TXNUNIT
//                            where 
//                                TXN_UNIT_ID like '%%' OR TXN_UNIT_UID like '%%' OR
//                                TXN_UNIT_NAME like '%%' OR TXN_UNIT_DESC like '%%'
//                            order by TXN_UNIT_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Org ID";
//            string con = "";
//            lv.getData(qry, fields, con, "TXN List");
//            lv.Show();

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnTxnUnit_Clicks);
            lv.AddColumn("TXN_UNIT_ID", "ID", false, true);
            lv.AddColumn("TXN_UNIT_UID", "Code", true, true);
            lv.AddColumn("TXN_UNIT_NAME", "Name", true, true);
            lv.AddColumn("TXN_UNIT_DESC", "Description", true, true);
            lv.Text = "TXN List";

            ProcessGetInvTxnunit getData = new ProcessGetInvTxnunit();
            getData.Invoke();
            lv.Data = getData.ResultTable;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }

        private void btnTxnUnit_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtTxnUnit1.Tag = retValue[0];
            txtTxnUnit1.Text = retValue[1];
            txtTxnUnit2.Text = retValue[2];
        }

        private void btnTypeID_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnTypeID_Clicks);

//            string qry = @"
//                            select
//                                ITEMTYPE_ID,ITEMTYPE_UID,ITEMTYPE_NAME,ITEMTYPE_DESC
//                            from
//                                dbo.INV_ITEMTYPE
//                            where 
//                                ITEMTYPE_ID like '%%' OR ITEMTYPE_UID like '%%' OR
//                                ITEMTYPE_NAME like '%%' OR ITEMTYPE_DESC like '%%'
//                            order by ITEMTYPE_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Org ID";
//            string con = "";
//            lv.getData(qry, fields, con, "TXN List");
//            lv.Show();

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnTypeID_Clicks);
            lv.AddColumn("ITEMTYPE_ID", "ID", false, true);
            lv.AddColumn("ITEMTYPE_UID", "Code", true, true);
            lv.AddColumn("ITEMTYPE_NAME", "Name", true, true);
            lv.AddColumn("ITEMTYPE_DESC", "Description", true, true);
            lv.Text = "ItemType List";

            ProcessGetInvItemtype getData = new ProcessGetInvItemtype();
            getData.Invoke();
            lv.Data = getData.ResultTable;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }

        private void btnTypeID_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtTypeID1.Tag = retValue[0];
            txtTypeID1.Text = retValue[1];
            txtTypeID2.Text = retValue[2];
        }

        private void AddNewText(DataRow row)
        {
            try
            {
                txtID.Text = row["ITEM_ID"].ToString();
                txtUID.Text = row["ITEM_UID"].ToString();
                txtName.Text = row["ITEM_NAME"].ToString();
                txtDescription.Text = row["ITEM_DESC"].ToString();

                try
                {
                    ImageConverter convert = new ImageConverter();
                    pictureEdit1.Image = (Image)convert.ConvertFrom(row["ITEM_IMG"]);
                }
                catch { }

                txtCategory1.Tag = row["CATEGORY_ID"];
                txtCategory1.Text = row["CATEGORY_UID"].ToString();
                txtCategory2.Text = row["CATEGORY_NAME"].ToString();

                txtTypeID1.Tag = row["TYPE_ID"];
                txtTypeID1.Text = row["ITEMTYPE_UID"].ToString();
                txtTypeID2.Text = row["ITEMTYPE_NAME"].ToString();

                txtTxnUnit1.Tag = row["TXN_UNIT"];
                txtTxnUnit1.Text = row["TXN_UNIT_UID"].ToString();
                txtTxnUnit2.Text = row["TXN_UNIT_NAME"].ToString();

                txtReOrderDay.Text = row["RE_ORDER_DAYS"].ToString();
                txtReOrderQty.Text = row["RE_ORDER_QTY"].ToString();

                chkIsForeign.Checked = row["IS_FOREIGN"].Equals("Y") ? true : false;
                chkInclude.Checked = row["INCLUDE_IN_AUTO_PR"].Equals("Y") ? true : false;

                txtGlCode.Text = row["GL_CODE"].ToString();
                chkIsFa.Checked = row["IS_FA"].Equals("Y") ? true : false;

                chkIsReusable.Checked = row["IS_REUSABLE"].Equals("Y") ? true : false;
                txtReusePrice.Text = row["REUSE_PRICE_PERC"].ToString();

                txtVendor1.Tag = row["VENDOR_ID"];
                txtVendor1.Text = row["VENDOR_UID"].ToString();
                txtVendor2.Text = row["VENDOR_NAME"].ToString();

                txtPurchase.Text = row["PURCHASE_PRICE"].ToString();
                txtSelling.Text = row["SELLING_PRICE"].ToString();

                chkAllowPartialDelivery.Checked = row["ALLOW_PARTIAL_DELIVERY"].Equals("Y") ? true : false;
                chkAllowPartialRecieve.Checked = row["ALLOW_PARTIAL_RECIEVE"].Equals("Y") ? true : false;

                //txtOrdID1.Tag = row["ORG_ID"];
                //txtOrdID1.Text = row["ORG_UID"].ToString();
                //txtOrdID2.Text = row["ORG_NAME"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
   
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtUID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";

            //ImageConverter convert = new ImageConverter();
            //pictureEdit1.Image = (Image)convert.ConvertFrom(row["ITEM_IMG"]);

            txtCategory1.Tag = null;
            txtCategory1.Text = "";
            txtCategory2.Text = "";

            txtTypeID1.Tag = null;
            txtTypeID1.Text = "";
            txtTypeID2.Text = "";

            txtTxnUnit1.Tag = null;
            txtTxnUnit1.Text = "";
            txtTxnUnit2.Text = "";

            txtReOrderDay.Text = "";
            txtReOrderQty.Text = "";

            chkIsForeign.Checked = false;
            chkInclude.Checked = false;

            txtGlCode.Text = "";
            chkIsFa.Checked = false;

            chkIsReusable.Checked = false;
            txtReusePrice.Text = "";

            txtVendor1.Tag = null;
            txtVendor1.Text = "";
            txtVendor2.Text = "";

            txtPurchase.Text = "";
            txtSelling.Text = "";

            chkAllowPartialDelivery.Checked = false;
            chkAllowPartialRecieve.Checked = false;

            //txtOrdID1.Tag = null;
            //txtOrdID1.Text = "";
            //txtOrdID2.Text = "";

            pictureEdit1.Image = null;
        }

        private void txtSearch_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            TextSearching();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextSearching();
            }
        }

        private void TextSearching()
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                using (ProcessGetInvItem select = new ProcessGetInvItem())
                {
                    select.Invoke();
                    gridControl1.DataSource = select.ResultTable.Copy();
                }
            }
            else
            {
                string key = txtSearch.Text.Trim();
                string queryString;

                txtSearch.Text = key;
                key = "'" + key + "%'";

                queryString =
                @"SELECT it.*, 
			        ca.CATEGORY_UID,ca.CATEGORY_NAME,
				        ty.ITEMTYPE_UID,ty.ITEMTYPE_NAME,
					        tx.TXN_UNIT_UID,tx.TXN_UNIT_NAME,
						        ve.VENDOR_UID,ve.VENDOR_NAME,
							        en.ORG_UID,en.ORG_NAME " +
	            @"FROM INV_ITEM it
			            left join INV_CATEGORY ca on it.CATEGORY_ID=ca.CATEGORY_ID
			            left join INV_ITEMTYPE ty on it.TYPE_ID = ty.ITEMTYPE_ID
			            left join INV_TXNUNIT tx on it.TXN_UNIT = tx.TXN_UNIT_ID
			            left join INV_VENDOR ve on it.VENDOR_ID = ve.VENDOR_ID
			            left join GBL_ENV en on it.ORG_ID = en.ORG_ID " +

                @"WHERE ITEM_UID like "+key+@"
			                OR ITEM_NAME like "+key+@"
				                OR ca.CATEGORY_UID like "+key+@"
					                OR ca.CATEGORY_NAME like "+key+@";";


                gridControl1.DataSource = DataBase_Query(queryString);
            }
        }

        private DataTable DataBase_Query(string queryString)
        {
            string connectionString = ConfigurationSettings.AppSettings["connStr"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = new SqlCommand(queryString, connection);
                adapter.Fill(dataset);

                return dataset.Tables[0];
            }

        }

        private bool Control_Checking()
        {
            if (
                    txtName.Text.Trim().Equals("")
                    //|| txtUID.Text.Trim().Equals("")
                    || txtCategory1.Tag == null
                    || txtVendor1.Tag == null
                    || txtTxnUnit1.Tag == null
                    || txtTypeID1.Tag == null
                )
            {
                //MessageBox.Show("Infor. incomplete!", "not complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mymsb.ShowAlert("UID4006", new GBLEnvVariable().CurrentLanguageID);
                return false;
            }

            return true;
        }

    }
}