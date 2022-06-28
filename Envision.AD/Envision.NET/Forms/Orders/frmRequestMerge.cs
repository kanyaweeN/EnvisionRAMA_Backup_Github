using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Orders
{
    public partial class frmRequestMerge : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private int xrayreqID;
        private DataSet dataMerge;

        public frmRequestMerge(int request_id)
        {
            InitializeComponent();
            xrayreqID = request_id;

        }
        private void frmRequestMerge_Load(object sender, EventArgs e)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Preparing Data", s);

            ProcessGetXRAYREQ prc = new ProcessGetXRAYREQ();
            dataMerge = prc.GetMergeRequest(xrayreqID);
            DataTable dtMain = dataMerge.Tables[0].Copy();
            DataTable dtMerge = dataMerge.Tables[1].Copy();

            if (!dtMerge.Columns.Contains("colCheck"))
                dtMerge.Columns.Add("colCheck");

            grdData.DataSource = dtMerge;
            setGridColumns();

            dlg.Close();
        }
        private void setGridColumns()
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
            {
                viewData.Columns[i].Visible = false;
                viewData.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewData.Columns["colCheck"].VisibleIndex = 1;
            viewData.Columns["colCheck"].Caption = " ";
            viewData.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            viewData.Columns["colCheck"].Width = 30;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            viewData.Columns["colCheck"].ColumnEdit = chk;

            viewData.Columns["HN"].Visible = true;
            viewData.Columns["HN"].Caption = "HN";
            viewData.Columns["HN"].ColVIndex = 2;
            viewData.Columns["HN"].Width = 60;

            viewData.Columns["PATIENT_NAME"].Visible = true;
            viewData.Columns["PATIENT_NAME"].Caption = "Patient Name";
            viewData.Columns["PATIENT_NAME"].ColVIndex = 3;
            viewData.Columns["PATIENT_NAME"].Width = 130;

            viewData.Columns["ORDER_DT"].Visible = true;
            viewData.Columns["ORDER_DT"].Caption = "Request Datetime";
            viewData.Columns["ORDER_DT"].ColVIndex = 4;
            viewData.Columns["ORDER_DT"].Width = 100;
            viewData.Columns["ORDER_DT"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            viewData.Columns["EXAM_UID"].Visible = true;
            viewData.Columns["EXAM_UID"].Caption = "Exam Code";
            viewData.Columns["EXAM_UID"].Width = 60;
            viewData.Columns["EXAM_UID"].ColVIndex = 5;

            viewData.Columns["EXAM_NAME"].Visible = true;
            viewData.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewData.Columns["EXAM_NAME"].Width = 150;
            viewData.Columns["EXAM_NAME"].ColVIndex = 6;
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = viewData.GetDataRow(viewData.FocusedRowHandle);
            if (chk.Checked)
                rowHandle["colCheck"] = "Y";
            else
                rowHandle["colCheck"] = "N";
        }

        private void btnMerge_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (memReason.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                memReason.Focus();
                return;
            }

            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Processing Data", s);


            DataTable dtGrid = grdData.DataSource as DataTable;
            DataRow[] rowsSelected = dtGrid.Select("colCheck='Y'");

            string _ref_doc_instruction = dataMerge.Tables[0].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            string _clinical_instruction = dataMerge.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString();
            string _reason = memReason.Text.Trim() + "\r\n Old Reason : " + dataMerge.Tables[0].Rows[0]["REASON"].ToString();
            string _comments = dataMerge.Tables[0].Rows[0]["COMMENTS"].ToString();
            int _order_id = Convert.ToInt32(dataMerge.Tables[0].Rows[0]["ORDER_ID"]);
            #region Insert Merge Exam into XRAYREQDTL
            DataTable dtMerge = dataMerge.Tables[1].Copy();

            foreach (DataRow rows in rowsSelected)
            {
                int _order_id_Remove = Convert.ToInt32(rows["ORDER_ID"]);
                DataRow[] rowsAdd = dtMerge.Select("ORDER_ID=" + _order_id_Remove.ToString());
                for (int i = 0; i < rowsAdd.Length; i++)
                {

                    if (i == 0)
                    {
                        if (!string.IsNullOrEmpty(rowsAdd[i]["REF_DOC_INSTRUCTION"].ToString()))
                            _ref_doc_instruction += "\r\n\r\n [Merge From " + rowsAdd[i]["ORDER_ID"].ToString() + "] : " + rowsAdd[i]["REF_DOC_INSTRUCTION"].ToString();
                        if (!string.IsNullOrEmpty(rowsAdd[i]["CLINICAL_INSTRUCTION"].ToString()))
                            _clinical_instruction += "\r\n\r\n [Merge From " + rowsAdd[i]["ORDER_ID"].ToString() + "] : " + rowsAdd[i]["CLINICAL_INSTRUCTION"].ToString();
                        if (!string.IsNullOrEmpty(rowsAdd[i]["REASON"].ToString()))
                            _reason += "\r\n\r\n [Merge From " + rowsAdd[i]["ORDER_ID"].ToString() + "] : " + rowsAdd[i]["REASON"].ToString();
                    }
                    DataRow[] rowCheck = dataMerge.Tables[0].Select("EXAM_ID=" + rowsAdd[i]["EXAM_ID"].ToString());
                    if (rowCheck.Length == 0)
                    {
                        ProcessAddXrayreqdtl addxreqdtl = new ProcessAddXrayreqdtl();
                        addxreqdtl.XRAYREQ.ORDER_ID = _order_id;
                        addxreqdtl.XRAYREQ.STATUS = rowsAdd[i]["STATUS"].ToString();
                        addxreqdtl.XRAYREQ.PRIORITY = rowsAdd[i]["PRIORITY"].ToString();
                        addxreqdtl.XRAYREQ.EXAM_DT = Convert.ToDateTime(rowsAdd[i]["EXAM_DT"]);
                        addxreqdtl.XRAYREQ.EXAM_ID = Convert.ToInt32(rowsAdd[i]["EXAM_ID"]);
                        addxreqdtl.XRAYREQ.EXAM_UID = rowsAdd[i]["EXAM_UID"].ToString();
                        addxreqdtl.XRAYREQ.BPVIEW_ID = Convert.ToInt32(rowsAdd[i]["BPVIEW_ID"]);
                        addxreqdtl.XRAYREQ.BP_VIEW = rowsAdd[i]["BP_VIEW"].ToString();
                        addxreqdtl.XRAYREQ.ASSIGN_TO = Convert.ToInt32(rowsAdd[i]["ASSIGN_TO"].ToString());
                        addxreqdtl.XRAYREQ.RATE = Convert.ToDecimal(rowsAdd[i]["RATE"]);
                        addxreqdtl.XRAYREQ.PAT_DEST_ID = Convert.ToInt32(rowsAdd[i]["PAT_DEST_ID"]);
                        addxreqdtl.XRAYREQ.MODALITY_ID = Convert.ToInt32(rowsAdd[i]["MODALITY_ID"]);
                        addxreqdtl.XRAYREQ.IS_PORTABLE = rowsAdd[i]["IS_PORTABLE"].ToString();
                        addxreqdtl.XRAYREQ.QTY = Convert.ToInt32(rowsAdd[i]["QTY"]);
                        addxreqdtl.XRAYREQ.ORG_ID = env.OrgID;
                        addxreqdtl.XRAYREQ.CREATED_BY = env.UserID;
                        addxreqdtl.XRAYREQ.CLINIC_TYPE = Convert.ToInt32(rowsAdd[i]["CLINIC_TYPE"]);//_xrayreq.CLINIC_TYPE;
                        addxreqdtl.XRAYREQ.COMMENTS = rowsAdd[i]["COMMENTS"].ToString();
                        addxreqdtl.Invoke();
                    }
                    dtMerge.Rows.Remove(rowsAdd[i]);
                    dtMerge.AcceptChanges();
                }
                ProcessUpdateXRAYREQ updateCancel = new ProcessUpdateXRAYREQ();
                updateCancel.updateCancel(_order_id_Remove);
            }
            #endregion
            #region Update Merge Appointment into XRAYREQ
            ProcessUpdateXRAYREQ updateRequest = new ProcessUpdateXRAYREQ();
            updateRequest.updateMergeRequest(_order_id, _clinical_instruction, _ref_doc_instruction, _reason);
            #endregion

            dlg.Close();
            this.Close();
        }
        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

    }
}