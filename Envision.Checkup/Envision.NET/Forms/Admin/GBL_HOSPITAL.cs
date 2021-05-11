using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common.UtilityClass;
using RIS.Forms.GBLMessage;
namespace RIS.Forms.Admin
{
    public partial class GBL_HOSPITAL : Form
    {
        private DBUtility dbu;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataTable dtt;
        private BindingSource bs;
        private MyMessageBox msg = new MyMessageBox();
        private string mode = "new";

        public GBL_HOSPITAL() {
            InitializeComponent();
            initControl();
            initBinding();
        }
        public GBL_HOSPITAL(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
            initControl();
            initBinding();
        }

        #region ToolStrip.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            setReadOnlyTextBox(false);
            setButtonEnabled(false);
            mode = "new";
            textUID.Focus();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            setReadOnlyTextBox(false);
            setButtonEnabled(false);
            mode = "edit";
            textUID.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str=msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2") {
                deleteData();
                setButtonEnabled(true);
                setReadOnlyTextBox(true);
                lblHos.Text = "*";
                lblHos.Visible = false;
                lblUID.Text = "*";
                lblUID.Visible = false;
                lbDiscount.Text = "*";
                lbDiscount.Visible = false;
                initControl();
                initBinding();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButtonEnabled(true);
            setReadOnlyTextBox(true);
            lblHos.Text = "*";
            lblHos.Visible = false;
            lblUID.Text = "*";
            lblUID.Visible = false;
            lbDiscount.Text = "*";
            lbDiscount.Visible = false;
            initControl();
            initBinding();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Require Check.
            if (textUID.Text.Trim().Length == 0)
            {
                lblUID.Visible = true;
                textUID.Focus();
                return;
            }
            else
                lblUID.Visible = false;
            if (textHospital.Text.Trim().Length == 0)
            {
                lblHos.Visible = true;
                textHospital.Focus();
                return;
            }
            else
                lblHos.Visible = false;

            try
            {
                int dc = Convert.ToInt32(textDiscount.Text);
                if (dc < 0)
                {
                    lbDiscount.Text = "ระบุตัวเลข '0-99'";
                    lbDiscount.Visible = true;
                    textDiscount.Focus();
                    return; 
                }
            }
            catch 
            {
                lbDiscount.Text = "ระบุตัวเลข '0-99'";
                lbDiscount.Visible = true;
                textDiscount.Focus();
                return; 
            }
            //check uid duplicate
            DataRow[] dr= dtt.Select(" HOS_UID='" + textUID.Text + "'");
            if (mode == "new")
            {
                if (dr.Length > 0)
                {
                    lblUID.Text = "ข้อมูลซ้ำ";
                    lblUID.Visible = true;
                    return;
                }
            }else { 
                if (dr.Length > 0) { 
                    DataRow[] ori=dtt.Select(" HOS_ID=" + textUID.Tag.ToString() );
                    foreach (DataRow d in ori)
                    {
                        if (textUID.Text.Trim() != d["HOS_UID"].ToString().Trim())
                        {
                            lblUID.Text = "ข้อมูลซ้ำ";
                            lblUID.Visible = true;
                            return;
                        }
                        break;
                    }
                }
            }
            #endregion

            string str = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                if (mode == "new")
                    saveData();
                else
                    updateData();
                setButtonEnabled(true);
                setReadOnlyTextBox(true);
                lblHos.Text = "*";
                lblHos.Visible = false;
                lblUID.Text = "*";
                lblUID.Visible = false;
                lbDiscount.Text = "*";
                lbDiscount.Visible = false;
                initControl();
                initBinding();
            }
        } 
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseControl != null)
            {
                dbu = new DBUtility();
                dbu.CloseFrom(CloseControl, this);
            }
            else
                this.Close();
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            //bs.MoveFirst();
        }
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
          //  bs.MovePrevious();
        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
           // bs.MoveNext();
        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            //bs.MoveLast();
        }
        #endregion

        #region KeyBoard Event.
        private void textUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textHospital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        } 
        #endregion

        private void initControl() {
            textUID.Text = string.Empty;
            textHospital.Text = string.Empty;
            textAlias.Text = string.Empty;
            textPhoneNo.Text = string.Empty;
            textDesc.Text = string.Empty;
            textDiscount.Text = "0";

            textUID.Properties.ReadOnly = true;
            textHospital.Properties.ReadOnly = true;
            textAlias.Properties.ReadOnly = true;
            textPhoneNo.Properties.ReadOnly = true;
            textDesc.Properties.ReadOnly = true;
            textDiscount.Properties.ReadOnly = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
        private void initBinding() 
        {
            dtt = new DataTable();
            bs = new BindingSource();

            ProcessGetGBLHospital process = new ProcessGetGBLHospital();
            process.Invoke();
            dtt = process.Result.Tables[0].Copy();
            bs.DataSource = dtt;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            bindingNavigator1.BindingSource = bs;

            if (dtt.Rows.Count == 0)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMoveLastItem.Enabled = false;
                bindingNavigatorMoveNextItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorPositionItem.Enabled = false;
                btnAdd.Enabled = true;
            }
            else
            {
                setNavigator();
                bs.MoveNext();
                bs.MoveFirst();
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorPositionItem.Enabled = true;
            }
        }
        private void clearInContext() {
            textUID.DataBindings.Clear();
            textHospital.DataBindings.Clear();
            textAlias.DataBindings.Clear();
            textPhoneNo.DataBindings.Clear();
            textDesc.DataBindings.Clear();
            textDiscount.DataBindings.Clear();

            textUID.Tag = null;
            textUID.Text = string.Empty;
            textHospital.Text = string.Empty;
            textAlias.Text = string.Empty;
            textPhoneNo.Text = string.Empty;
            textDesc.Text = string.Empty;
            textDiscount.Text = "0";
        }
        private void setNavigator() {
            clearInContext();

            textUID.DataBindings.Add("Tag", bs, "HOS_ID");
            textUID.DataBindings.Add("Text", bs, "HOS_UID");
            textHospital.DataBindings.Add("Text", bs, "HOS_NAME");
            textAlias.DataBindings.Add("Text", bs, "HOS_NAME_ALIAS");
            textPhoneNo.DataBindings.Add("Text", bs, "PHONE_NO");
            textDesc.DataBindings.Add("Text", bs, "DESCR");
            textDiscount.DataBindings.Add("Text", bs, "PERCENT_DISCOUNT");
         
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        void bs_PositionChanged(object sender, EventArgs e)
        {
           // setNavigator();
        }
       
        private void setReadOnlyTextBox(bool flag) {
            textUID.Properties.ReadOnly = flag;
            textHospital.Properties.ReadOnly = flag;
            textAlias.Properties.ReadOnly = flag;
            textPhoneNo.Properties.ReadOnly = flag;
            textDesc.Properties.ReadOnly = flag;
            textDiscount.Properties.ReadOnly = flag;
        }
        private void setButtonEnabled(bool flag) {
            btnAdd.Visible = flag;
            btnEdit.Visible = flag;
            btnDelete.Visible = flag;
            btnClose.Visible = flag;
            btnSave.Visible = !flag;
            btnCancel.Visible = !flag;
            bindingNavigatorMoveFirstItem.Enabled = flag;
            bindingNavigatorMoveLastItem.Enabled = flag;
            bindingNavigatorMoveNextItem.Enabled = flag;
            bindingNavigatorMovePreviousItem.Enabled = flag;
            bindingNavigatorPositionItem.Enabled = flag;
        }
        private void saveData() {
            ProcessAddGBLHospital process = new ProcessAddGBLHospital();
            process.GBLHospital.HOS_UID = textUID.Text;
            process.GBLHospital.HOS_NAME = textHospital.Text;
            process.GBLHospital.HOS_NAME_ALIAS = textAlias.Text;
            process.GBLHospital.PHONE_NO = textPhoneNo.Text;
            process.GBLHospital.DESCR = textDesc.Text;
            process.GBLHospital.ORG_ID = new GBLEnvVariable().OrgID;
            process.GBLHospital.CREATED_BY = new GBLEnvVariable().UserID;
            process.GBLHospital.PERCENT_DISCOUNT = Convert.ToInt32(textDiscount.Text);
            process.Invoke();
          
        }
        private void updateData() {
            ProcessUpdateGBLHospital process = new ProcessUpdateGBLHospital();
            process.GBLHospital.HOS_ID = Convert.ToInt32(textUID.Tag.ToString());
            process.GBLHospital.HOS_UID = textUID.Text;
            process.GBLHospital.HOS_NAME = textHospital.Text;
            process.GBLHospital.HOS_NAME_ALIAS = textAlias.Text;
            process.GBLHospital.PHONE_NO = textPhoneNo.Text;
            process.GBLHospital.DESCR = textDesc.Text;
            process.GBLHospital.ORG_ID = new GBLEnvVariable().OrgID;
            process.GBLHospital.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            process.GBLHospital.PERCENT_DISCOUNT = Convert.ToInt32(textDiscount.Text);
            process.Invoke();
        }
        private void deleteData() {
            ProcessDeleteGBLHospital process = new ProcessDeleteGBLHospital();
            process.GBLHospital.HOS_ID = Convert.ToInt32(textUID.Tag.ToString());
            process.Invoke();
        }

    }
}