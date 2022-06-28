using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Media;
using System.Threading;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Envision.BusinessLogic.ProcessDelete;
using Envision.Common;
using DevExpress.XtraEditors;
using Envision.BusinessLogic;
using DevExpress.XtraGrid.Views.Grid;

namespace Envision.NET.Forms.Dialog
{
    public partial class GroupEmpMessageConversation : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public DataTable dataGroupDetail { get; set; }
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataTable dtGroup, dtAllEmp;
        public GroupEmpMessageConversation()
        {
            InitializeComponent();
            dataGroupDetail = new DataTable();
        }

        private void GroupEmpMessageConversation_Load(object sender, EventArgs e)
        {
            dtAllEmp = new DataTable();
            dtGroup = new DataTable();

            getData();
            getGroupTech();
            setGridColumns();
        }
        private void getData()
        {
            ProcessGetRISCommentEmpGroup groupManagement = new ProcessGetRISCommentEmpGroup();
            dtGroup = groupManagement.getGroupEmp(env.UserID);
            dtGroup.Columns.Add("CHK");
            dtGroup.AcceptChanges();
            dtAllEmp = groupManagement.getAllEmp();
            dtAllEmp.Columns.Add("CHK");
            dtAllEmp.AcceptChanges();
        }
        private void getGroupTech()
        {
            for (int c = 0; c < dtAllEmp.Rows.Count; c++)
                dtAllEmp.Rows[c]["CHK"] = "N";

            foreach (DataRow rowChk in dataGroupDetail.Rows)
            {
                DataRow[] rowChkAllEmp = dtAllEmp.Select("EMP_ID = "+rowChk["READER_ID"].ToString());
                if (rowChkAllEmp.Length > 0)
                    rowChkAllEmp[0]["CHK"] = "Y";
            }
            foreach (DataRow rowChkGroup in dtGroup.Rows)
            {
                bool chkGroup = true;
                ProcessGetRISCommentEmpGroup groupManagement = new ProcessGetRISCommentEmpGroup();
                DataTable dtGroupDtl = groupManagement.getEmpInGroup(Convert.ToInt32(rowChkGroup["GROUP_ID"]));
                for (int i = 0; i < dtGroupDtl.Rows.Count; i++)
                {
                    if (dataGroupDetail.Select("READER_ID=" + dtGroupDtl.Rows[i]["EMP_ID"].ToString()).Length == 0)
                    {
                        chkGroup = false;
                        break;
                    }
                }
                if (chkGroup)
                    rowChkGroup["CHK"] = "Y";
                else
                    rowChkGroup["CHK"] = "N";
            }
            dtGroup.AcceptChanges();
            dtAllEmp.AcceptChanges();

            DataTable dt = new DataTable();
            dt.Merge(dtGroup);
            dt.Merge(dtAllEmp);
            grdGroupTech.DataSource = dt;
        }
        private void setGridColumns()
        {
            grdGroupTech.ForceInitialize();
            viewTech.OptionsView.RowAutoHeight = true;
            viewTech.OptionsView.ColumnAutoWidth = false;
            viewTech.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewTech.OptionsBehavior.Editable = true;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUser = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkUser.ValueChecked = "Y";
            chkUser.ValueUnchecked = "N";
            chkUser.ValueGrayed = " ";
            chkUser.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkUser.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkUser.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkUser.Click += new EventHandler(chk_Click);

            viewTech.Columns["CHK"].Visible = true;
            viewTech.Columns["CHK"].VisibleIndex = 1;
            viewTech.Columns["CHK"].OptionsColumn.AllowEdit = true;
            viewTech.Columns["CHK"].OptionsColumn.ReadOnly = false;
            viewTech.Columns["CHK"].Caption = " ";
            viewTech.Columns["CHK"].Width = -1;
            viewTech.Columns["CHK"].ColumnEdit = chkUser;

            viewTech.Columns["GROUP_ID"].Visible = false;

            viewTech.Columns["mergeGroup"].GroupIndex = 1;

            viewTech.Columns["Name"].Caption = "Name";
            viewTech.Columns["Name"].OptionsColumn.ReadOnly = true;
            viewTech.Columns["Name"].VisibleIndex = 2;
            viewTech.Columns["Name"].OptionsColumn.AllowFocus = false;
            viewTech.Columns["Name"].Width = 229;

            viewTech.Columns["JOB_TITLE_DESC"].Caption = "Job Title";
            viewTech.Columns["JOB_TITLE_DESC"].OptionsColumn.ReadOnly = true;
            viewTech.Columns["JOB_TITLE_DESC"].VisibleIndex = 3;
            viewTech.Columns["JOB_TITLE_DESC"].OptionsColumn.AllowFocus = false;
            viewTech.Columns["JOB_TITLE_DESC"].Width = 80;

            viewTech.Columns["GROUP_DESC"].Caption = "Desc";
            viewTech.Columns["GROUP_DESC"].Visible = false;

            viewTech.Columns["EMP_ID"].Caption = "Emp ID";
            viewTech.Columns["EMP_ID"].Visible = false;

            //viewTech.Columns["CHK"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            //viewTech.Columns["Name"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            viewTech.Columns["GROUP_TAG"].Caption = "Group Tag";
            viewTech.Columns["GROUP_TAG"].Visible = false;

        }
        private void grdGroupTech_DoubleClick(object sender, EventArgs e)
        {
            if (viewTech.FocusedRowHandle >= 0)
            {
                DataRow drGroup = viewTech.GetDataRow(viewTech.FocusedRowHandle);

                if (!string.IsNullOrEmpty(drGroup["GROUP_ID"].ToString()))
                {
                    dlgAddEmpToGroupMessageConversation frmInGroup = new dlgAddEmpToGroupMessageConversation(Convert.ToInt32(drGroup["GROUP_ID"].ToString()), drGroup["Name"].ToString(), drGroup["GROUP_TAG"].ToString(), drGroup["GROUP_DESC"].ToString());
                    frmInGroup.ShowDialog();
                    getData();
                    getGroupTech();
                }
            }

        }
        private void chk_Click(object sender, EventArgs e)
        {
            if (viewTech.FocusedRowHandle < 0)
                return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            DataRow drChk = viewTech.GetDataRow(viewTech.FocusedRowHandle);
            DataView dvAllEmp = viewTech.DataSource as DataView;
            DataTable dtAllEmp = dvAllEmp.ToTable();
            if (string.IsNullOrEmpty(drChk["GROUP_ID"].ToString()))
            {
                if (chk.Checked == false)
                {
                    DataRow rowAdd = dataGroupDetail.NewRow();
                    rowAdd["READER_ID"] = drChk["EMP_ID"];
                    dataGroupDetail.Rows.Add(rowAdd);
                    drChk["CHK"] = "Y";
                }
                else
                {
                    DataRow[] rowsDel = dataGroupDetail.Select("READER_ID=" + drChk["EMP_ID"].ToString());
                    foreach (DataRow rowD in rowsDel)
                        dataGroupDetail.Rows.Remove(rowD);
                    drChk["CHK"] = "N";
                }

            
            }
            else
            {
                ProcessGetRISCommentEmpGroup groupManagement = new ProcessGetRISCommentEmpGroup();
                DataTable dtGroupDtl = groupManagement.getEmpInGroup(Convert.ToInt32(drChk["GROUP_ID"]));
                foreach (DataRow rowAddDtl in dtGroupDtl.Rows)
                {
                    if (drChk["CHK"].ToString() == "Y")
                    {
                        DataRow[] rowsRemove = dataGroupDetail.Select("READER_ID="+rowAddDtl["EMP_ID"].ToString());
                        foreach (DataRow rowRemove in rowsRemove)
                            dataGroupDetail.Rows.Remove(rowRemove);
                    }
                    else
                    {
                        DataRow rowAdd = dataGroupDetail.NewRow();
                        rowAdd["READER_ID"] = rowAddDtl["EMP_ID"];
                        dataGroupDetail.Rows.Add(rowAdd);
                    }

                    DataRow[] rowChkAllEmp = dtAllEmp.Select("EMP_ID = " + rowAddDtl["EMP_ID"].ToString());
                    if (rowChkAllEmp.Length > 0)
                        rowChkAllEmp[0]["CHK"] = rowChkAllEmp[0]["CHK"] == "Y" ? "N" : "Y";
                }
            }
            getGroupTech();
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void barBtnAddGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgAddEmpToGroupMessageConversation frmGroup = new dlgAddEmpToGroupMessageConversation();
            frmGroup.ShowDialog();
            getData();
            getGroupTech();
        }


        private void viewTech_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            (e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds = Rectangle.Empty;
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.FieldName == "mergeGroup")
            {
                if ("1" == info.EditValue.ToString())
                {
                    info.GroupText = "Group";
                }
                if ("2" == info.EditValue.ToString())
                {
                    info.GroupText = "All";
                }
            }
            info.Appearance.ForeColor = Color.Black;
        }
        private void viewTech_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }
        private void viewTech_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }

    }
}