using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.BusinessLogic.ProcessRead;
using Miracle.Util;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPopupRadFilterMode : DevExpress.XtraEditors.XtraForm
    {
        private int Radiologist_id;
        public frmPopupRadFilterMode()
        {
            InitializeComponent();
        }
        public frmPopupRadFilterMode(int rad_id)
        {
            InitializeComponent();
            Radiologist_id = rad_id;
        }
        private void frmPopupRadFilterMode_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            DataTable dtFilterAll = new DataTable();
            DataTable dtRadFilter = new DataTable();

            ProcessGetRISExamresultFilterworklist filterData = new ProcessGetRISExamresultFilterworklist();
            filterData.RIS_EXAMRESULT_FILTERWORKLIST.EMP_ID = Radiologist_id;
            filterData.getDataByRadid();
            DataSet ds = filterData.Result;

            grdFilter.DataSource = ds.Tables[1];

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
           chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chk_Click);


            for (int i = 0; i < viewFilter.Columns.Count; i++)
            {
                viewFilter.Columns[i].Visible = false;
            }
            viewFilter.Columns["CHK"].ColVIndex = 1;
            viewFilter.Columns["CHK"].Caption = " ";
            viewFilter.Columns["CHK"].ColumnEdit = chkTemplate;
            viewFilter.Columns["CHK"].Width = 20;

            viewFilter.Columns["FILTER_NAME"].ColVIndex = 2;
            viewFilter.Columns["FILTER_NAME"].Caption = "Filter Name";
            viewFilter.Columns["FILTER_NAME"].OptionsColumn.ReadOnly = true;
            viewFilter.Columns["FILTER_NAME"].OptionsColumn.AllowEdit = false;
            viewFilter.Columns["FILTER_NAME"].Width = 200;
        }
        private void chk_Click(object sender, EventArgs e)
        {
            if (viewFilter.FocusedRowHandle > -1)
            {
                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                DataRow drChk = viewFilter.GetDataRow(viewFilter.FocusedRowHandle);
                if (chk.Checked == false)
                    drChk["CHK"] = "Y";
                else
                    drChk["CHK"] = "N";

                drChk.AcceptChanges();
            }
        }
        private void viewFilter_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewFilter.FocusedRowHandle >= 0)
            {
                DataRow row = viewFilter.GetDataRow(viewFilter.FocusedRowHandle);
                DataSet getXML = new DataSet();
                System.IO.MemoryStream mem = null;
                char[] chr = row["FILTER_DETAIL"].ToString().ToCharArray();
                byte[] data = new byte[chr.Length];
                for (int i = 0; i < chr.Length; i++)
                    data[i] = (byte)chr[i];
                mem = new System.IO.MemoryStream(data);

                getXML.ReadXml(mem);

                if (Utilities.IsHaveData(getXML))
                {
                    ProcessGetRISExamType getExamType = new ProcessGetRISExamType();
                    getExamType.Invoke();
                    DataTable dtExamType = getExamType.Result.Tables[0];

                    ProcessGetHRUnit getUnit = new ProcessGetHRUnit();
                    getUnit.Invoke_forRadiologistWorklist();
                    DataTable dtUnit = getUnit.Result.Tables[0];

                    string _ExamType = "";
                    string _HRUnit = "";
                    string _Filter = "";

                    DataRow[] rowsExamType = dtExamType.Select("EXAM_TYPE_ID IN(" + getXML.Tables[0].Rows[0]["EXAM_TYPE"].ToString() + ")");
                    DataRow[] rowsHRUnit = dtUnit.Select("UNIT_ID IN(" + getXML.Tables[0].Rows[0]["REF_UNIT"].ToString() + ")");

                    if (rowsExamType.Length > 0)
                    {
                        _ExamType += "Exam Type : \r\n";
                        foreach (DataRow rowExamType in rowsExamType)
                        {
                            _ExamType += "      -  " + rowExamType["EXAM_TYPE_TEXT"].ToString() + "\r\n";
                        }
                    }
                    if (rowsHRUnit.Length > 0)
                    {
                        _HRUnit += "Department : \r\n";
                        foreach (DataRow rowHRUnit in rowsHRUnit)
                        {
                            _HRUnit += "      -  " + rowHRUnit["UNIT_UID"].ToString() + "\r\n";
                        }
                    }
                    if (!string.IsNullOrEmpty(getXML.Tables[0].Rows[0]["FILTER_COLUMNS"].ToString()))
                    {
                        _Filter += "Filter : \r\n";
                        _Filter += "      " + getXML.Tables[0].Rows[0]["FILTER_COLUMNS"].ToString();
                    }
                    memDetail.Text = string.IsNullOrEmpty(_Filter) ? "" : _Filter + "\r\n";
                    memDetail.Text += string.IsNullOrEmpty(_ExamType) ? "" : _ExamType + "\r\n";
                    memDetail.Text += string.IsNullOrEmpty(_HRUnit) ? "" : _HRUnit + "\r\n";
                }
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             GBLEnvVariable env = new GBLEnvVariable();
            ProcessDeleteRISExamresultFilterRad del = new ProcessDeleteRISExamresultFilterRad();
            del.RIS_EXAMRESULT_FILTERRAD.EMP_ID = Radiologist_id;
            del.Invoke();

            DataTable dt = grdFilter.DataSource as DataTable;
            DataRow[] rows = dt.Select("CHK='Y'");
            foreach (DataRow row in rows)
            {
                ProcessAddRISExamresultFilterRad add = new ProcessAddRISExamresultFilterRad();
                add.RIS_EXAMRESULT_FILTERRAD.EMP_ID = Radiologist_id;
                add.RIS_EXAMRESULT_FILTERRAD.FILTER_ID = Convert.ToInt32(row["FILTER_ID"]);
                add.RIS_EXAMRESULT_FILTERRAD.CREATED_BY = env.UserID;
                add.Invoke();
            }

            this.Close();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        
    }
}