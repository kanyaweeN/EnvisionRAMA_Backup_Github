using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Controls;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmContrastFillDetail : Envision.NET.Forms.Main.MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        DataRow dr;
        DataSet _dsAcr;
        int _contrastDtl_id = 0;

        public frmContrastFillDetail()
        {
            InitializeComponent();
        }
        public frmContrastFillDetail(DataRow row)
        {
            InitializeComponent();
            dr = row;
        }

        private void frmContrastFillDetail_Load(object sender, EventArgs e)
        {
            _contrastDtl_id = 0;
            setDataReaction();
            setDataContrastDtl();
            setDataRoute();
            setDataContrast();
          
            cmbOnsetOfSymptom.SelectedIndex = 0;
            chkcmbAcuteReactions.Visible = chkAcuteReactionYes.Checked;
            speContrastMediaExtravasation.Visible = chkContrastMediaExtravasationYes.Checked;

            lblPatientDetail.Text = " HN : " + dr["HN"].ToString();
            _contrastDtl_id = Convert.ToInt32(dr["CONTRASTDTL_ID"]);

            spePatientWeight.Value = Convert.ToDecimal(dr["PATIENT_WEIGHT"]);
            cmbContrastName.EditValue = new contrastData(Convert.ToInt32(dr["CONTRAST_ID"]), dr["CONTRAST_TEXT"].ToString());
            cmbRoute.EditValue = new routeData(Convert.ToInt32(dr["ROUTE_ID"]), dr["ROUTE_TEXT"].ToString());
            cmbLot.EditValue = new lotData(Convert.ToInt32(dr["LOT_ID"]), dr["LOT_DISPLAY"].ToString());
            speDose.Value = Convert.ToDecimal(dr["DOSE"]);
            speActualQuantity.Value = Convert.ToDecimal(dr["ACTUAL_QTY"]);
            speSideEffect.Value = Convert.ToDecimal(dr["INJECTION_RATE"]);
            speOnsetOfSymptom.Value = Convert.ToDecimal(dr["ONSET_SYMPTOM_VALUE"]);
            cmbOnsetOfSymptom.EditValue = dr["ONSET_SYMPTOM_TYPE"].ToString();

            //calculateAutoCalculate();

            chkAcuteReactionYes.Checked = false;
            chkAcuteReactionNo.Checked = false;
            if (dr["MEDIA_REACTION_LIST"].ToString() == "")
            {
                chkAcuteReactionYes.Checked = false;
                chkAcuteReactionNo.Checked = false;
            }
            else if (dr["MEDIA_REACTION_LIST"].ToString() == "No")
            {
                chkAcuteReactionNo.Checked = true;
            }
            else
            {
                chkAcuteReactionYes.Checked = true;
                chkcmbAcuteReactions.EditValue = dr["MEDIA_REACTION_LIST"].ToString();
                chkcmbAcuteReactions.RefreshEditValue();
            }

            chkContrastMediaExtravasationYes.Checked = false;
            chkContrastMediaExtravasationNo.Checked = false;
            if (dr["MEDIA_EXTRAVASATION"].ToString() == "0.00")
            {
                chkContrastMediaExtravasationNo.Checked = true;
            }
            else if (dr["MEDIA_EXTRAVASATION"].ToString() == "-1.00")
            {
                chkContrastMediaExtravasationYes.Checked = false;
                chkContrastMediaExtravasationNo.Checked = false;
            }
            else
            {
                chkContrastMediaExtravasationYes.Checked = true;
                speContrastMediaExtravasation.Value = Convert.ToDecimal(dr["MEDIA_EXTRAVASATION"]);
            }

            memComments.Text = dr["COMMENTS"].ToString();
        }
        private void setDataContrastDtl()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetRISContrastdtl _getContrastHis = new ProcessGetRISContrastdtl();
            DataSet dsHis = _getContrastHis.GetDataByHN(dr["HN"].ToString());
            if (!dsHis.Tables[0].Columns.Contains("MEDIA_REACTION_DISPLAY"))
                dsHis.Tables[0].Columns.Add("MEDIA_REACTION_DISPLAY");
            foreach (DataRow rowHis in dsHis.Tables[0].Rows)
            {
                string _list = "0";
                if (string.IsNullOrEmpty(rowHis["MEDIA_REACTION_LIST"].ToString()))
                    _list = "0";
                else if (rowHis["MEDIA_REACTION_LIST"].ToString() == "No")
                    _list = "0";
                else
                    _list = rowHis["MEDIA_REACTION_LIST"].ToString();
                DataRow[] rowsAcr = _dsAcr.Tables[0].Select("ACR_ID in (" + _list + ")");
                foreach (DataRow rowAcr in rowsAcr)
                {
                    rowHis["MEDIA_REACTION_DISPLAY"] += "[" + rowAcr["ACR_TYPE"].ToString() + "] " + rowAcr["ACR_TEXT"].ToString() + ";";
                }
            }

            grdDataContrastHistory.DataSource = dsHis.Tables[0];

            for (int i = 0; i < viewDataContrastHistory.Columns.Count; i++)
            {
                viewDataContrastHistory.Columns[i].Visible = false;
                viewDataContrastHistory.Columns[i].OptionsColumn.ReadOnly = true;
                viewDataContrastHistory.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewDataContrastHistory.Columns["CASE_DATETIME"].ColVIndex = 1;
            viewDataContrastHistory.Columns["CASE_DATETIME"].Caption = "Datetime";
            viewDataContrastHistory.Columns["CONTRAST_TEXT"].ColVIndex = 2;
            viewDataContrastHistory.Columns["CONTRAST_TEXT"].Caption = "Contrast Name";
            viewDataContrastHistory.Columns["ROUTE_TEXT"].ColVIndex = 3;
            viewDataContrastHistory.Columns["ROUTE_TEXT"].Caption = "Route";
            viewDataContrastHistory.Columns["LOT_DISPLAY"].ColVIndex = 4;
            viewDataContrastHistory.Columns["LOT_DISPLAY"].Caption = "Lot";
            viewDataContrastHistory.Columns["ACTUAL_QTY"].ColVIndex = 5;
            viewDataContrastHistory.Columns["ACTUAL_QTY"].Caption = "Act. Qty";
            viewDataContrastHistory.Columns["MEDIA_REACTION_DISPLAY"].ColVIndex = 6;
            viewDataContrastHistory.Columns["MEDIA_REACTION_DISPLAY"].Caption = "Contrast Reaction";

            dlg.Close();
        }

        private void setDataContrast()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastManagement(2, DateTime.Now, DateTime.Now, "");

            cmbContrastName.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbContrastName.Properties.Items;
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    colls.Add(new contrastData(Convert.ToInt32(dr["ID"]), dr["CONTRAST_NAME"].ToString()));
                }
            }
            finally
            {
                colls.EndUpdate();
            }
            dlg.Close();

        }
        private void setDataRoute()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastManagement(1, DateTime.Now, DateTime.Now, "");

            cmbRoute.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbRoute.Properties.Items;
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    colls.Add(new routeData(Convert.ToInt32(dr["ID"]), dr["RouteName"].ToString()));

                }
            }
            finally
            {
                colls.EndUpdate();
            }

            dlg.Close();
        }
        private void setDataLot(int contrastId)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastLot(contrastId);

            cmbLot.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbLot.Properties.Items;
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    colls.Add(new lotData(Convert.ToInt32(dr["LOT_ID"]), dr["LOT_DISPLAY"].ToString()));
                }
            }
            finally
            {
                colls.EndUpdate();
            }
            dlg.Close();
        }
        private void setDataReaction()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetRISContrastdtl _arcReaction = new ProcessGetRISContrastdtl();
            _dsAcr = _arcReaction.GetReactionData();

            chkcmbAcuteReactions.Properties.Items.Clear();
            try
            {
                foreach (DataRow dr in _dsAcr.Tables[0].Rows)
                {
                    chkcmbAcuteReactions.Properties.Items.Add(Convert.ToInt32(dr["ACR_ID"]), dr["ACR_DISPLAY"].ToString(), System.Windows.Forms.CheckState.Unchecked, true);
                }
            }
            finally
            {
            }
            dlg.Close();

        }
        private void calculateAutoCalculate()
        {
            try
            {
                decimal _autCalculate = speDose.Value * spePatientWeight.Value;
                speAutoCalculate.Value = _autCalculate;
            }
            catch (Exception ex)
            {
                speAutoCalculate.Value = 0;
            }

        }

        private void btnSaveContrast_Click(object sender, EventArgs e)
        {
            contrastData _contrastData = cmbContrastName.SelectedItem as contrastData;
            routeData _routeData = cmbRoute.SelectedItem as routeData;
            lotData _lotData = cmbLot.SelectedItem as lotData;

            ProcessUpdateRISContrastDtl _update = new ProcessUpdateRISContrastDtl();
            _update.RIS_CONTRASTDTL.CONTRASTDTL_ID = _contrastDtl_id;
            _update.RIS_CONTRASTDTL.CONTRAST_ID = _contrastData.id();
            _update.RIS_CONTRASTDTL.PATIENT_WEIGHT = spePatientWeight.Value;
            _update.RIS_CONTRASTDTL.ROUTE_ID = _routeData.id();
            _update.RIS_CONTRASTDTL.LOT_ID = _lotData.id();
            _update.RIS_CONTRASTDTL.DOSE = speDose.Value;
            _update.RIS_CONTRASTDTL.ACTUAL_QTY = speActualQuantity.Value;
            _update.RIS_CONTRASTDTL.INJECTION_RATE = speSideEffect.Value;
            _update.RIS_CONTRASTDTL.ONSET_SYMPTOM_TYPE = cmbOnsetOfSymptom.EditValue.ToString();
            _update.RIS_CONTRASTDTL.ONSET_SYMPTOM_VALUE = speOnsetOfSymptom.Value;
            if (chkAcuteReactionYes.Checked)
                _update.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = chkcmbAcuteReactions.EditValue.ToString();
            else if (chkAcuteReactionNo.Checked)
                _update.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = "No";
            else
                _update.RIS_CONTRASTDTL.MEDIA_REACTION_LIST = "";
            if (chkContrastMediaExtravasationYes.Checked)
                _update.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = speContrastMediaExtravasation.Value;
            else if (chkContrastMediaExtravasationNo.Checked)
                _update.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = 0;
            else
                _update.RIS_CONTRASTDTL.MEDIA_EXTRAVASATION = -1;
            _update.RIS_CONTRASTDTL.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]); 
            _update.RIS_CONTRASTDTL.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]); 
            _update.RIS_CONTRASTDTL.XRAYREQ_ID = Convert.ToInt32(dr["XRAYREQ_ID"]); 
            _update.RIS_CONTRASTDTL.COMMENTS = memComments.Text;
            _update.RIS_CONTRASTDTL.LAST_MODIFIED_BY = env.UserID;
            _update.Invoke();

            this.Close();
        }

        private void cmbContrastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            contrastData _contrastSelected = cmbContrastName.SelectedItem as contrastData;
            if (_contrastSelected != null)
            {
                setDataLot(_contrastSelected.id());
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            routeData _routeSelected = cmbRoute.SelectedItem as routeData;
            if (_routeSelected != null)
            {
                if (_routeSelected.id() == 108 || _routeSelected.id() == 109)
                {
                    lblContrastMediaExtravasation.Visible = false;
                    chkContrastMediaExtravasationNo.Visible = false;
                    chkContrastMediaExtravasationYes.Visible = false;
                    speContrastMediaExtravasation.Visible = false;
                }
                else
                {
                    lblContrastMediaExtravasation.Visible = true;
                    chkContrastMediaExtravasationNo.Visible = true;
                    chkContrastMediaExtravasationYes.Visible = true;
                    speContrastMediaExtravasation.Visible = true;
                }
            }
        }

        private void chkContrastMediaExtravasationYes_CheckedChanged(object sender, EventArgs e)
        {
            speContrastMediaExtravasation.Visible = false;
            if (chkContrastMediaExtravasationYes.Checked)
            {
                chkContrastMediaExtravasationNo.Checked = false;
                speContrastMediaExtravasation.Visible = true;
            }
        }
        private void chkContrastMediaExtravasationNo_CheckedChanged(object sender, EventArgs e)
        {
            speContrastMediaExtravasation.Visible = false;
            if (chkContrastMediaExtravasationNo.Checked)
            {
                chkContrastMediaExtravasationYes.Checked = false;
                speContrastMediaExtravasation.Visible = false;
            }
        }

        private void chkAcuteReactionYes_CheckedChanged(object sender, EventArgs e)
        {
            chkcmbAcuteReactions.Visible = false;
            if (chkAcuteReactionYes.Checked)
            {
                chkAcuteReactionNo.Checked = false;
                chkcmbAcuteReactions.Visible = true;
            }
        }
        private void chkAcuteReactionNo_CheckedChanged(object sender, EventArgs e)
        {
            chkcmbAcuteReactions.Visible = false;
            if (chkAcuteReactionNo.Checked)
            {
                chkAcuteReactionYes.Checked = false;
                chkcmbAcuteReactions.Visible = false;
            }
        }

        private void spePatientWeight_EditValueChanged(object sender, EventArgs e)
        {
            calculateAutoCalculate();
        }

        private void speDose_EditValueChanged(object sender, EventArgs e)
        {
            calculateAutoCalculate();
        }
        

    }
}
