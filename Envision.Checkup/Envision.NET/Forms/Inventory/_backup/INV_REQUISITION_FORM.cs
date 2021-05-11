using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Forms.GBLMessage;
using RIS.BusinessLogic;
using RIS.Common;

namespace RIS.Forms.Inventory
{
    public partial class INV_REQUISITION_FORM : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();

        public INV_REQUISITION_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            using (ProcessGetInvRequisition select = new ProcessGetInvRequisition())
            {
                select.Invoke();

                gridControl1.DataSource = select.ResultTable.Copy();

            }

            gridView_BestFit();

            Grid_ColumnEdit_Setting();

            txtOrdID1.Tag = new RIS.Common.Common.GBLEnvVariable().OrgID;
        }

        private void gridView_BestFit()
        {
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in gridView1.Columns)
            {
                col.BestFit();
            }
            if (gridView2.Columns.Count > -1)
            {
                if (gridControl2.DataSource == null)
                    Create_New_GridControl2();

                foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in gridView2.Columns)
                {
                    col.BestFit();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                btnAdd.Text = "Save";

                EnablePropertySetup(true);

                ClearText();

                AddNewRow();

                Grid_Editable_Enable(true);
                
            }
            else
            {
                btnAdd_Process();
                btnCancel_Process();
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Process()
        {
            using(ProcessAddInvRequisition insert = new ProcessAddInvRequisition())
            {
                INV_REQUISITION common = new INV_REQUISITION();

                //common.REQUISITION_ID = int.Parse(txtID.Text);
                common.REQUISITION_TYPE = txtType.Text;
                common.GENERATE_MODE = txtGenMode.Text;
                common.GENERATED_ON = DateTime.Parse(txtGenDate.Text);

                common.FROM_UNIT = Convert.ToInt32(txtFromUnit1.Tag);
                common.TO_UNIT = Convert.ToInt32(txtToUnit1.Tag);
                common.GENERATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);

                insert.INV_REQUISITION = common;
                insert.Invoke();
            }

            using (ProcessAddInvRequisitionDtl insert = new ProcessAddInvRequisitionDtl())
            {
                INV_REQUISITIONDTL common = new INV_REQUISITIONDTL();

                DataTable table = (DataTable)gridControl2.DataSource;

                //DataView dataview = (DataView)gridView2.DataSource;
                //DataTable table = dataview.Table;

                foreach (DataRow row in table.Rows)
                {
                    if (row["ITEM_ID"].ToString() != "")
                    {
                        //common.REQUISITION_ID = Convert.ToInt32(row["REQUISITION_ID"]);
                        common.ITEM_ID = Convert.ToInt32(row["ITEM_ID"]);
                        try{common.QTY = Convert.ToDouble(row["QTY"]);}
                        catch (Exception) { }
                        common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);

                        insert.INV_REQUISITIONDTL = common;
                        insert.Invoke();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            List<int> ID = new List<int>();

            if (btnEdit.Text.Equals("Edit"))
            {
                EnablePropertySetup(true);

                btnEdit.Text = "Save";

                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                AddNewRow();

                Grid_Editable_Enable(true);

                ID = Save_Old_ID();
            }
            else
            {
                btnEdit_Process();
                btnCancel_Process();
                btnEdit.Text = "Edit";
            }
        }

        private void btnEdit_Process()
        {
            using (ProcessUpdateInvRequisition update = new ProcessUpdateInvRequisition())
            {
                INV_REQUISITION common = new INV_REQUISITION();

                common.REQUISITION_ID = int.Parse(txtID.Text);
                common.REQUISITION_TYPE = txtType.Text;
                common.GENERATE_MODE = txtGenMode.Text;
                common.GENERATED_ON = DateTime.Parse(txtGenDate.Text);

                common.FROM_UNIT = Convert.ToInt32(txtFromUnit1.Tag);
                common.TO_UNIT = Convert.ToInt32(txtToUnit1.Tag);
                common.GENERATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);

                update.INV_REQUISITION = common;
                update.Invoke();
            }

            using (ProcessUpdateInvRequisitionDtl update = new ProcessUpdateInvRequisitionDtl())
            {
                INV_REQUISITIONDTL common = new INV_REQUISITIONDTL();
                DataTable table = (DataTable)gridControl2.DataSource;
                foreach (DataRow row in table.Rows)
                {
                    if (row["ITEM_ID"].ToString() != "")
                    {
                        common.REQUISITION_ID = Convert.ToInt32(row["REQUISITION_ID"]);
                        common.ITEM_ID = Convert.ToInt32(row["ITEM_ID"]);
                        try{common.QTY = Convert.ToDouble(row["QTY"]);}
                        catch (Exception) { }
                        common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);

                        update.INV_REQUISITIONDTL = common;
                        update.Invoke();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                //INV_UNIT common = new INV_UNIT();
                //common.UNIT_ID = int.Parse(txtID.Text);

                //ProcessDeleteInvUnit delete = new ProcessDeleteInvUnit();
                //delete.INV_UNIT = common;
                //delete.Invoke();

                //btnCancel_Process();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Process();
        }

        private void btnCancel_Process()
        {
            ClearText();

            using (ProcessGetInvRequisition select = new ProcessGetInvRequisition())
            {
                select.Invoke();
                //gbltable = select.ResultTable.Copy();

                gridControl1.DataSource = select.ResultTable.Copy();
            }

            gridView_BestFit();

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";
            btnDelete.Text = "Delete";

            EnablePropertySetup(false);

            gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);

            Grid_Editable_Enable(false);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void EnablePropertySetup(bool enable)
        {
            txtID.Enabled = enable;
            txtType.Enabled = enable;
            txtGenDate.Enabled = enable;
            txtGenMode.Enabled = enable;

            btnToUnit.Enabled = enable;
            btnFromUnit.Enabled = enable;
            btnGenBy.Enabled = enable;
            btnOrgId.Enabled = enable;
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                DataTable table = (DataTable)gridControl1.DataSource;
                DataRow row = table.Rows[e.FocusedRowHandle];

                AddText(row);

                using (ProcessGetInvRequisitionDtl select = new ProcessGetInvRequisitionDtl())
                {
                    INV_REQUISITIONDTL common = new INV_REQUISITIONDTL();

                    common.REQUISITION_ID = Convert.ToInt32(row["REQUISITION_ID"]);

                    select.INV_REQUISITIONDTL = common;
                    select.Invoke();

                    gridControl2.DataSource = select.ResultTable.Copy();
                }
            }
            else
            {
                ClearText();

                Create_New_GridControl2();
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle > -1)
            //{
            //    DataTable table = (DataTable)gridControl2.DataSource;
            //    DataRow row = table.Rows[e.FocusedRowHandle];

            //    AddText(row);
            //}
        }

        private void AddText(DataRow row)
        {
            txtID.Text = row["REQUISITION_ID"].ToString();
            txtType.Text = row["REQUISITION_TYPE"].ToString();
            txtGenDate.Text = row["GENERATED_ON"].ToString();
            txtGenMode.Text = row["GENERATE_MODE"].ToString();

            txtFromUnit1.Tag = row["FROM_UNIT"].ToString();
            txtFromUnit1.Text = row["UNIT_UID"].ToString();
            txtFromUnit2.Text = row["UNIT_NAME"].ToString();

            txtToUnit1.Tag = row["TO_UNIT"].ToString();
            txtToUnit1.Text = row["UNIT_UID"].ToString();
            txtToUnit2.Text = row["UNIT_NAME"].ToString();

            txtGenBy1.Tag = row["GENERATED_BY"].ToString();
            txtGenBy1.Text = row["EMP_UID"].ToString();
            txtGenBy2.Text = row["USER_NAME"].ToString();

            txtOrdID1.Tag = row["ORG_ID"].ToString();
            txtOrdID1.Text = row["ORG_UID"].ToString();
            txtOrdID2.Text = row["ORG_NAME"].ToString();

        }

        private void ClearText()
        {
            txtID.Text = "";
            txtType.Text = "";
            txtGenDate.Text = "";
            txtGenMode.Text = "";

            txtFromUnit1.Text = "";
            txtFromUnit2.Text = "";

            txtToUnit1.Text = "";
            txtToUnit2.Text = "";

            txtGenBy1.Text = "";
            txtGenBy2.Text = "";

            txtOrdID1.Text = "";
            txtOrdID2.Text = "";

        }

        private void btnOrgId_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnOrgId_Clicks);

            string qry = @"
                            select
                                ORG_ID,ORG_UID,ORG_NAME,ORG_ALIAS
                            from
                                GBL_ENV
                            where 
                                ORG_ID like '%%' OR ORG_UID like '%%' OR
                                ORG_NAME like '%%' OR ORG_ALIAS like '%%'
                            order by ORG_ID asc;
                        ";

            string fields = "ID, Code, Name, Alias";
            string con = "";
            lv.getData(qry, fields, con, "Global Environtment");
            lv.Show();
        }

        private void btnOrgId_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtOrdID1.Tag = retValue[0];
            txtOrdID1.Text = retValue[1];
            txtOrdID2.Text = retValue[2];
        }

        private void gridView1_FocusedRowChanged(int rowindex)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs args
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(rowindex, rowindex);

            gridView1_FocusedRowChanged(this.gridView1, args);
        }

        private void AddNewRow()
        {
            if (gridControl2.DataSource==null)
                Create_New_GridControl2();

            //gridView2.AddNewRow();

            DataTable table = (DataTable)gridControl2.DataSource;
            DataRow row = table.NewRow();
            table.Rows.Add(row);
        }

        private void Grid_ColumnEdit_Setting()
        {
            //using (
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button
                = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();//)
            //{
                button.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(button2_ButtonClick);
                gridView2.Columns["ITEM_ID"].ColumnEdit = button;
            //}

            gridView2.Columns["REQUISITION_ID"].OptionsColumn.ReadOnly = true;
            

            //using (
                DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spin
                = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();//)
            //{
                spin.DisplayFormat.FormatString = "0.00";
                spin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                spin.EditFormat.FormatString = "0.00";
                spin.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                spin.MaxValue = 9999999;

                gridView2.Columns["QTY"].ColumnEdit = spin;
            //}
        }

        private void button2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(button2_ButtonClicks);

            string qry = @"
                            select
                                ITEM_ID,ITEM_UID,ITEM_NAME,ITEM_DESC
                            from
                                INV_ITEM
                            where 
                                ITEM_ID like '%%' OR ITEM_UID like '%%' OR
                                ITEM_NAME like '%%' OR ITEM_DESC like '%%'
                            order by ITEM_ID asc;
                        ";

            string fields = "ID, Code, Name, Description";
            string con = "";
            lv.getData(qry, fields, con, "Inventory Item List");
            lv.Show();

            this.Enabled = false;
        }

        private void button2_ButtonClicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            DataTable table = (DataTable)gridControl2.DataSource;
            table.Rows[gridView2.FocusedRowHandle]["ITEM_ID"] = retValue[0];

            this.Enabled = true;

            if (gridView2.FocusedRowHandle == gridView2.RowCount - 1)
                AddNewRow();
        }

        private void Grid_Editable_Enable(bool enable)
        {
            gridView2.OptionsBehavior.Editable = enable;
        }

        private void gridView2_CellValueChanged
            (object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //DataTable table = (DataTable)gridControl2.DataSource;
            //DataRow row = table.Rows[e.RowHandle];

            //if (e.Column.FieldName == "ITEM_ID" && e.RowHandle == gridView2.RowCount - 1)
            //{


            //    AddNewRow();
            //}
        }

        private void btnFromUnit_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnFromUnit_Clicks);

            string qry = @"
                            select
                                UNIT_ID,UNIT_UID,UNIT_NAME,UNIT_DESC
                            from
                                INV_UNIT
                            where 
                                UNIT_ID like '%%' OR UNIT_UID like '%%' OR
                                UNIT_NAME like '%%' OR UNIT_DESC like '%%'
                            order by UNIT_ID asc;
                        ";

            string fields = "ID, Code, Name, Description";
            string con = "";
            lv.getData(qry, fields, con, "Inventory Unit List");
            lv.Show();
        }

        private void btnFromUnit_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtFromUnit1.Tag = retValue[0];
            txtFromUnit1.Text = retValue[1];
            txtFromUnit2.Text = retValue[2];
        }

        private void btnToUnit_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnToUnit_Clicks);

            string qry = @"
                            select
                                UNIT_ID,UNIT_UID,UNIT_NAME,UNIT_DESC
                            from
                                INV_UNIT
                            where 
                                UNIT_ID like '%%' OR UNIT_UID like '%%' OR
                                UNIT_NAME like '%%' OR UNIT_DESC like '%%'
                            order by UNIT_ID asc;
                        ";

            string fields = "ID, Code, Name, Description";
            string con = "";
            lv.getData(qry, fields, con, "Inventory Unit List");
            lv.Show();
        }

        private void btnToUnit_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtToUnit1.Tag = retValue[0];
            txtToUnit1.Text = retValue[1];
            txtToUnit2.Text = retValue[2];
        }

        private void Create_New_GridControl2()
        {
            List<DataColumn> list = new List<DataColumn>();

            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in gridView2.Columns)
            {
                DataColumn cols = new DataColumn();
                cols.ColumnName = col.FieldName;
                list.Add(cols);
            }

            //DataTable table = (DataTable)gridControl2.DataSource;
            DataTable table = new DataTable();

            table.Columns.AddRange(list.ToArray());

            gridControl2.DataSource = table.Copy();
        }

        private List<int> Save_Old_ID()
        { 
            List<int> result = new List<int>();

            DataTable table = (DataTable)gridControl2.DataSource;
            foreach(DataRow row in table.Rows)
            {
                result.Add(Convert.ToInt32(row["ITEM_ID"]));
            }

            return result;
        }

    }
}