using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Envision.Common;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmTechnologist_BarcodeChange : Form
    {
        private string BAR_CODE;
        private int ORDER_ID;
        private int EXAM_ID;

        private DataTable dtExam;
        private DataView dvExam;

        private OrderManager orderManger;
        private Order orderItem;

        public frmTechnologist_BarcodeChange(string exam_code, int order_id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BAR_CODE = exam_code;
            this.ORDER_ID = order_id;
            this.Text = "BarCode Exam Mapping";
        }
        private void frmTechnologist_BarcodeChange_Load(object sender, EventArgs e)
        {
            txtLabel.Text = txtLabel.Text.Replace("#", BAR_CODE);
            txtBarCode.Text = BAR_CODE;
            ReloadConsumable();
        }

        private void LoadConsumableData()
        {
            ProcessGetRISExam getData = new ProcessGetRISExam(true);
            getData.Invoke();
            DataTable table = getData.Result.Tables[0];
            table.Columns.Add("colCheck");
            foreach (DataRow dr in table.Rows)
                dr["colCheck"] = "N";
            DataTable table_clone = table.Clone();

            DataRow[] rows = table.Select("[UNIT_ID]=7 AND [SERVICE_TYPE]=3");
            foreach (DataRow dr in rows)
                table_clone.Rows.Add(dr.ItemArray);

            dtExam = table_clone;
            dvExam = new DataView(table);
        }
        private void LoadConsumableFilter()
        {
            
        }
        private void LoadConsumableGrid()
        {
            gridControl1.DataSource = dtExam;
            //gridControl1.DataSource = dvExam;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                gridView1.Columns[k].Visible = false;
                ++k;
            }

            gridView1.Columns["EXAM_UID"].ColVIndex = 0;
            gridView1.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView1.Columns["EXAM_NAME"].ColVIndex = 1;
            gridView1.Columns["EXAM_NAME"].Caption = "Exam Code";

            gridView1.Columns["RATE"].ColVIndex = 2;
            gridView1.Columns["RATE"].Caption = "Rate";

            gridView1.Columns["colCheck"].ColVIndex = 3;
            gridView1.Columns["colCheck"].Caption = "";
            gridView1.Columns["colCheck"].OptionsColumn.ShowCaption = false;
            gridView1.Columns["colCheck"].OptionsColumn.AllowEdit = true;

            RepositoryItemCheckEdit check_item = new RepositoryItemCheckEdit();
            check_item.ValueChecked = "Y";
            check_item.ValueGrayed = "N";
            check_item.ValueUnchecked = "N";
            check_item.AllowGrayed = false;
            check_item.CheckStateChanged += new EventHandler(check_item_CheckStateChanged);
            gridView1.Columns["colCheck"].ColumnEdit = check_item;

            gridView1.BestFitColumns();
        }
        private void ReloadConsumable()
        {
            LoadConsumableData();
            LoadConsumableFilter();
            LoadConsumableGrid();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)gridControl1.DataSource;
            DataRow[] rows = table.Select("colCheck='Y'");
            if (rows.Length > 0)
            {
                orderManger = new OrderManager();
                orderItem = new Order(ORDER_ID);
                DataTable orderTable = orderItem.ItemDetail;
                DataRow orderRow0 = orderTable.Rows[0];
                int i = 0;
                while (i < orderTable.Rows.Count)
                {
                    if (orderTable.Rows[i]["EXAM_ID"].ToString() == string.Empty)
                    {
                        orderTable.Rows[i].Delete();
                        orderTable.AcceptChanges();
                        i = 0;
                    }
                    else
                        i++;
                }
                orderTable.AcceptChanges();

                foreach(DataRow dr in rows)
                {
                    DataRow row = orderTable.NewRow();

                    row["ORDER_ID"] = DBNull.Value;

                    row["EST_START_TIME"] = orderRow0["EST_START_TIME"];
                    row["QTY"] = 1;

                    row["ASSIGNED_TO"] = orderRow0["ASSIGNED_TO"];
                    row["MODALITY_ID"] = orderRow0["MODALITY_ID"];
                    row["PRIORITY"] = orderRow0["PRIORITY"];

                    row["EXAM_ID"] = dr["EXAM_ID"];
                    row["RATE"] = dr["RATE"];
                    row["CLINIC_TYPE"] = orderRow0["CLINIC_TYPE"];
                    row["BPVIEW_ID"] = orderRow0["BPVIEW_ID"];

                    row["EXAM_UID"] = dr["EXAM_UID"];
                    row["EXAM_NAME"] = dr["EXAM_NAME"];

                    orderTable.Rows.Add(row.ItemArray);
                    orderTable.AcceptChanges();

                    EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                }
                orderManger.Add(orderItem);
                bool flag = orderManger[0].Invoke();
                if (flag)
                {
                    //orderItem = new order();
                    //orderManger = new OrderManager();

                    ProcessUpdateRISExam updateData = new ProcessUpdateRISExam();
                    updateData.UpdateBarcode(EXAM_ID, BAR_CODE);
                }
                else
                {
                    MyMessageBox msg = new MyMessageBox();
                    GBLEnvVariable env = new GBLEnvVariable();
                    msg.ShowAlert("UID1024", env.CurrentLanguageID);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //MessageBox.Show("Please select at least 1 rows");
                MyMessageBox msg_box = new MyMessageBox();
                msg_box.ShowAlert("UID2101", new GBLEnvVariable().CurrentLanguageID);
            }
        }
        private void check_item_CheckStateChanged(object sender, EventArgs e)
        {
            column_check_changed();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            column_check_changed();
        }
        private void column_check_changed()
        {
            int row_focus = gridView1.FocusedRowHandle;
            if (row_focus < 0) return;

            DataRow row = gridView1.GetDataRow(row_focus);
            DataTable table = (DataTable)gridControl1.DataSource;
            int row_index = table.Rows.IndexOf(row);

            foreach (DataRow dr in table.Rows)
                dr["colCheck"] = "N";
            table.Rows[row_index]["colCheck"] = "Y";
        }
    }
}