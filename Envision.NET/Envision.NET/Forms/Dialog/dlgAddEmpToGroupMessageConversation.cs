using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;
using Miracle.Util;

namespace Envision.NET.Forms.Dialog
{
    public partial class dlgAddEmpToGroupMessageConversation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int groupID;
        private DataTable chkEmp;
        private DataTable dtEmp;
        private ProcessGetRISCommentEmpGroup groupManagement;

        public dlgAddEmpToGroupMessageConversation()
        {
            InitializeComponent();
            btnSave.Location = new Point(132, 517);
            btnDeleteGroup.Visible = false;
            groupID = 0;
        }

        public dlgAddEmpToGroupMessageConversation(int grId, string name, string tag, string desc)
        {
            InitializeComponent();
            groupID = grId;
            this.Text = "Group" + " " + name;
            txtName.Text = name;
            txtTag.Text = tag;
            txtDesc.Text = desc;

            groupManagement = new ProcessGetRISCommentEmpGroup();
            DataTable dtCheckDefault = groupManagement.checkGroupDefault(grId);
            if (Utilities.IsHaveData(dtCheckDefault))
            {
                txtName.Enabled = false;
                txtTag.Enabled = false;
                txtDesc.Enabled = false;
                btnDeleteGroup.Enabled = false;
                btnSave.Enabled = false;
            }
        }



        private void dlgAddEmpToGroupMessageConversation_Load(object sender, EventArgs e)
        {
            mergeGroup();
            setGridColumns();
            viewGroupMessage.MakeRowVisible(0, false);
            viewGroupMessage.SelectRow(0);
        }



        private void getGroupEmp()
        {
            groupManagement = new ProcessGetRISCommentEmpGroup();
            chkEmp = new DataTable();
            chkEmp = groupManagement.getEmpInGroup(groupID);
        }

        private void getEmp()
        {
            groupManagement = new ProcessGetRISCommentEmpGroup();
            GBLEnvVariable env = new GBLEnvVariable();
            dtEmp = new DataTable();
            dtEmp = groupManagement.getAllEmp();
            dtEmp.Columns.Add("CHK");
            foreach (DataRow dr in dtEmp.Rows)
            {
                dr["CHK"] = "N";
            }
        }

        private void mergeGroup()
        {
            getGroupEmp();
            getEmp();

            foreach (DataRow dr in chkEmp.Rows)
            {
                foreach (DataRow drEmp in dtEmp.Rows)
                {
                    if (dr["EMP_ID"].ToString() == drEmp["EMP_ID"].ToString())
                    {
                        drEmp["CHK"] = "Y";
                    }
                    dtEmp.AcceptChanges();
                }
            }

            grdGroupMessage.DataSource = dtEmp;
        }


        private void setGridColumns()
        {
            for (int i = 0; i < viewGroupMessage.Columns.Count; i++)
                viewGroupMessage.Columns[i].Visible = false;
            grdGroupMessage.ForceInitialize();
            viewGroupMessage.OptionsView.RowAutoHeight = true;
            viewGroupMessage.OptionsView.ColumnAutoWidth = false;
            viewGroupMessage.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewGroupMessage.OptionsBehavior.Editable = true;


            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUser = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkUser.ValueChecked = "Y";
            chkUser.ValueUnchecked = "N";
            chkUser.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkUser.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkUser.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkUser.Click += new EventHandler(chk_Click);

            viewGroupMessage.Columns["CHK"].Visible = true;
            viewGroupMessage.Columns["CHK"].VisibleIndex = 1;
            viewGroupMessage.Columns["CHK"].OptionsColumn.AllowEdit = true;
            viewGroupMessage.Columns["CHK"].OptionsColumn.ReadOnly = false;
            viewGroupMessage.Columns["CHK"].Caption = " ";
            viewGroupMessage.Columns["CHK"].Width = -1;
            viewGroupMessage.Columns["CHK"].ColumnEdit = chkUser;

            viewGroupMessage.Columns["Name"].Visible = true;
            viewGroupMessage.Columns["Name"].VisibleIndex = 2;
            viewGroupMessage.Columns["Name"].Width = 217;
            viewGroupMessage.Columns["Name"].OptionsColumn.ReadOnly = true;
            viewGroupMessage.Columns["Name"].OptionsColumn.AllowFocus = false;

            viewGroupMessage.Columns["JOB_TITLE_DESC"].Visible = true;
            viewGroupMessage.Columns["JOB_TITLE_DESC"].VisibleIndex = 3;
            viewGroupMessage.Columns["JOB_TITLE_DESC"].Width = 100;
            viewGroupMessage.Columns["JOB_TITLE_DESC"].OptionsColumn.ReadOnly = true;
            viewGroupMessage.Columns["JOB_TITLE_DESC"].OptionsColumn.AllowFocus = false;

            viewGroupMessage.Columns["EMP_ID"].Visible = false;

            //viewGroupMessage.Columns["CHK"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            //viewGroupMessage.Columns["Name"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }



        private void chk_Click(object sender, EventArgs e)
        {
            if (viewGroupMessage.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (viewGroupMessage.FocusedRowHandle > -1)
                {
                    DataRow drChk = viewGroupMessage.GetDataRow(viewGroupMessage.FocusedRowHandle);
                    if (chk.Checked == false)
                        drChk["CHK"] = "Y";
                    else
                        drChk["CHK"] = "N";

                    drChk.AcceptChanges();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string buttion_id = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);

            if (buttion_id == "2")
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    msg.ShowAlert("UID1403", new GBLEnvVariable().CurrentLanguageID);
                }
                else
	            {
                    GBLEnvVariable env = new GBLEnvVariable();

                if (groupID ==0)//Add New Group
                {
                     ProcessAddRISCommentEmpGroup prcAddGroup = new ProcessAddRISCommentEmpGroup();
                     groupID = prcAddGroup.createdNewGroup(txtName.Text, txtDesc.Text, txtTag.Text, env.UserID);
                }
                if (groupID > 0)//Update Group
                {
                    ProcessUpdateRISCommentEmpGroup groupUpdate = new ProcessUpdateRISCommentEmpGroup();
                    groupUpdate.Update(groupID, txtName.Text, txtDesc.Text, txtTag.Text, env.UserID);

                    ProcessDeleteRISCommentEmpGroup prcDelete = new ProcessDeleteRISCommentEmpGroup();
                    prcDelete.deleteEmpInGroup(groupID);
                }

                DataTable dtEmp = (DataTable)grdGroupMessage.DataSource;

                foreach (DataRow dr in dtEmp.Rows)//Update Emp in Group
                {
                    if (!string.IsNullOrEmpty(dr["EMP_ID"].ToString()) && dr["CHK"].ToString() == "Y")
                    {
                        ProcessAddRISCommentEmpGroup prc = new ProcessAddRISCommentEmpGroup();
                        prc.createdEmpToGroup(groupID, Convert.ToInt32(dr["EMP_ID"].ToString()), env.UserID);
                    }
                }

                this.Close();
	            }
                
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();

            if (msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID) == "2")
            {
                ProcessDeleteRISCommentEmpGroup prc = new ProcessDeleteRISCommentEmpGroup();
                prc.deleteGroup(groupID);
            }
            this.Close();
        }


        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                laStar.Visible = false;
            }
            else
            {
                laStar.Visible = true;
            }
        }

    }
}