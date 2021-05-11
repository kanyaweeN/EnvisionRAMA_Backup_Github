using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;
using RIS.Common;

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using RIS.Common.Common;


namespace RIS.Forms.Admin
{
    public partial class PatientStatusN : Form
    {
        private string Ribbon;
        private int GN;  //grid number
        RIS.Forms.GBLMessage.MyMessageBox msg = new RIS.Forms.GBLMessage.MyMessageBox();
        RIS.Common.Common.GBLEnvVariable env = new RIS.Common.Common.GBLEnvVariable();
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        
        public PatientStatusN(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
        }

        private void PatientStatusN_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            ProcessGetRISPatstatusN gePat = new ProcessGetRISPatstatusN();
            gePat.RISPatstatus.SELECTCASE = 0;
            gePat.Invoke();
            grdContrl.DataSource = gePat.ResultSet.Tables[0];
            SetGridColumns();

            Ribbon = "Views";

            groupControl2.Enabled = false;
            groupControl2.Text = "Views";
            SetNull();
        }
        private void SetGridColumns()
        {
            views.OptionsBehavior.Editable = false;
            views.OptionsSelection.EnableAppearanceFocusedCell = false;

            views.Columns["STATUS_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            views.Columns["STATUS_ID"].Visible = false ;
            views.Columns["STATUS_ID"].Caption = "ID";
            views.Columns["STATUS_ID"].OptionsColumn.ReadOnly = true; ;

            views.Columns["STATUS_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            views.Columns["STATUS_UID"].Visible = true;
            views.Columns["STATUS_UID"].Caption = "UID";
            views.Columns["STATUS_UID"].OptionsColumn.ReadOnly = true;

            views.Columns["STATUS_TEXT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            views.Columns["STATUS_TEXT"].Visible = true;
            views.Columns["STATUS_TEXT"].Caption = "STATUS TEXT";
            views.Columns["STATUS_TEXT"].OptionsColumn.ReadOnly = true;


            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = FormatType.Custom;
            chk.Click += new EventHandler(chk_Click);

            views.Columns["IS_ACTIVE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            views.Columns["IS_ACTIVE"].Visible = false ;
            views.Columns["IS_ACTIVE"].Caption = "IS_ACTIVE";
            views.Columns["IS_ACTIVE"].ColumnEdit = chk;
            views.Columns["IS_ACTIVE"].OptionsColumn.ReadOnly = true;

            views.Columns["ORG_ID"].Visible = false;
            views.Columns["CREATED_BY"].Visible = false;
            views.Columns["CREATED_ON"].Visible = false;
            views.Columns["LAST_MODIFIED_BY"].Visible = false;
            views.Columns["LAST_MODIFIED_ON"].Visible = false;
            views.Columns["IS_DEFAULT"].Visible = false;

            //views.Columns["STATUS_ID"].ReadOnly = true;

        }
        private void chk_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            DataTable dtg = (DataTable)grdContrl.DataSource;
            dtg.Rows[views.FocusedRowHandle]["IS_ACTIVE"] = chk.Checked ? "N" : "Y";
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Navigator_Click(object sender, EventArgs e)
        {

        }

        private void brClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void brHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < CloseControl.TabPages.Count; i++)
            {
                if (CloseControl.TabPages[i].Title == "Home")
                {
                    CloseControl.TabPages[i].Selected = true;
                    return;
                }
            }
            RIS.Forms.Main.frmMainTab frm = new RIS.Forms.Main.frmMainTab(this.CloseControl);
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }

        private void brBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl2.Enabled = true;
            groupControl2.Text = "NEW";
            lblStatus.Text = "AUTO";

            SetNull();


            Ribbon = "NEW";
            btnSave.Text = "Save";

            txtUID.Focus();


        }
        private void SetNull()
        {
            lblStatus.Text = "";
            txtStatusText.Text = "";
            txtUID.Text = "";
            chkActive.Checked = false;
            chkDefault.Checked = false;
        }
        private void brBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl2.Enabled = true;
            groupControl2.Text = "Update";
            grdContrl.Enabled = true;
            Ribbon = "Edit";
            btnSave.Text = "Update";
            txtUID.Focus();
        }
        private void brBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl2.Enabled = true;
            groupControl2.Text = "Delete";

            grdContrl.Enabled = true;
            Ribbon = "Delete";
            btnSave.Text = "Delete";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUID.Text.Trim() == "")
            {
                msg.ShowAlert("UID4006",new GBLEnvVariable().CurrentLanguageID);
                txtUID.Focus();
                return;
            }
            if (Ribbon == "NEW")
            {
                ProcessGetRISPatstatusN gePatN = new ProcessGetRISPatstatusN();
                gePatN.RISPatstatus.SELECTCASE = 1;
                gePatN.RISPatstatus.STATUS_UID = txtUID.Text.Trim();
                gePatN.Invoke();
                if (gePatN.ResultSet.Tables[0].Rows.Count != 0)
                {
                    msg.ShowAlert("UID4005", new GBLEnvVariable().CurrentLanguageID);
                    txtUID.Focus();
                    return;
                }
                string id = msg.ShowAlert("UID4001", new GBLEnvVariable().CurrentLanguageID);


                if (id == "2")
                {
                    ProcessAddRISPatstatusN adPat = new ProcessAddRISPatstatusN();
                    adPat.RISPatstatus.STATUS_UID = txtUID.Text;
                    adPat.RISPatstatus.STATUS_TEXT = txtStatusText.Text;
                    if (chkActive.Checked == true)
                    {
                        adPat.RISPatstatus.IsActive = "Y";
                    }
                    else if (chkActive.Checked == false)
                    {
                        if (chkDefault.Checked == false)
                        {
                            adPat.RISPatstatus.IsActive = "N"; 
                        }
                        else if (chkDefault.Checked == true)
                        {
                            adPat.RISPatstatus.IsActive = "Y";
                        }
                    }
                    adPat.RISPatstatus.ORG_ID = 1;
                    adPat.RISPatstatus.CREATED_BY = env.UserID;
                    adPat.RISPatstatus.LAST_MODIFIED_BY = env.UserID;

                    switch (chkDefault.Checked)
                    {
                        case true: adPat.RISPatstatus.IS_DEFAULT = "Y";
                            DataTable dtgNew = (DataTable)grdContrl.DataSource;
                            dtgNew.AcceptChanges();
                            for (int n = 0; n < dtgNew.Rows.Count; n++)
                            {
                                ProcessUpdateRISPatstatus upPatNew = new ProcessUpdateRISPatstatus();

                                upPatNew.RISPatstatus.IS_DEFAULT = "N";
                                upPatNew.RISPatstatus.STATUS_ID = Convert.ToInt32(dtgNew.Rows[n]["STATUS_ID"]);
                                upPatNew.RISPatstatus.STATUS_UID = dtgNew.Rows[n]["STATUS_UID"].ToString();
                                upPatNew.RISPatstatus.STATUS_TEXT = dtgNew.Rows[n]["STATUS_TEXT"].ToString();
                                upPatNew.RISPatstatus.ORG_ID = Convert.ToInt32(dtgNew.Rows[n]["ORG_ID"]);
                                upPatNew.RISPatstatus.IsActive = dtgNew.Rows[n]["IS_ACTIVE"].ToString();
                                upPatNew.RISPatstatus.LAST_MODIFIED_BY = env.UserID;
                                upPatNew.Invoke();
                            }
                            dtgNew.AcceptChanges();
                            break;
                        case false: adPat.RISPatstatus.IS_DEFAULT = "N"; break;
                    }

                    adPat.Invoke();

                   
                    BindData();
                }
            }
            else if (Ribbon == "Edit")
            {
                DataTable dtgEd = (DataTable)grdContrl.DataSource;
                if (dtgEd.Rows[GN]["STATUS_UID"].ToString() != txtUID.Text)
                {
                    ProcessGetRISPatstatusN gePatN = new ProcessGetRISPatstatusN();
                    gePatN.RISPatstatus.SELECTCASE = 1;
                    gePatN.RISPatstatus.STATUS_UID = txtUID.Text.Trim();
                    gePatN.Invoke();
                    if (gePatN.ResultSet.Tables[0].Rows.Count != 0)
                    {
                        msg.ShowAlert("UID4005", new GBLEnvVariable().CurrentLanguageID);
                        txtUID.Focus();
                        return;
                    } 
                }
                string up = msg.ShowAlert("UID4002",new GBLEnvVariable().CurrentLanguageID);
                if (up == "2")
                {
                    ProcessUpdateRISPatstatus upPat = new ProcessUpdateRISPatstatus();
                    upPat.RISPatstatus.STATUS_ID = Convert.ToInt32(lblStatus.Text);
                    upPat.RISPatstatus.STATUS_UID = txtUID.Text;
                    upPat.RISPatstatus.STATUS_TEXT = txtStatusText.Text;
                    if (chkActive.Checked == true)
                    {
                        upPat.RISPatstatus.IsActive = "Y"; 
                    }
                    else if (chkActive.Checked == false)
                    {
                        if (chkDefault.Checked == false)
                        {
                            upPat.RISPatstatus.IsActive = "N"; 
                        }
                        else if (chkDefault.Checked == true)
                        {
                            upPat.RISPatstatus.IsActive = "Y"; 
                        }
                    }
                    upPat.RISPatstatus.ORG_ID = 1;
                    upPat.RISPatstatus.LAST_MODIFIED_BY = env.UserID;

                    switch (chkDefault.Checked)
                    {
                        case true: upPat.RISPatstatus.IS_DEFAULT = "Y";
                            DataTable dtgUp = (DataTable)grdContrl.DataSource;
                            dtgUp.AcceptChanges();
                            for (int n = 0; n < dtgUp.Rows.Count; n++)
                            {
                                ProcessUpdateRISPatstatus upPatUP = new ProcessUpdateRISPatstatus();

                                upPatUP.RISPatstatus.IS_DEFAULT = "N";
                                upPatUP.RISPatstatus.STATUS_ID = Convert.ToInt32(dtgUp.Rows[n]["STATUS_ID"]);
                                upPatUP.RISPatstatus.STATUS_UID = dtgUp.Rows[n]["STATUS_UID"].ToString();
                                upPatUP.RISPatstatus.STATUS_TEXT = dtgUp.Rows[n]["STATUS_TEXT"].ToString();
                                upPatUP.RISPatstatus.ORG_ID = Convert.ToInt32(dtgUp.Rows[n]["ORG_ID"]);
                                upPatUP.RISPatstatus.IsActive = dtgUp.Rows[n]["IS_ACTIVE"].ToString();
                                upPatUP.RISPatstatus.LAST_MODIFIED_BY = env.UserID;
                                upPatUP.Invoke();
                            }
                            dtgUp.AcceptChanges();
                            break;
                        case false: upPat.RISPatstatus.IS_DEFAULT = "N"; break;
                    }
                    upPat.Invoke();
                    BindData();
                }
            }
            else if (Ribbon == "Delete")
            {
                string del = msg.ShowAlert("UID4003",new GBLEnvVariable().CurrentLanguageID);
                if (del == "2")
                {
                    ProcessDeleteRISPatstatus delPat = new ProcessDeleteRISPatstatus();
                    delPat.RISPatstatus.STATUS_ID = Convert.ToInt32(lblStatus.Text);
                    delPat.Invoke();

                    ProcessGetRISPatstatusN gePatDel = new ProcessGetRISPatstatusN();
                    gePatDel.RISPatstatus.SELECTCASE = 0;
                    gePatDel.Invoke();
                    grdContrl.DataSource = gePatDel.ResultSet.Tables[0];
                    SetGridColumns();
                    //BindData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BindData();
        }
        private void views_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Ribbon != "NEW")
            {
                if (e.FocusedRowHandle >= 0)
                {
                    GN = e.FocusedRowHandle;

                    DataTable dtg = (DataTable)grdContrl.DataSource;
                    DataTable dtt = dtg.Copy();
                    dtt.AcceptChanges();

                    lblStatus.Text = dtt.Rows[GN]["STATUS_ID"].ToString();
                    txtStatusText.Text = dtt.Rows[GN]["STATUS_TEXT"].ToString();
                    txtUID.Text = dtt.Rows[GN]["STATUS_UID"].ToString();
                    if (dtt.Rows[GN]["IS_ACTIVE"].ToString() == "Y")
                    {
                        chkActive.Checked = true;
                    }
                    else if (dtt.Rows[GN]["IS_ACTIVE"].ToString() == "N")
                    {
                        chkActive.Checked = false;
                    }


                    if (dtt.Rows[GN]["IS_DEFAULT"].ToString() == "Y")
                    {
                        chkDefault.Checked = true;
                    }
                    else if (dtt.Rows[GN]["IS_DEFAULT"].ToString() == "N")
                    {
                        chkDefault.Checked = false;
                    }
                } 
            }
        }

        private void txtUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtStatusText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void chkActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void chkDefault_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

    }
}