using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic;
using Envision.Common;

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;


namespace Envision.NET.Forms.Admin
{
    public partial class PatientStatusN : Envision.NET.Forms.Main.MasterForm
    {
        private string Ribbon;
        private int GN;  //grid number
        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        
        //public PatientStatusN(UUL.ControlFrame.Controls.TabControl clsCtl)
        //{
        //    InitializeComponent();
        //    this.CloseControl = clsCtl;
        //}
        public PatientStatusN()
        {
            InitializeComponent();
            //this.CloseControl = clsCtl;
        }

        private void PatientStatusN_Load(object sender, EventArgs e)
        {
            BindData();
            base.CloseWaitDialog();
        }
        private void BindData()
        {
            ProcessGetRISPatstatusN gePat = new ProcessGetRISPatstatusN();
            gePat.RIS_PATSTATUS.SELECTCASE = 0;
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
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.RemoveAt(index);
            this.Close();
        }

        private void brHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
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
            if (views.RowCount > 0)
            {
                groupControl2.Enabled = true;
                groupControl2.Text = "Update";
                grdContrl.Enabled = true;
                Ribbon = "Edit";
                btnSave.Text = "Update";
                txtUID.Focus();

                #region select first rows
                if (views.FocusedRowHandle > -1)
                    GN = views.FocusedRowHandle;
                else
                    GN = 0;

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
                #endregion
            }
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
                gePatN.RIS_PATSTATUS.SELECTCASE = 1;
                gePatN.RIS_PATSTATUS.STATUS_UID = txtUID.Text.Trim();
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
                    adPat.RIS_PATSTATUS.STATUS_UID = txtUID.Text;
                    adPat.RIS_PATSTATUS.STATUS_TEXT = txtStatusText.Text;
                    if (chkActive.Checked == true)
                    {
                        adPat.RIS_PATSTATUS.IS_ACTIVE = 'Y';
                    }
                    else if (chkActive.Checked == false)
                    {
                        if (chkDefault.Checked == false)
                        {
                            adPat.RIS_PATSTATUS.IS_ACTIVE = 'N'; 
                        }
                        else if (chkDefault.Checked == true)
                        {
                            adPat.RIS_PATSTATUS.IS_ACTIVE = 'Y';
                        }
                    }
                    adPat.RIS_PATSTATUS.ORG_ID = 1;
                    adPat.RIS_PATSTATUS.CREATED_BY = env.UserID;
                    adPat.RIS_PATSTATUS.LAST_MODIFIED_BY = env.UserID;

                    switch (chkDefault.Checked)
                    {
                        case true: adPat.RIS_PATSTATUS.IS_DEFAULT = 'Y';
                            DataTable dtgNew = (DataTable)grdContrl.DataSource;
                            dtgNew.AcceptChanges();
                            for (int n = 0; n < dtgNew.Rows.Count; n++)
                            {
                                ProcessUpdateRISPatstatus upPatNew = new ProcessUpdateRISPatstatus();

                                upPatNew.RIS_PATSTATUS.IS_DEFAULT = 'N';
                                upPatNew.RIS_PATSTATUS.STATUS_ID = Convert.ToInt32(dtgNew.Rows[n]["STATUS_ID"]);
                                upPatNew.RIS_PATSTATUS.STATUS_UID = dtgNew.Rows[n]["STATUS_UID"].ToString();
                                upPatNew.RIS_PATSTATUS.STATUS_TEXT = dtgNew.Rows[n]["STATUS_TEXT"].ToString();
                                upPatNew.RIS_PATSTATUS.ORG_ID = Convert.ToInt32(dtgNew.Rows[n]["ORG_ID"]);
                                upPatNew.RIS_PATSTATUS.IS_ACTIVE = char.Parse(dtgNew.Rows[n]["IS_ACTIVE"].ToString());
                                upPatNew.RIS_PATSTATUS.LAST_MODIFIED_BY = env.UserID;
                                upPatNew.Invoke();
                            }
                            dtgNew.AcceptChanges();
                            break;
                        case false: adPat.RIS_PATSTATUS.IS_DEFAULT = 'N'; break;
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
                    gePatN.RIS_PATSTATUS.SELECTCASE = 1;
                    gePatN.RIS_PATSTATUS.STATUS_UID = txtUID.Text.Trim();
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
                    upPat.RIS_PATSTATUS.STATUS_ID = Convert.ToInt32(lblStatus.Text);
                    upPat.RIS_PATSTATUS.STATUS_UID = txtUID.Text;
                    upPat.RIS_PATSTATUS.STATUS_TEXT = txtStatusText.Text;
                    if (chkActive.Checked == true)
                    {
                        upPat.RIS_PATSTATUS.IS_ACTIVE = 'Y'; 
                    }
                    else if (chkActive.Checked == false)
                    {
                        if (chkDefault.Checked == false)
                        {
                            upPat.RIS_PATSTATUS.IS_ACTIVE = 'N'; 
                        }
                        else if (chkDefault.Checked == true)
                        {
                            upPat.RIS_PATSTATUS.IS_ACTIVE = 'Y'; 
                        }
                    }
                    upPat.RIS_PATSTATUS.ORG_ID = 1;
                    upPat.RIS_PATSTATUS.LAST_MODIFIED_BY = env.UserID;

                    switch (chkDefault.Checked)
                    {
                        case true: upPat.RIS_PATSTATUS.IS_DEFAULT = 'Y';
                            DataTable dtgUp = (DataTable)grdContrl.DataSource;
                            dtgUp.AcceptChanges();
                            for (int n = 0; n < dtgUp.Rows.Count; n++)
                            {
                                ProcessUpdateRISPatstatus upPatUP = new ProcessUpdateRISPatstatus();

                                upPatUP.RIS_PATSTATUS.IS_DEFAULT = 'N';
                                upPatUP.RIS_PATSTATUS.STATUS_ID = Convert.ToInt32(dtgUp.Rows[n]["STATUS_ID"]);
                                upPatUP.RIS_PATSTATUS.STATUS_UID = dtgUp.Rows[n]["STATUS_UID"].ToString();
                                upPatUP.RIS_PATSTATUS.STATUS_TEXT = dtgUp.Rows[n]["STATUS_TEXT"].ToString();
                                upPatUP.RIS_PATSTATUS.ORG_ID = Convert.ToInt32(dtgUp.Rows[n]["ORG_ID"]);
                                upPatUP.RIS_PATSTATUS.IS_ACTIVE = char.Parse(dtgUp.Rows[n]["IS_ACTIVE"].ToString());
                                upPatUP.RIS_PATSTATUS.LAST_MODIFIED_BY = env.UserID;
                                upPatUP.Invoke();
                            }
                            dtgUp.AcceptChanges();
                            break;
                        case false: upPat.RIS_PATSTATUS.IS_DEFAULT = 'N'; break;
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
                    delPat.RIS_PATSTATUS.STATUS_ID = Convert.ToInt32(lblStatus.Text);
                    delPat.Invoke();

                    ProcessGetRISPatstatusN gePatDel = new ProcessGetRISPatstatusN();
                    gePatDel.RIS_PATSTATUS.SELECTCASE = 0;
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