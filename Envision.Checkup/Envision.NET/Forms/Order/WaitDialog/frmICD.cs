using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
namespace RIS.Forms.Order.WaitDialog
{
    public partial class frmICD : Form
    {
        private DataTable dttData;
        private DataTable dttBaseData;
        private MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();
        private DataTable dttUpdate;

        public DataTable ICDTable
        {
            get { return dttData; }
            set { 
                dttData = value;
                SetGridICD();
            }
        }

        public frmICD()
        {
            InitializeComponent();
            dttData = new DataTable();
            LoadInitData();
            SetGridICD();
        }
        public frmICD(bool EditGrid) {
            InitializeComponent();
            dttData = new DataTable();
            LoadInitData();
            SetGridICD();
            view1.OptionsBehavior.Editable = EditGrid;
            btnCancel.Visible = false;
            btnOK.Visible = false;
            btnClose.Visible = true;
        }
        private void LoadInitData() {
            ProcessGetHisICD processICD = new ProcessGetHisICD();
            processICD.Invoke();
            dttBaseData = processICD.Result.Tables[0].Copy();

            ProcessGetRISPaticd processPat = new ProcessGetRISPaticd(-1);
            processPat.Invoke();
            dttData = processPat.Result.Tables[0];
        }
        private void SetGridICD() {
            bool flag = true;
            for(int m=0;m<dttData.Columns.Count;m++)
                if (dttData.Columns[m].ColumnName.Trim() == "colDelete")
                {
                    flag = false;
                    break;
                }

            if (flag)
            {
                dttData.Columns.Add("colDelete");
                dttData.Columns.Add("ICD_DESC");
                dttData.Columns.Add("IS_DELETED");
            }
            dttUpdate = dttData.Clone();
            if (dttData.Rows.Count == 0)
            {
                DataRow dr = dttData.NewRow();
                dttData.Rows.Add(dr);

            }
            else { 
                foreach (DataRow dr in dttData.Rows)
                    dr["ICD_DESC"] = dr["ICD_ID"];

                DataRow drAdd = dttData.NewRow();
                dttData.Rows.Add(drAdd);

                //for(int i=0;i<dttData.Rows.Count;i++)
                //    if (dttData.Rows[i]["IS_DELETED"].ToString() == "Y")
                //    {
                //        drAdd = dttUpdate.NewRow();
                //        for (int j = 0; j < dttUpdate.Columns.Count; j++)
                //            drAdd[j] = dttData.Rows[i][j];
                //        dttData.Rows[i].Delete();
                //        dttData.AcceptChanges();
                //        i = 0;
                //    }
                
            }
            grdData.DataSource = dttData;

            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.OptionsView.ShowBands = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            view1.OptionsView.ShowColumnHeaders = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICD_UID", "ICD Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "ICD_UID";
            repositoryItemLookUpEdit1.ValueMember = "ICD_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dttBaseData;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(icdUID_KeyUp);
            repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(icdUID_CloseUp);
            view1.Columns["ICD_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            view1.Columns["ICD_ID"].Visible = true;
            view1.Columns["ICD_ID"].Caption = "ICD Code";
            view1.Columns["ICD_ID"].BestFit();

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICD_DESC", "ICD Desc", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "ICD_DESC";
            repositoryItemLookUpEdit2.ValueMember = "ICD_ID";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dttBaseData;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(icdDesc_KeyUp);
            repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(icdDesc_CloseUp);
            view1.Columns["ICD_DESC"].ColumnEdit = repositoryItemLookUpEdit2;
            view1.Columns["ICD_DESC"].Visible = true;
            view1.Columns["ICD_DESC"].Caption = "ICD Description";
            view1.Columns["ICD_DESC"].BestFit();

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDelete_Click);
            view1.Columns["colDelete"].Caption = string.Empty;
            view1.Columns["colDelete"].ColumnEdit = btn;
            view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["colDelete"].Visible = true;

            view1.Columns["ICD_ID"].ColVIndex = 0;
            view1.Columns["ICD_DESC"].ColVIndex = 1;
            view1.Columns["colDelete"].ColVIndex = 2;

            view1.Columns["ICD_ID"].Width = 100;
            view1.Columns["ICD_DESC"].Width = 320;
            view1.Columns["colDelete"].Width = 30;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)grdData.DataSource;
            int row = view1.FocusedRowHandle;
            dtt.Rows[row].Delete();
            dtt.AcceptChanges();

            //if (dtt.Rows.Count == 0)
                AddNewRow();
        }
      
        private void AddNewRow()
        {
            DataTable dtt = (DataTable)grdData.DataSource;
            foreach (DataRow drSearch in dtt.Rows)
            {
                if (drSearch["ICD_ID"].ToString().Trim() == string.Empty) 
                    return;
            }
            DataRow dr = dtt.NewRow();
            dtt.Rows.Add(dr);
        }

        private bool UpdateICD(string strSearch)
        {
            int i = 0;
            bool flag = false;
            for (; i < dttBaseData.Rows.Count; i++) {
                if (dttBaseData.Rows[i]["ICD_ID"].ToString().Trim() == strSearch)
                    break;
            }
            if (dttBaseData.Rows.Count > i)
            {
                DataTable dtt = (DataTable)grdData.DataSource;
                flag = false;
                foreach (DataRow dr in dtt.Rows) {
                    if (dr["ICD_ID"].ToString().Trim() == strSearch.Trim())
                    {
                        flag = true;
                        break;
                    }
                }
                if(flag){
                    //show alert
                    msg.ShowAlert("UID1031",env.CurrentLanguageID);
                    flag=false;
                    return flag;
                }

                flag = true;
                dtt.Rows[view1.FocusedRowHandle]["ICD_ID"] = dttBaseData.Rows[i]["ICD_ID"];
                dtt.Rows[view1.FocusedRowHandle]["ICD_DESC"] = dttBaseData.Rows[i]["ICD_ID"];
                view1.RefreshData();
                AddNewRow();
            }   
            return flag;
        }

        private void icdUID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                int row = view1.FocusedRowHandle;
                bool flag=UpdateICD(e.Value.ToString());
                if (flag)
                {
                    if (e.Value.ToString() != string.Empty)
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }
                else
                    e.AcceptValue = false;
            }
        }
        private void icdUID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view1.FocusedColumn = view1.VisibleColumns[1];
                view1.MoveNext();
            }
        }

        private void icdDesc_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value != null)
                {
                    bool flag = UpdateICD(e.Value.ToString());
                    if (flag)
                    {
                        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                        int row = view1.FocusedRowHandle;
                        if (e.Value.ToString() != string.Empty)
                        {
                            view1.FocusedColumn = view1.VisibleColumns[0];
                            view1.MoveNext();
                        }
                    }
                    else
                        e.AcceptValue = false;
                }
            }
        }
        private void icdDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view1.FocusedColumn = view1.VisibleColumns[0];
                view1.MoveNext();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow dr = null;
            
            dttData = (DataTable)grdData.DataSource;
            if (dttUpdate.Rows.Count > 0) {
                for (int i = 0; i < dttUpdate.Rows.Count; i++) { 
                    dr = dttData.NewRow();
                    for (int j = 0; j < dttUpdate.Columns.Count; j++) 
                        dr[j] = dttUpdate.Rows[i][j];
                    dttData.Rows.Add(dr);
                }
            }
            dttData.AcceptChanges();
            
            for (int k=0;k<dttData.Rows.Count;k++)
                if(dttData.Rows[k].RowState!=DataRowState.Deleted){
                    if (dttData.Rows[k]["ICD_ID"].ToString().Trim() == string.Empty)
                    {
                        dttData.Rows[k].Delete();
                        k = 0;
                    }
                }
            //dr = dttData.Rows[dttData.Rows.Count - 1];
            //if (dr["ICD_ID"].ToString().Trim() == string.Empty)
            //    dr.Delete();
            dttData.AcceptChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}