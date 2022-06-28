using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.Common;
using Envision.BusinessLogic;
using Miracle.Util;

namespace Envision.NET.Forms.Dialog
{
    public partial class dlgRadGroup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        GBLEnvVariable env = new GBLEnvVariable();
        private int groupID;
        private string groupName;
        private DataTable chkEmp;
        private DataTable dtEmp;
        private ProcessRisPrGroup groupManagement;

        public dlgRadGroup()
        {
            InitializeComponent();
            btnDeleteGroup.Visible = false;
            btnSave.Location = new Point(132, 517);
            groupID = 0;
        }

        public dlgRadGroup(int grId, string name)
        {
            InitializeComponent();
            groupID = grId;
            this.Text = "Group" + " " + name;
            txtName.Text = name;
            groupName = name;

            groupManagement = new ProcessRisPrGroup();
            DataTable dtCheckDefault = groupManagement.getEmpInGroup(grId, env.OrgID);
            if (Utilities.IsHaveData(dtCheckDefault))
            {
                txtName.Enabled = true;
                //btnDeleteGroup.Enabled = true;
                btnSave.Enabled = true;

                btnDeleteGroup.Visible = false;
                btnSave.Location = new Point(132, 517);
            }
        }

        private void dlgRadGroup_Load(object sender, EventArgs e)
        {
            mergeGroup();
            setGridColumns();
            viewPrRadGroup.MakeRowVisible(0, false);
            viewPrRadGroup.SelectRow(0);
        }

        private void getGroupEmp()
        {
            groupManagement = new ProcessRisPrGroup();
            GBLEnvVariable env = new GBLEnvVariable();
            chkEmp = new DataTable();
            chkEmp = groupManagement.getEmpInGroup(groupID, env.OrgID);
        }

        private void getEmp()
        {
            groupManagement = new ProcessRisPrGroup();
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
                    if (dr["RAD_ID"].ToString() == drEmp["EMP_ID"].ToString())
                    {
                        drEmp["CHK"] = "Y";
                    }
                    dtEmp.AcceptChanges();
                }
            }

            grdPrRadGroup.DataSource = dtEmp;
        }

        private void setGridColumns()
        {
            for (int i = 0; i < viewPrRadGroup.Columns.Count; i++)
                viewPrRadGroup.Columns[i].Visible = false;
            grdPrRadGroup.ForceInitialize();
            viewPrRadGroup.OptionsView.RowAutoHeight = true;
            viewPrRadGroup.OptionsView.ColumnAutoWidth = false;
            viewPrRadGroup.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewPrRadGroup.OptionsBehavior.Editable = true;


            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUser = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkUser.ValueChecked = "Y";
            chkUser.ValueUnchecked = "N";
            chkUser.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkUser.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkUser.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkUser.Click += new EventHandler(chk_Click);

            viewPrRadGroup.Columns["CHK"].Visible = true;
            viewPrRadGroup.Columns["CHK"].VisibleIndex = 1;
            viewPrRadGroup.Columns["CHK"].OptionsColumn.AllowEdit = true;
            viewPrRadGroup.Columns["CHK"].OptionsColumn.ReadOnly = false;
            viewPrRadGroup.Columns["CHK"].Caption = " ";
            viewPrRadGroup.Columns["CHK"].Width = -1;
            viewPrRadGroup.Columns["CHK"].ColumnEdit = chkUser;

            viewPrRadGroup.Columns["Name"].Visible = true;
            viewPrRadGroup.Columns["Name"].VisibleIndex = 2;
            viewPrRadGroup.Columns["Name"].Width = 217;
            viewPrRadGroup.Columns["Name"].OptionsColumn.ReadOnly = true;
            viewPrRadGroup.Columns["Name"].OptionsColumn.AllowFocus = false;

            viewPrRadGroup.Columns["JOB_TITLE_DESC"].Visible = true;
            viewPrRadGroup.Columns["JOB_TITLE_DESC"].VisibleIndex = 3;
            viewPrRadGroup.Columns["JOB_TITLE_DESC"].Width = 100;
            viewPrRadGroup.Columns["JOB_TITLE_DESC"].OptionsColumn.ReadOnly = true;
            viewPrRadGroup.Columns["JOB_TITLE_DESC"].OptionsColumn.AllowFocus = false;

            viewPrRadGroup.Columns["EMP_ID"].Visible = false;

            //viewGroupMessage.Columns["CHK"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            //viewGroupMessage.Columns["Name"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }

        private void chk_Click(object sender, EventArgs e)
        {
            if (viewPrRadGroup.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                if (viewPrRadGroup.FocusedRowHandle > -1)
                {
                    DataRow drChk = viewPrRadGroup.GetDataRow(viewPrRadGroup.FocusedRowHandle);
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
                txtName.ErrorText = string.Empty;

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    msg.ShowAlert("UID1403", new GBLEnvVariable().CurrentLanguageID);
                    dxErrorProvider1.SetError(txtName, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                else
                {
                    ProcessRisPrGroup groupData;
                   
                    if (groupID == 0)//Add New Group
                    {
                        groupData = new ProcessRisPrGroup();
                        groupID = groupData.createdNewGroup(txtName.Text.Trim(), env.OrgID, env.UserID);

                        setEmpInGroup();

                    }
                    if (groupID > 0)//Update Group
                    {
                        if (groupName.Trim() == txtName.Text.Trim())
                        {
                            
                            groupData = new ProcessRisPrGroup();
                            groupData.Update(groupID, txtName.Text.Trim(), env.OrgID, env.UserID);

                            groupData = new ProcessRisPrGroup();
                            groupData.deleteEmpInGroup(groupID);

                            setEmpInGroup();
                        }
                        else
                        {
                            groupData = new ProcessRisPrGroup();
                            DataTable group = groupData.chkGroupName(txtName.Text, env.OrgID);

                            if (group.Rows.Count == 0)
                            {
                                groupData = new ProcessRisPrGroup();
                                groupData.Update(groupID, txtName.Text.Trim(), env.OrgID, env.UserID);

                                groupData = new ProcessRisPrGroup();
                                groupData.deleteEmpInGroup(groupID);

                                setEmpInGroup();
                            }
                            else if (group.Rows.Count > 0)
                            {
                                dxErrorProvider1.SetError(txtName, "duplicate group name", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                            }
                        }
                    }
                }

            }
        }

        private void setEmpInGroup()
        {
            DataTable dtEmp = (DataTable)grdPrRadGroup.DataSource;

            foreach (DataRow dr in dtEmp.Rows)//Update Emp in Group
            {
                if (!string.IsNullOrEmpty(dr["EMP_ID"].ToString()) && dr["CHK"].ToString() == "Y")
                {
                    ProcessRisPrGroup prc = new ProcessRisPrGroup();
                    prc.createdEmpToGroup(groupID, Convert.ToInt32(dr["EMP_ID"].ToString()), env.OrgID, env.UserID);
                }
            }

            this.Close();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();

            if (msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID) == "2")
            {
                ProcessRisPrGroup prc = new ProcessRisPrGroup();
                prc.deleteGroup(groupID);
            }
            this.Close();
        }


        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                txtName.ErrorText = string.Empty;
            }
            else
            {
                dxErrorProvider1.SetError(txtName, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
        }

    }
}