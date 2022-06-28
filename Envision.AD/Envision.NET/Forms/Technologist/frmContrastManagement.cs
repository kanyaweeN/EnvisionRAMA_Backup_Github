using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using DevExpress.Utils;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmContrastManagement : Envision.NET.Forms.Main.MasterForm
    {
        private DataSet ds = new DataSet();
        public frmContrastManagement()
        {
            InitializeComponent();
        }

        private void frmContrastManagement_Load(object sender, EventArgs e)
        {
            dteFromdate.DateTime = DateTime.Now;
            dteTodate.DateTime = DateTime.Now;
            setDataGrid();
            base.CloseWaitDialog();
        }

        private void setDataGrid()
        {
            base.LabelWaitDialog("Loading Data");

            DateTime dteFrom = new DateTime(dteFromdate.DateTime.Year, dteFromdate.DateTime.Month, dteFromdate.DateTime.Day, 0, 0, 0);
            DateTime dteTo = new DateTime(dteTodate.DateTime.Year, dteTodate.DateTime.Month, dteTodate.DateTime.Day, 23, 59, 59);


            ProcessGetRISContrastdtl _arcReaction = new ProcessGetRISContrastdtl();
            DataSet _dsAcr = _arcReaction.GetReactionData();


            ProcessGetRISContrastdtl _getOrd = new ProcessGetRISContrastdtl();
            ds = _getOrd.GetDataByDate(dteFrom, dteTo);

            if (!ds.Tables[0].Columns.Contains("MEDIA_REACTION_DISPLAY"))
                ds.Tables[0].Columns.Add("MEDIA_REACTION_DISPLAY");
            foreach (DataRow rowHis in ds.Tables[0].Rows)
            {
                string _list = "0";
                if(string.IsNullOrEmpty(rowHis["MEDIA_REACTION_LIST"].ToString()))
                    _list = "0";
                else if(rowHis["MEDIA_REACTION_LIST"].ToString() == "No")
                    _list = "0";
                else
                    _list = rowHis["MEDIA_REACTION_LIST"].ToString();
                DataRow[] rowsAcr = _dsAcr.Tables[0].Select("ACR_ID in (" + _list + ")");
                foreach (DataRow rowAcr in rowsAcr)
                {
                    rowHis["MEDIA_REACTION_DISPLAY"] += "[" + rowAcr["ACR_TYPE"].ToString() + "] " + rowAcr["ACR_TEXT"].ToString() + ";";
                }
            }

            ds.AcceptChanges();
            grdData.DataSource = ds.Tables[0];
            setGrid();
            base.CloseWaitDialog();
        }
        private void setGrid()
        {

            for (int i = 0; i < viewMaster.Columns.Count; i++)
            {
                viewMaster.Columns[i].Visible = false;
                viewMaster.Columns[i].OptionsColumn.ReadOnly = true;
                viewMaster.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewMaster.Columns["HN"].ColVIndex = 1;
            viewMaster.Columns["HN"].Caption = "HN";
            viewMaster.Columns["CONTRAST_TEXT"].ColVIndex = 2;
            viewMaster.Columns["CONTRAST_TEXT"].Caption = "Contrast Name";

            viewMaster.Columns["ROUTE_TEXT"].ColVIndex = 3;
            viewMaster.Columns["ROUTE_TEXT"].Caption = "Route";

            viewMaster.Columns["LOT_DISPLAY"].ColVIndex = 4;
            viewMaster.Columns["LOT_DISPLAY"].Caption = "Lot";

            viewMaster.Columns["PATIENT_WEIGHT"].ColVIndex = 5;
            viewMaster.Columns["PATIENT_WEIGHT"].Caption = "Patient Weight";

            viewMaster.Columns["DOSE"].ColVIndex = 6;
            viewMaster.Columns["DOSE"].Caption = "Dose";

            viewMaster.Columns["ACTUAL_QTY"].ColVIndex = 7;
            viewMaster.Columns["ACTUAL_QTY"].Caption = "Actual Qty";

            viewMaster.Columns["INJECTION_RATE"].ColVIndex = 8;
            viewMaster.Columns["INJECTION_RATE"].Caption = "Injection Rate";

            viewMaster.Columns["ONSET_SYMPTOM_DISPLAY"].ColVIndex = 9;
            viewMaster.Columns["ONSET_SYMPTOM_DISPLAY"].Caption = "Onset of symptom";

            viewMaster.Columns["COMMENTS"].ColVIndex = 10;
            viewMaster.Columns["COMMENTS"].Caption = "Comments";

            viewMaster.Columns["MEDIA_REACTION_DISPLAY"].ColVIndex = 11;
            viewMaster.Columns["MEDIA_REACTION_DISPLAY"].Caption = "Contrast Reaction";
        }
        private void viewMaster_DoubleClick(object sender, EventArgs e)
        {
            if (viewMaster.FocusedRowHandle >= 0)
            {
                DataRow row = viewMaster.GetDataRow(viewMaster.FocusedRowHandle);
                frmContrastFillDetail frm = new frmContrastFillDetail(row);
                frm.ShowDialog();
                setDataGrid();
            }
        }

        private void barLotManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmContrastLotManagement frm = new frmContrastLotManagement();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            setDataGrid();
        }

    }
}
