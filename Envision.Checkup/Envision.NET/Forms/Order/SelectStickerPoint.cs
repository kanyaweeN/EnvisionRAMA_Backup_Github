using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using RIS.Common;

namespace RIS.Forms.Order
{
    public partial class SelectStickerPoint : Form
    {
        int OrderID = 0;
        int i = 0;
        int ExamID = 0;
        DataSet ds;
        string WebPath = "";
        public SelectStickerPoint(int order_id,string name)
        {
            WebPath = ConfigurationSettings.AppSettings["WebReport"].ToString();
            InitializeComponent();
            OrderID = order_id;
            txtName.Text = "Name : " + name;
            txtName.Properties.ReadOnly = true;
        }
        private void BindGridOrder()
        {
            if (ds == null) return;
            if (ds.Tables.Count == 0) return;
            DataTable dtt = ds.Tables[0];
            view1.Columns.Clear();
            gridControl1.DataSource = dtt;
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;
            view1.OptionsView.ShowAutoFilterRow = true;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = true;

            view1.Columns["ORDER_ID"].Caption = "Order No.";
            view1.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
            view1.Columns["ORDER_ID"].Width = 35;
            //view1.Columns["ORDER_ID"].ReadOnly = true;

            //view1.Columns["HN"].Caption = "HN ";
            //view1.Columns["HN"].OptionsColumn.ReadOnly = true;
            //view1.Columns["HN"].BestFit();
            //view1.Columns["HN"].ReadOnly = true;

            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["EXAM_NAME"].BestFit();

            view1.Columns["ORDER_ID"].Visible = true;
            view1.Columns["EXAM_NAME"].Visible = true;
            //view1.Columns["HISName"].ReadOnly = true;

            //view1.Columns["ORDER_DT"].Caption = "Order Date";
            //view1.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            //view1.Columns["ORDER_DT"].BestFit();
            //view1.Columns["ORDER_DT"].ReadOnly = true;

            gridControl1.Focus();
            ExamID = Convert.ToInt32(ds.Tables[0].Rows[0]["EXAM_ID"].ToString());
        }

        private void SelectStickerPoint_Load(object sender, EventArgs e)
        {
            ProcessGetRISOrderdtl getOrdtl = new ProcessGetRISOrderdtl('3', OrderID, 0);
            getOrdtl.Invoke();
            ds = getOrdtl.Result;
            BindGridOrder();
        }
        private void OpenReport(string url)
        {
            RIS.Reports.ReportViewer.frmXtraReportViewer xfm = new RIS.Reports.ReportViewer.frmXtraReportViewer(url);
            xfm.ShowDialog();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=1";
            OpenReport(string.Format(url,OrderID.ToString(),ExamID.ToString()));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=2";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=3";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=4";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=5";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=6";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=7";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            string url = WebPath + @"/ReportManager/ManageRpt.aspx?Envelope=SK&orderid={0}&examid={1}&selectcase=8";
            OpenReport(string.Format(url, OrderID.ToString(), ExamID.ToString()));
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                i = e.FocusedRowHandle;
                ExamID = Convert.ToInt32(ds.Tables[0].Rows[i]["EXAM_ID"].ToString());
            }
        }
    }
}