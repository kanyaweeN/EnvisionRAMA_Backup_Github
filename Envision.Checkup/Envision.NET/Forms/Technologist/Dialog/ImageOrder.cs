using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
namespace RIS.Forms.Technologist.Dialog
{
    public partial class ImageOrder : Form
    {
        private RIS.Common.Common.GBLEnvVariable env = new RIS.Common.Common.GBLEnvVariable();
        private int orderID;
        public ImageOrder(int OrderID)
        {
            InitializeComponent();
            orderID = OrderID;
            SetGridImage();
        }
        private void SetGridImage()
        {
            ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
            process.RIS_ORDERIMAGE.ORDER_ID = orderID;
            process.Invoke();
            DataTable dtt = process.Result.Tables[0].Copy();
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
                    string url = env.PacsUrl2 + "/" + dr["IMAGE_NAME"].ToString();
                    //System.Diagnostics.Process.Start(url, "_new");
                    RIS.Reports.ReportViewer.frmXtraReportViewer Browser = new RIS.Reports.ReportViewer.frmXtraReportViewer(url);
                    //RIS.Operational.EnvisionBrowser.EnvisionBrowser Browser = new RIS.Operational.EnvisionBrowser.EnvisionBrowser(url);
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