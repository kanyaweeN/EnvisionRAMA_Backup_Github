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
    public partial class RIS_OperatorNoteItem : Form
    {
        private DBUtility dbu;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataTable dtt;
        private BindingSource bs;
        private MyMessageBox msg = new MyMessageBox();
        private string mode = "new";

        public RIS_OperatorNoteItem() {
            InitializeComponent();
            initControl();
            initBinding();
        }
        public RIS_OperatorNoteItem(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
            initControl();
            initBinding();
        }
        #region ToolStrip.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked == true)
                chkActive.Tag = (object)"Y";
            else
                chkActive.Tag = (object)"N";

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
            string str = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                deleteData();
                setButtonEnabled(true);
                setReadOnlyTextBox(true);
                lblUID.Text = "*";
                lblUID.Visible = false;
                lbUnit.Visible = false;
                initControl();
                initBinding();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButtonEnabled(true);
            setReadOnlyTextBox(true);
            lblUID.Text = "*";
            lblUID.Visible = false;
            lbUnit.Visible = false;
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
            if (textItemname.Text.Trim().Length == 0)
            {
                textItemname.Focus();
                return;
            }
            if (txtUnit.Text.Length == 0)
            {
                lbUnit.Visible = true;
                btnLookUpUnit.Focus();
                return;
            }
            //check uid duplicate
            DataRow[] dr = dtt.Select(" OP_ITEM_UID='" + textUID.Text + "'");
            if (mode == "new")
            {
                if (dr.Length > 0)
                {
                    lblUID.Text = "ข้อมูลซ้ำ";
                    lblUID.Visible = true;
                    return;
                }
               
            }
            else
            {
                if (dr.Length > 0)
                {
                    DataRow[] ori = dtt.Select(" OP_ITEM_ID=" + textUID.Tag.ToString());
                    foreach (DataRow d in ori)
                    {
                        if (textUID.Text.Trim() != d["OP_ITEM_UID"].ToString().Trim())
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
                lblUID.Text = "*";
                lblUID.Visible = false;
                lbUnit.Visible = false;
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

        private void initControl()
        {
            textUID.Text = string.Empty;
            textItemname.Text = string.Empty;

            textUID.Properties.ReadOnly = true;
            textItemname.Properties.ReadOnly = true;

            txtUnit.Properties.ReadOnly = true;

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

            ProcessGetRISOpnoteitem process = new ProcessGetRISOpnoteitem();
            //ProcessGetGBLHospital process = new ProcessGetGBLHospital();
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
        private void clearInContext()
        {
            textUID.DataBindings.Clear();
            textItemname.DataBindings.Clear();
            txtUnit.DataBindings.Clear();
            chkActive.DataBindings.Clear();

            textUID.Tag = null;
            textUID.Text = string.Empty;
            textItemname.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtUnit.Tag = null;
            chkActive.Tag = string.Empty;
        }
        private void setNavigator()
        {
            clearInContext();

            textUID.DataBindings.Add("Tag", bs, "OP_ITEM_ID");
            textUID.DataBindings.Add("Text", bs, "OP_ITEM_UID");
            textItemname.DataBindings.Add("Text", bs, "OP_ITEM_NAME");
            txtUnit.DataBindings.Add("Text", bs, "UNIT_NAME");
            txtUnit.DataBindings.Add("Tag", bs, "UNIT_ID");
            chkActive.DataBindings.Add("Tag", bs, "IS_ACTIVE");
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        void bs_PositionChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds = (BindingSource)sender;
            if (dtt.Rows.Count > 0)
            {
                try
                {
                    dtt = (DataTable)bds.DataSource;
                    string Status = dtt.Rows[bds.Position]["IS_ACTIVE"].ToString();
                    if (Status == "Y")
                        chkActive.Checked = true;
                    else
                        chkActive.Checked = false;
                }
                catch { }
            }
        }

        private void setReadOnlyTextBox(bool flag)
        {
            textUID.Properties.ReadOnly = flag;
            textItemname.Properties.ReadOnly = flag;
        }
        private void setButtonEnabled(bool flag)
        {
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
        private void saveData()
        {
            ProcessAddRISOpnoteitem process = new ProcessAddRISOpnoteitem();
            process.RISOpnoteitem = new RIS.Common.RISOpnoteitem();
            process.RISOpnoteitem.OP_ITEM_UID = textUID.Text;
            process.RISOpnoteitem.OP_ITEM_NAME = textItemname.Text;
            process.RISOpnoteitem.UNIT_ID = Convert.ToInt32(txtUnit.Tag.ToString());
            process.RISOpnoteitem.IS_ACTIVE = chkActive.Tag.ToString();
            process.RISOpnoteitem.CREATED_BY = new GBLEnvVariable().UserID;
            process.RISOpnoteitem.LAST_MODIFIED_BY = process.RISOpnoteitem.CREATED_BY;
            process.Invoke();

        }
        private void updateData()
        {
            ProcessUpdateRISOpnoteitem process = new ProcessUpdateRISOpnoteitem();
            process.RISOpnoteitem = new RIS.Common.RISOpnoteitem();
            process.RISOpnoteitem.OP_ITEM_ID = Convert.ToInt32(textUID.Tag.ToString());
            process.RISOpnoteitem.OP_ITEM_UID = textUID.Text;
            process.RISOpnoteitem.OP_ITEM_NAME = textItemname.Text;
            process.RISOpnoteitem.UNIT_ID = Convert.ToInt32(txtUnit.Tag.ToString());
            process.RISOpnoteitem.IS_ACTIVE = chkActive.Tag.ToString();
            process.RISOpnoteitem.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            process.Invoke();
        }
        private void deleteData()
        {
            ProcessDeleteRISOpnoteitem process = new ProcessDeleteRISOpnoteitem();
            process.RISOpnoteitem.OP_ITEM_ID = Convert.ToInt32(textUID.Tag.ToString());
            process.RISOpnoteitem.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            process.Invoke();
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked == true)
                chkActive.Tag = (object)"Y";
            else
                chkActive.Tag = (object)"N";

        }

        private void btnLookUpUnit_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lvNo_ValueUpdated);
            string qry = @"
                        SELECT     UNIT_ID, UNIT_UID, UNIT_NAME
                        FROM         HR_UNIT
                        where 
                            ORG_ID = 1 AND
                            UNIT_NAME like '%%'
                        order by UNIT_NAME desc
                        ";
            string fields = "UNIT_ID,UNIT_UID,UNIT_NAME";
            string con = "";
            lv.getData(qry, fields, con, "Unit Name Search");
            lv.Show();
        }
        private void lvNo_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtUnit.Text = retValue[2];
            txtUnit.Tag = (object)retValue[0];

            //int Unit;

            //try { Unit = Convert.ToInt32(txtUnit.Tag); }
            //catch { return; }
        }
    }
}