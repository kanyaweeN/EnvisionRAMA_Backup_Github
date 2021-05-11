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
    public partial class INV_PO_FORM : Form
    {
        DataTable gbltable = new DataTable();
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();

        public INV_PO_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            using (ProcessGetInvPo select = new ProcessGetInvPo())
            {
                select.Invoke();
                gbltable = select.ResultTable.Copy();

                gridControl1.DataSource = gbltable.Copy();

            }

            gridView_BestFit();

            txtPOID_TextChanged_Enable(true);

            Grid_ColumnEdit_Setting();

            txtPOID_TextChanged(new object(),new EventArgs());
        }

        private void gridView_BestFit()
        {
            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in gridView1.Columns)
            {
                col.BestFit();
            }
            foreach(DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in gridView1.Columns)
            {
                col.BestFit();
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

                //txtPOID_TextChanged_Enable(false);

                //AddNewDataSource();

                New_GridControl2_DataSource();

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
            using(ProcessAddInvPo insert = new ProcessAddInvPo())
            {
                INV_PO common = new INV_PO();

                //common.PO_ID = txtPOID.Text;
                common.REQUISITION_ID = int.Parse(txtRquisitionID.Text);
                common.TOC = txtTOC.Text;
                common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);
                common.VENDOR_ID = Convert.ToInt32(txtVendor1.Tag);
                common.GENERATED_ON = DateTime.Parse(txtGenDate.Text);
                common.PO_STATUS = txtPOStatus.Text.Substring(0, 1);

                insert.INV_PO = common;
                insert.Invoke();
            }


            using(ProcessAddInvPodtl insert = new ProcessAddInvPodtl())
            {
                INV_PODTL common = new INV_PODTL();
                DataTable table = (DataTable)gridControl2.DataSource;
                foreach (DataRow row in table.Rows)
                {
                    if (row["ITEM_ID"].ToString() != "")
                    {
                        common.ITEM_ID = Convert.ToInt32(row["ITEM_ID"]);
                        common.QTY = Convert.ToDouble(row["QTY"]);
                        common.PO_ITEM_STATUS = row["PO_ITEM_STATUS"].ToString();
                        common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);

                        insert.INV_PODTL = common;
                        insert.Invoke();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                EnablePropertySetup(true);

                btnEdit.Text = "Save";

                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                if (gridControl2.DataSource == null)
                    New_GridControl2_DataSource();

                AddNewRow();


                Grid_Editable_Enable(true);
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
            using (ProcessUpdateInvPo update = new ProcessUpdateInvPo())
            {
                INV_PO common = new INV_PO();
                common.PO_ID = int.Parse(txtPOID.Text);
                common.REQUISITION_ID = int.Parse(txtRquisitionID.Text);
                common.TOC = txtTOC.Text;
                common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);
                common.VENDOR_ID = Convert.ToInt32(txtVendor1.Tag);
                common.GENERATED_ON = DateTime.Parse(txtGenDate.Text);
                common.PO_STATUS = txtPOStatus.Text.Substring(0, 1);

                update.INV_PO = common;
                update.Invoke();
            }

            using (ProcessUpdateInvPodtl update = new ProcessUpdateInvPodtl())
            {
                INV_PODTL common = new INV_PODTL();
                DataTable table = (DataTable)gridControl2.DataSource;
                foreach (DataRow row in table.Rows)
                {
                    if (row["ITEM_ID"].ToString() != "")
                    {
                        common.PO_ID = int.Parse(txtPOID.Text);
                        common.ITEM_ID = Convert.ToInt32(row["ITEM_ID"]);
                        common.QTY = Convert.ToDouble(row["QTY"]);
                        common.PO_ITEM_STATUS = row["PO_ITEM_STATUS"].ToString();
                        common.ORG_ID = Convert.ToInt32(txtOrdID1.Tag);

                        update.INV_PODTL = common;
                        update.Invoke();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                using (ProcessDeleteInvPo delete = new ProcessDeleteInvPo())
                {
                    INV_PO common = new INV_PO();

                    common.PO_ID = int.Parse(txtPOID.Text);

                    delete.INV_PO = common;
                    delete.Invoke();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Process();
        }

        private void btnCancel_Process()
        {
            ClearText();

            using (ProcessGetInvPo select = new ProcessGetInvPo())
            {
                select.Invoke();
                gbltable = select.ResultTable.Copy();

                gridControl1.DataSource = gbltable.Copy();
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

            //txtPOID_TextChanged_Enable(true);

            Grid_Editable_Enable(false);

            txtPOID_TextChanged(new object(), new EventArgs());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void EnablePropertySetup(bool enable)
        {
            //txtID.Enabled = enable;
            //txtPOID.Enabled = enable;
            txtRquisitionID.Enabled = enable;
            btnOrgId.Enabled = enable;
            //txtDescription.Enabled = enable;
            btnVendor.Enabled = enable;
            //gridControl1.Enabled = enable;
            txtPOStatus.Enabled = enable;
            txtSearch.Enabled = !enable;
            txtTOC.Enabled = enable;
            txtGenDate.Enabled = enable;
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                DataTable table = (DataTable)gridControl1.DataSource;
                DataRow row = table.Rows[e.FocusedRowHandle];

                AddText(row);
            }
        }

        //private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle > -1)
        //    {
        //        DataTable table = (DataTable)gridControl2.DataSource;
        //        DataRow row = table.Rows[e.FocusedRowHandle];

        //        AddText(row);
        //    }
        //}

        private void AddText(DataRow row)
        {
            //txtID.Text = row["UNIT_ID"].ToString();
            txtPOID.Text = row["PO_ID"].ToString();
            txtRquisitionID.Text = row["REQUISITION_ID"].ToString();
            txtGenDate.Text = row["GENERATED_ON"].ToString();
            txtTOC.Text = row["TOC"].ToString();
            txtPOStatus.Text = row["PO_STATUS"].ToString();
            //txtDescription.Text = row["UNIT_DESC"].ToString();
            txtOrdID1.Text = row["ORG_UID"].ToString();
            txtOrdID2.Text = row["ORG_NAME"].ToString();

            txtVendor1.Text = row["VENDOR_UID"].ToString();
            txtVendor2.Text = row["VENDOR_Name"].ToString();

            txtOrdID1.Tag = row["ORG_ID"];
            txtVendor1.Tag = row["VENDOR_ID"];

        }

        private void ClearText()
        {
            txtPOID.Text = "";
            txtPOStatus.Text = "";
            txtRquisitionID.Text = "";
            txtOrdID1.Text = "";
            txtOrdID2.Text = "";

            txtTOC.Text = "";

            txtVendor1.Text = "";
            txtVendor2.Text = "";

            txtTOC.Text = "";
            txtGenDate.Text = "";
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

        private void btnVendor_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnVendor_Clicks);

            string qry = @"
                            select
                                VENDOR_ID,VENDOR_UID,VENDOR_NAME,ORG_ID
                            from
                                INV_VENDOR
                            where 
                                VENDOR_ID like '%%' OR VENDOR_UID like '%%' OR
                                VENDOR_NAME like '%%' OR ORG_ID like '%%'
                            order by VENDOR_ID asc;
                        ";

            string fields = "ID, Code, Name, Org ID";
            string con = "";
            lv.getData(qry, fields, con, "Vendor List");
            lv.Show();
        }

        private void btnVendor_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtVendor1.Tag = retValue[0];
            txtVendor1.Text = retValue[1];
            txtVendor2.Text = retValue[2];
        }

        private void txtPOID_TextChanged(object sender, EventArgs e)
        {
            INV_PODTL common = new INV_PODTL();
            int tryparse;
            if (int.TryParse(txtPOID.Text, out tryparse))
            {
                common.PO_ID = tryparse;

                using (ProcessGetInvPodtl select = new ProcessGetInvPodtl())
                {
                    select.Invoke(common.PO_ID);
                    DataTable table = select.ResultTable;

                    gridControl2.DataSource = table.Copy();
                }
            }
            else
            {
                gridControl2.DataSource = new DataTable().Copy();
            }
        }

        private void txtPOID_TextChanged_Enable(bool enable)
        {
            if (enable)
                txtPOID.TextChanged += new EventHandler(txtPOID_TextChanged);
            else
                txtPOID.TextChanged -= new EventHandler(txtPOID_TextChanged);
        }

        private void AddNewRow()
        {
            //DataTable table = (DataTable)gridControl2.DataSource;
            //if (table == null)
            //{
            //    DataTable tb = new DataTable();
            //    DataRow row = tb.NewRow();
            //    tb.Rows.Add(row);
            //    gridControl2.DataSource = tb.Copy();
            //}
            //else
            //{
            //    DataRow row = table.NewRow();
            //    table.Rows.Add(row);
            //}

            //gridView2.AddNewRow();

            DataTable table = (DataTable)gridControl2.DataSource;

            DataRow row = table.NewRow();

            try
            {
                row["PO_ID"] = int.Parse(txtPOID.Text);
            }
            catch (Exception)
            {
                //row["PO_ID"] = "";
            }
            //row["ITEM_ID"] = "";
            //row["QTY"] = "";
            //row["PO_ITEM_STATUS"] = "";
            row["CREATED_ON"] = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            //row["LAST_MODIFIED_ON"] = "";

            table.Rows.Add(row);
        }

        //private void AddNewDataSource()
        //{
        //    DataTable table = (DataTable)gridControl2.DataSource;
        //    table = new DataTable();
        //}

        private void Grid_ColumnEdit_Setting()
        { 
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox1
                = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            combobox1.Items.Add("FULL");
            combobox1.Items.Add("PARTIAL");
            gridView2.Columns["PO_ITEM_STATUS"].ColumnEdit = combobox1;

            //DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textedit
            //    = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //textedit.EditValueChanged += new EventHandler(textedit_EditValueChanged);
            //foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 
            //    col in gridView2.Columns)
            //{
            //    if (col.ColumnEdit == null)
            //        col.ColumnEdit = textedit;
            //}

            using (ProcessGetInvItem select = new ProcessGetInvItem())
            {
                select.Invoke();

                DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox2
                    = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                
                foreach(DataRow row in select.ResultTable.Rows)
                {
                    combobox2.Items.Add (
                                            row["ITEM_ID"].ToString() 
                                            //+ " " +
                                            //row["ITEM_UID"].ToString() + " " +
                                            //row["ITEM_NAME"].ToString()
                                        );
                }

                gridView2.Columns["ITEM_ID"].ColumnEdit = combobox2;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinedit
                = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();

            spinedit.DisplayFormat.FormatString = "0.00";
            spinedit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            spinedit.EditFormat.FormatString = "0.00";
            spinedit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spinedit.MaxValue = 9999999;

            //spinedit.ReadOnly = true;

            gridView2.Columns["QTY"].ColumnEdit = spinedit;

            gridView2.Columns["PO_ID"].OptionsColumn.ReadOnly = true;

        }

        private void Grid_Editable_Enable(bool enable)
        {
            gridView2.OptionsBehavior.Editable = enable;
        }

        //private void textedit_EditValueChanged(object sender, EventArgs e)
        //{
        //    DevExpress.XtraEditors.TextEdit sd = (DevExpress.XtraEditors.TextEdit)sender;

            
        //}

        private void gridView2_CellValueChanged
            (object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            //int rowhandle = e.RowHandle; 
            //DataColumn column =
            
            //DataTable tablectrl = (DataTable)gridControl2.DataSource;

            //tablectrl.Rows[rowhandle][column] = tableview.Rows[rowhandle][column];

            //gridControl2.DataSource = gridView2.DataSource;

            //DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView sd
            //    = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();            
            
            //DataTable table = (DataTable)gridControl2.DataSource;

            if (e.Column.FieldName == "ITEM_ID")
            {
                //string text = e.Value.ToString();
                //text.Substring(0, text.IndexOf(" ")-1);

                //((DataTable)gridView2.DataSource).Rows[e.RowHandle]["ITEM_ID"] = text;

                //DataTable table = (DataTable)gridControl1.DataSource;
                //foreach (DataRow row in table.Rows)
                //{
                //    if (row["ITEM_ID"].Equals(e.Value))
                //    {
                //        mymsb.ShowAlert("UID2004", 1);
                //        e.Value = "";
                //        break;
                //    }                              
                //}

                //if (!e.Value.Equals(""))
                    
                AddNewRow();

                
            }
        }

        private void New_GridControl2_DataSource()
        {
            DataColumn[] columns =  {
                                        new DataColumn("PO_ID",typeof(int)),
                                        new DataColumn("ITEM_ID",typeof(int)),
                                        new DataColumn("QTY",typeof(string)),
                                        new DataColumn("PO_ITEM_STATUS",typeof(string)),
                                        new DataColumn("CREATED_ON",typeof(DateTime)),
                                        new DataColumn("LAST_MODIFIED_ON",typeof(DateTime)),
                                    };

            DataTable table = new DataTable();
            table.Columns.AddRange(columns);
            gridControl2.DataSource = table.Copy();
        }

    }
}