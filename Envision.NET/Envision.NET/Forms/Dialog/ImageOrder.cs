using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using Miracle.Scanner;
namespace Envision.NET.Forms.Dialog
{
    public partial class ImageOrder : Form
    {
        private Envision.Common.GBLEnvVariable env = new Envision.Common.GBLEnvVariable();
        private int orderID,scheduleID;
        private string _Mode;
        public ImageOrder(int OrderID)
        {
            InitializeComponent();
            orderID = OrderID;
            SetGridImage();
        }
        public ImageOrder(int ScheduleID,string mode)
        {
            InitializeComponent();
            scheduleID = ScheduleID;
            _Mode = mode;
            SetGridImage();
        } 
        private void SetGridImage()
        {
            DataTable dtt = new DataTable();
            ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
            switch (_Mode)
            {
                case "Schedule":
                    process.RIS_ORDERIMAGE.ORDER_ID = 0;
                    process.RIS_ORDERIMAGE.SCHEDULE_ID = scheduleID;
                    dtt = process.GetDataByID();
                    break;
                default:
                    process.RIS_ORDERIMAGE.ORDER_ID = orderID;
                    process.Invoke();
                    dtt = process.Result.Tables[0].Copy();
                    break;
            }
            
            grdImage.DataSource = dtt;
            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["SL_NO"].OptionsColumn.ReadOnly = true;
            view1.Columns["SL_NO"].Visible = true;
            view1.Columns["SL_NO"].Caption = "SL No.";
            view1.Columns["SL_NO"].BestFit();

            RepositoryItemHyperLinkEdit link = new RepositoryItemHyperLinkEdit();
            link.Click += new EventHandler(link_Click);
            view1.Columns["IMAGE_NAME"].Caption = "Image File Name";
            view1.Columns["IMAGE_NAME"].Visible = true;
            view1.Columns["IMAGE_NAME"].Width = 200;
            view1.Columns["IMAGE_NAME"].ColumnEdit = link;



            view1.Columns["CREATED_ON"].Caption = "Create Date";
            view1.Columns["CREATED_ON"].Visible = true;
            view1.Columns["CREATED_ON"].OptionsColumn.ReadOnly = true;
            view1.Columns["CREATED_ON"].BestFit();
       
        }
        void link_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                if (dr != null)
                {
                    PointerStruct.ImageUrl = env.PacsUrl2;
                    string url = PointerStruct.ImageUrl + "/" + dr["IMAGE_NAME"].ToString();
                     //System.Diagnostics.Process.Start(url);

                     Envision.NET.Reports.ReportViewer.frmXtraReportViewer Browser = new Envision.NET.Reports.ReportViewer.frmXtraReportViewer(url);
                     Browser.Text = dr["IMAGE_NAME"].ToString();
                     Browser.StartPosition = FormStartPosition.CenterScreen;
                     Browser.ShowDialog();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}