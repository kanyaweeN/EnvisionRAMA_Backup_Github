using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using System.Data.Common;

namespace Envision.NET.Forms.ResultEntry.ConsultCase
{
    public partial class frmConsultCaseManagement : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string ACCESSION_NO;
        private DataTable dtConCase = new DataTable();
        private DataTable dtExamConsult = new DataTable();
        //private DataTable dttExamPanel = new DataTable();

        public frmConsultCaseManagement(string ACCESSION_NO)
        {
            InitializeComponent();
            this.ACCESSION_NO = ACCESSION_NO;
        }

        private void frmConsultCaseManagement_Load(object sender, EventArgs e)
        {
            ReloadCunsultCase();
        }

        private void LoadCunsultCaseData()
        {
            Envision.BusinessLogic.ResultEntry GetResult = new Envision.BusinessLogic.ResultEntry();
            DataSet ds = GetResult.GetConsultCaseData(ACCESSION_NO);
            //if (Miracle.Util.Utilities.IsHaveData(ds))
            dtConCase = ds.Tables[0];

            LookUpSelect lk = new LookUpSelect();
            dtExamConsult = lk.SelectExamConsultCase().Tables[0];
        }
        private void LoadCunsultCaseFilter()
        {

        }
        private void LoadCunsultCaseControl()
        {
            DataRow row = dtConCase.Rows[0];

            txtHN.Text = row["HN"].ToString();
            txtName.Text = row["NAME"].ToString();
            txtGender.Text = row["GENDER"].ToString();
            txtAge.Text = row["AGE"].ToString();

            txtExamID.Text = row["EXAM_UID"].ToString();
            txtExamName.Text = row["EXAM_NAME"].ToString();
            txtFinalizeBy.Text = row["FINALIZED_BY"].ToString();
            txtFinalizeOn.Text = row["FINALIZED_ON"].ToString();
            txtOrderingDoctor.Text = row["ORDERING_DOC"].ToString();
            txtOrderingDept.Text = row["ORDERING_DEPT"].ToString();
        }
        private void LoadCunsultCaseGrid()
        {
            #region Data Making
            DataTable tb = new DataTable();
            tb.Columns.Add("EXAM_UID");
            tb.Columns.Add("EXAM_NAME");
            tb.Columns.Add("QTY");
            tb.Columns.Add("RATE");
            tb.Columns.Add("colDel");
            tb.AcceptChanges();

            DataRow newRow = tb.NewRow();
            newRow["EXAM_UID"] = "";
            newRow["EXAM_NAME"] = "";
            newRow["QTY"] = "";
            newRow["RATE"] = "";
            newRow["colDel"] = "";
            tb.Rows.Add(newRow);
            tb.AcceptChanges();
            #endregion

            gcConsultOrder.DataSource = tb;
            gvConsultOrder.OptionsView.ColumnAutoWidth = true;

            foreach (BandedGridColumn cl in gvConsultOrder.Columns)
            {
                cl.Visible = false;
                cl.OptionsColumn.AllowEdit = false;
            }

            gvConsultOrder.Columns["EXAM_UID"].Caption = "Exam Code";
            gvConsultOrder.Columns["EXAM_UID"].ColVIndex = 1;

            gvConsultOrder.Columns["EXAM_NAME"].Caption = "Exam Name";
            gvConsultOrder.Columns["EXAM_NAME"].ColVIndex = 2;

            gvConsultOrder.Columns["QTY"].Caption = "Qty";
            gvConsultOrder.Columns["QTY"].ColVIndex = 3;

            gvConsultOrder.Columns["RATE"].Caption = "Rate";
            gvConsultOrder.Columns["RATE"].ColVIndex = 4;

            gvConsultOrder.Columns["colDel"].Caption = "";
            gvConsultOrder.Columns["colDel"].ColVIndex = 4;

            //RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            //repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //repositoryItemLookUpEdit1.ImmediatePopup = true;
            //repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //repositoryItemLookUpEdit1.AutoHeight = false;
            //repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            //repositoryItemLookUpEdit1.ValueMember = "EXAM_UID";
            //repositoryItemLookUpEdit1.DropDownRows = 5;
            //repositoryItemLookUpEdit1.DataSource = dtExamConsult;
            //repositoryItemLookUpEdit1.NullText = string.Empty;
            ////repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
            //repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
            //gvConsultOrder.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
            //gvConsultOrder.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            //repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //repositoryItemLookUpEdit2.ImmediatePopup = true;
            //repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //repositoryItemLookUpEdit2.AutoHeight = false;
            //repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            //repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            //repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
            //repositoryItemLookUpEdit2.DropDownRows = 5;
            //repositoryItemLookUpEdit2.DataSource = dtExamConsult;
            //repositoryItemLookUpEdit2.NullText = string.Empty;
            ////repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            //repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            //gvConsultOrder.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            //gvConsultOrder.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            //RepositoryItemSpinEdit spe = new RepositoryItemSpinEdit();
            //spe.ValueChanged += new EventHandler(Qty_ValueChanged);
            //gvConsultOrder.Columns["QTY"].ColumnEdit = spe;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.BestFitWidth = 9;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            //btn.Click += new EventHandler(btnDeleteRow_Click);
            gvConsultOrder.Columns["colDel"].Caption = string.Empty;
            gvConsultOrder.Columns["colDel"].ColumnEdit = btn;
            gvConsultOrder.Columns["colDel"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gvConsultOrder.Columns["colDel"].Width = 10;
            gvConsultOrder.Columns["colDel"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            gvConsultOrder.BestFitColumns();
        }
        private void ReloadCunsultCase()
        {
            LoadCunsultCaseData();
            LoadCunsultCaseFilter();
            LoadCunsultCaseControl();
            LoadCunsultCaseGrid();
        }

        #region Consult Case
        private void btnStartWriting_Click(object sender, EventArgs e)
        {
            DataRow row = dtConCase.Rows[0];

            int orderID = Convert.ToInt32(row["ORDER_ID"]);
            string hn = row["HN"].ToString();
            string exam_name = row["EXAM_NAME"].ToString() + " (" + row["EXAM_UID"].ToString() + ") ";
            string accno = row["ACCESSION_NO"].ToString();

            frmAddendum frmAdden = new frmAddendum(accno, exam_name, orderID, hn);
            if (frmAdden.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    if (e.AcceptValue)
        //    {
        //        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
        //        int row = view1.FocusedRowHandle;
        //        if (e.Value.ToString() != string.Empty)
        //        {
        //            bool flag = updateExamName(e.Value.ToString());
        //            if (flag)
        //            {
        //                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
        //                {
        //                    view1.FocusedRowHandle = row;
        //                    view1.FocusedColumn = view1.VisibleColumns[2];
        //                }
        //                else
        //                {
        //                    view1.FocusedColumn = view1.VisibleColumns[0];
        //                    view1.MoveNext();
        //                }
        //            }
        //            else
        //            {
        //                msg.ShowAlert("UID1014", env.CurrentLanguageID);
        //                e.AcceptValue = false;
        //            }
        //        }
        //    }
        //}
        //void examCode_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    if (e.AcceptValue)
        //    {
        //        DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
        //        int row = view1.FocusedRowHandle;
        //        if (e.Value.ToString() != string.Empty)
        //        {
        //            bool flag = updateExamUID(e.Value.ToString());
        //            if (flag)
        //            {
        //                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
        //                {
        //                    view1.FocusedRowHandle = row;
        //                    view1.FocusedColumn = view1.VisibleColumns[2];
        //                }
        //                else
        //                {
        //                    view1.FocusedColumn = view1.VisibleColumns[0];
        //                    view1.MoveNext();
        //                }
        //            }
        //            else
        //            {
        //                msg.ShowAlert("UID1014", env.CurrentLanguageID);
        //                e.AcceptValue = false;
        //            }
        //        }
        //    }
        //}
        //void Qty_ValueChanged(object sender, EventArgs e)
        //{
        //    string str = "";
        //    SpinEdit spe = new SpinEdit();
        //    spe = (SpinEdit)sender;
        //    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
        //    int sp = Convert.ToInt32(spe.Value.ToString());
        //    if (sp > 0)
        //    {
        //        dr["QTY"] = sp;
        //        dr.AcceptChanges();
        //        calTotal();
        //    }
        //    else
        //    {
        //        dr["QTY"] = 0;
        //        dr.AcceptChanges();
        //        calTotal();
        //    }
        //}
        //private void btnDeleteRow_Click(object sender, EventArgs e)
        //{
        //    DataView dv = (DataView)grdOrderdtl.DataSource;
        //    DataTable dtt = dv.Table;
        //    if (dtt.Rows.Count > 0)
        //    {
        //        if (dv.Count == 1)
        //        {
        //            if (dv[0][24].ToString() == "N")
        //            {
        //                if (dv[0][6].ToString() == string.Empty)
        //                {
        //                    //treeRadio.Nodes.Clear();
        //                    //treeRadio.Nodes.Add("No Radiologist");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            DataRow dr = null;
        //            dr = dtt.Rows[view1.FocusedRowHandle];
        //            if (dr["EXAM_ID"].ToString().Trim() == string.Empty && _modality.ToString().Trim() == string.Empty)
        //                return;
        //            string s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
        //            if (s == "2")
        //            {
        //                DataRow drAdd = dttUpdate.NewRow();
        //                for (int i = 0; i < dttUpdate.Columns.Count; i++)
        //                    drAdd[i] = dr[i];
        //                drAdd["IS_DELETED"] = "Y";
        //                dttUpdate.Rows.Add(drAdd);
        //                dttUpdate.AcceptChanges();

        //                dtt.Rows[view1.FocusedRowHandle].Delete();
        //                dtt.AcceptChanges();
        //                dv = new DataView(dtt);
        //                grdOrderdtl.DataSource = dv;
        //                if (dtt.Rows.Count == 1)
        //                {
        //                    if (dtt.Rows[0]["MODALITY_ID"].ToString().Trim() == string.Empty)
        //                    {
        //                        //treeRadio.Nodes.Clear();
        //                        //treeRadio.Nodes.Add("No Radiologist");
        //                    }
        //                }
        //            }
        //        }
        //        calTotal();
        //        gridBestFitColumn();
        //    }
        //}

        //private void InsertConsultCaseData()
        //{
        //    DbTransaction tran = null;
        //    DbConnection con = null;

        //    DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
        //    con = db.Connection();
        //    con.Open();
        //    tran = con.BeginTransaction();

        //    ProcessAddRISOrder processAdd = new ProcessAddRISOrder();
        //    processAdd.Transaction = tran;

        //    ProcessAddRISOrderdtl processAddDetails = new ProcessAddRISOrderdtl();
        //    processAddDetails.UseTransaction = tran;

        //    processAdd.RIS_ORDER.REG_ID = patient.Reg_ID;
        //    processAdd.RIS_ORDER.HN = patient.Reg_UID;
        //    processAdd.RIS_ORDER.VISIT_NO = visitNumber;
        //    processAdd.RIS_ORDER.ADMISSION_NO = item.ADMISSION_NO;
        //    processAdd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
        //    processAdd.RIS_ORDER.SCHEDULE_ID = item.SCHEDULE_ID;
        //    processAdd.RIS_ORDER.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
        //    processAdd.RIS_ORDER.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
        //    processAdd.RIS_ORDER.REASON = item.REASON;
        //    processAdd.RIS_ORDER.DIAGNOSIS = item.DIAGNOSIS;
        //    processAdd.RIS_ORDER.ICD_ID = item.ICD_ID;
        //    processAdd.RIS_ORDER.ORG_ID = item.ORG_ID;
        //    processAdd.RIS_ORDER.CREATED_BY = item.CREATED_BY;
        //    processAdd.RIS_ORDER.ORDER_DT = item.ORDER_DT;
        //    processAdd.RIS_ORDER.SCHEDULE_ID = scheduleID;
        //    processAdd.RIS_ORDER.REF_DOC = item.REF_DOC;
        //    processAdd.RIS_ORDER.REF_UNIT = item.REF_UNIT;
        //    processAdd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
        //    processAdd.RIS_ORDER.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
        //    processAdd.RIS_ORDER.PAT_STATUS = item.PAT_STATUS;
        //    processAdd.RIS_ORDER.LMP_DT = item.LMP_DT;
        //    processAdd.Invoke();

        //    foreach (DataRow dr in dtOrder.Rows)
        //    {
        //        processAddDetails.RIS_ORDERDTL.ORDER_ID = processAdd.RIS_ORDER.ORDER_ID;
        //        processAddDetails.RIS_ORDERDTL.EXAM_DT = item.ORDER_DT;
        //        processAddDetails.RIS_ORDERDTL.ORG_ID = item.ORG_ID;
        //        processAddDetails.RIS_ORDERDTL.CREATED_BY = item.CREATED_BY;
        //        processAddDetails.RIS_ORDERDTL.EST_START_TIME = dr["EST_START_TIME"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["EST_START_TIME"]);
        //        processAddDetails.RIS_ORDERDTL.QTY = Convert.ToByte(dr["QTY"].ToString());
        //        processAddDetails.RIS_ORDERDTL.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
        //        processAddDetails.RIS_ORDERDTL.MODALITY_ID = (int)dr["MODALITY_ID"];
        //        processAddDetails.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"].ToString());
        //        processAddDetails.RIS_ORDERDTL.EXAM_ID = (int)dr["EXAM_ID"];
        //        processAddDetails.RIS_ORDERDTL.RATE = (decimal)dr["RATE"];
        //        processAddDetails.RIS_ORDERDTL.CLINIC_TYPE = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];
        //        if (processAddDetails.RIS_ORDERDTL.MODALITY_ID > 0)
        //        {
        //            //processAddDetails.RIS_ORDERDTL.ACCESSION_NO = getAccessionNo(processAddDetails.RIS_ORDERDTL.MODALITY_ID);
        //            processAddDetails.RIS_ORDERDTL.ACCESSION_NO = getAccessionNo(processAddDetails.RIS_ORDERDTL.MODALITY_ID, item.REF_UNIT);
        //        }
        //        else
        //        {
        //            processAddDetails.RIS_ORDERDTL.MODALITY_ID = 1;// 86;
        //            processAddDetails.RIS_ORDERDTL.ACCESSION_NO = GenHN();
        //        }
        //        int bv_view = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString()) ? 0 : (int)dr["BPVIEW_ID"];
        //        //processAddDetails.RIS_ORDERDTL.BV_VIEW = bv_view;
        //        processAddDetails.RIS_ORDERDTL.BPVIEW_ID = bv_view;
        //        processAddDetails.RIS_ORDERDTL.COMMENTS = dr["COMMENTS"].ToString();
        //        processAddDetails.RIS_ORDERDTL.HIS_SYNC = 'N';// SendBilling(processAddDetails.RIS_ORDERDTL.ACCESSION_NO);
        //        if (string.IsNullOrEmpty(dr["PREPARATION_ID"].ToString()))
        //        {
        //            processAddDetails.RIS_ORDERDTL.PREPARATION_ID = 0;
        //        }
        //        else
        //        {
        //            processAddDetails.RIS_ORDERDTL.PREPARATION_ID = Convert.ToInt32(dr["PREPARATION_ID"]);
        //        }

        //        processAddDetails.Invoke();
        //    }

        //}
        //private string getAccessionNo(int MODALITY_ID, int? REF_UNIT)
        //{
        //    string accNo = string.Empty;
        //    try
        //    {
        //        ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
        //        process.RIS_ORDERDTL.MODALITY_ID = MODALITY_ID;
        //        process.RIS_ORDERDTL.RIS_ORDER.REF_UNIT = REF_UNIT;
        //        accNo = process.GetAccessionNo();
        //        if (accNo.Trim() == string.Empty)
        //            throw new Exception("Modality : " + MODALITY_ID + " cannot generate accession number, Please try again");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "¢ÈÕº‘¥æ≈“¥", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    return accNo;
        //}
        #endregion
    }
}