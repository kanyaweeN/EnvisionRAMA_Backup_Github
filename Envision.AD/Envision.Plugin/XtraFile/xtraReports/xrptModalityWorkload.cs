using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptModalityWorkload : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet dsSource;

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string DeptName { get; set; }

        public xrptModalityWorkload(DataSet ds)
        {
            InitializeComponent();
            dsSource = ds;
            ReloadData();
        }
        private void xrptModalityWorkload_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            
        }
        private void xrptModalityWorkload_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbHeader.Text = lbHeader.Text.Replace("[DateFrom]", DateFrom);
            lbHeader.Text = lbHeader.Text.Replace("[DateTo]", DateTo);
            lbDept.Text = lbDept.Text.Replace("[DeptName]", DeptName);
        }

        private void LoadData()
        {
            this.DataSource = dsSource;        
        }
        private void LoadControl()
        {
            cellModality.DataBindings.Add("Text", dsSource, "MODALITY_NAME", "");
            cellRegMorning.DataBindings.Add("Text", dsSource, "REG_MON_TOTAL", "");
            cellRegAfternoon.DataBindings.Add("Text", dsSource, "REG_AFTER_TOTAL", "");
            cellSpecialClinic.DataBindings.Add("Text", dsSource, "SPC_TOTAL", "");
            cellPremium.DataBindings.Add("Text", dsSource, "PRM_TOTAL", "");

            #region
            int TotalRegMon = 0;
            int TotalRegAft = 0;
            int TotalSpc = 0;
            int TotalPrm = 0;

            foreach (DataRow dr in dsSource.Tables[0].Rows)
            {
                TotalRegMon += Convert.ToInt32(dr["REG_MON_TOTAL"]);
                TotalRegAft += Convert.ToInt32(dr["REG_AFTER_TOTAL"]);
                TotalSpc += Convert.ToInt32(dr["SPC_TOTAL"]);
                TotalPrm += Convert.ToInt32(dr["PRM_TOTAL"]);
            }

            cellTotalRegMorning.Text = TotalRegMon.ToString();
            cellTotalRegAfternoon.Text = TotalRegAft.ToString();
            cellTotalSpecialClinic.Text = TotalSpc.ToString();
            cellTotalPremium.Text = TotalPrm.ToString();

            #endregion
        }
        private void ReloadData()
        {
            LoadData();
            LoadControl();
        }
    }
}
