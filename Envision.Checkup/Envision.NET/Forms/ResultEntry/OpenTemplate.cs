using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
using DevExpress.XtraRichEdit;

namespace RIS.Forms.ResultEntry
{
    public partial class OpenTemplate : Form
    {
        private RichEditControl rtPad;
        private DataTable dttData;
        private RIS.BusinessLogic.ResultEntry result;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg;
        private DataSet dsTemp;
        private bool FisrtSetGrid = true;
        private int ThisExamID = -1;

        public OpenTemplate()
        {
            InitializeComponent();
            result = new RIS.BusinessLogic.ResultEntry();
            rtPad = new RichEditControl();
            msg = new MyMessageBox();
            btnDelete.Enabled = false;
            loadData();
            
            checkBox1.Checked = rtEdit.WordWrap;
        }
        public OpenTemplate(RichEditControl editor)
        {
            InitializeComponent();
            rtPad = editor;
            result = new RIS.BusinessLogic.ResultEntry();
            msg = new MyMessageBox();
            btnDelete.Enabled = false;
            loadData();
            checkBox1.Checked = rtEdit.WordWrap;
        }
        public OpenTemplate(RichEditControl editor, int ExamID)
        {
            InitializeComponent();
            rtPad = editor;
            result = new RIS.BusinessLogic.ResultEntry();
            msg = new MyMessageBox();
            btnDelete.Enabled = false;
            loadData(ExamID);
            checkBox1.Checked = rtEdit.WordWrap;
        }


        private void chkAccess(object sender, EventArgs e)
        {
            loadData();
        }
        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (view1.FocusedRowHandle > -1) 
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                if (dr["TEMPLATE_TEXT_RTF"].ToString().Length > 0)
                {
                    txtResult.Rtf = dr["TEMPLATE_TEXT_RTF"].ToString();//dttData.Rows[view1.FocusedRowHandle]["TEMPLATE_TEXT"].ToString();
                }
                else
                {
                    txtResult.Font = new Font("Microsoft Sans Serif", 10);
                    txtResult.Text = dr["TEMPLATE_TEXT"].ToString();//dttData.Rows[view1.FocusedRowHandle]["TEMPLATE_TEXT"].ToString();
                }
                if (dr["TEMPLATE_TYPE"].ToString() == "P")
                    btnDelete.Enabled = true;
                else
                    btnDelete.Enabled = false;

                //if (dttData.Rows[view1.FocusedRowHandle]["TEMPLATE_TYPE"].ToString() == "P")
                //    btnDelete.Enabled = true;
                //else
                //    btnDelete.Enabled = false;
            }
        }

        private void setOption() 
        {
 
        }
        private void loadData() 
        {
            result.RISExamresult.EMP_ID = env.UserID;
            dsTemp = result.GetTemplate();
            switch (radGroup.SelectedIndex)
            {
                case 0:
                    setGridColumn(dsTemp.Tables[0]); 
                    break;
                case 1:
                    setGridColumn(dsTemp.Tables[1]); 
                    break;
                case 2:
                    setGridColumn(dsTemp.Tables[2]); 
                    break;
                default:
                    break;
            }
            
            
            //if (dttData.Rows.Count == 0)
            //    txtResult.Text = string.Empty;
        }
        private void loadData(int ExamID)
        {
            result.RISExamresult.EMP_ID = env.UserID;
            dsTemp = result.GetTemplate();
            switch (radGroup.SelectedIndex)
            {
                case 0:
                    setGridColumn(dsTemp.Tables[0]);
                    break;
                case 1:
                    setGridColumn(dsTemp.Tables[1]);
                    break;
                case 2:
                    setGridColumn(dsTemp.Tables[2]);
                    break;
                default:
                    break;
            }
            dttData = (DataTable)grdData.DataSource;
            DataRow[] drs = dttData.Select("EXAM_ID=" + ExamID);
            if (drs.Length > 0) {

                view1.Columns["EXAM_ID"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(DevExpress.XtraGrid.Columns.ColumnFilterType.Custom, null, "[EXAM_ID]=" + ExamID);
            }
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                if (dr["TEMPLATE_TEXT_RTF"].ToString().Length > 0)
                {
                    txtResult.Rtf = dr["TEMPLATE_TEXT_RTF"].ToString();//dttData.Rows[view1.FocusedRowHandle]["TEMPLATE_TEXT"].ToString();
                }
                else
                {
                    txtResult.Text = dr["TEMPLATE_TEXT"].ToString();//dttData.Rows[view1.FocusedRowHandle]["TEMPLATE_TEXT"].ToString();
                }
                if (dr["TEMPLATE_TYPE"].ToString() == "P")
                    btnDelete.Enabled = true;
                else
                    btnDelete.Enabled = false;
            }
        }

        private void setGridColumn(DataTable dt)
        {
            grdData.DataSource = dt;
            if (FisrtSetGrid == true)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                    view1.Columns[i].Visible = false;

                view1.Columns["TEMPLATE_NAME"].Caption = "Template Name";
                view1.Columns["TEMPLATE_NAME"].Visible = true;
                view1.Columns["TEMPLATE_NAME"].Width = 100;
                view1.Columns["TEMPLATE_NAME"].ColVIndex = 1;

                view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["EXAM_NAME"].Visible = true;
                view1.Columns["EXAM_NAME"].Width = 180;
                view1.Columns["EXAM_NAME"].ColVIndex = 2;

                //view1.Columns["TP_TEXT"].Caption = "Type";
                //view1.Columns["TP_TEXT"].Visible = true;
                //view1.Columns["TP_TEXT"].Width = 80;
                //view1.Columns["TP_TEXT"].ColVIndex = 3;

                view1.Columns["AT_TEXT"].Caption = "Auto";
                view1.Columns["AT_TEXT"].Visible = true;
                view1.Columns["AT_TEXT"].Width = 50;
                view1.Columns["AT_TEXT"].ColVIndex = 4;

                //view1.Columns["EXAM_TYPE_TEXT"].Caption = "Exam Type";
                //view1.Columns["EXAM_TYPE_TEXT"].Visible = true;
                //view1.Columns["EXAM_TYPE_TEXT"].Width = 100;
                //view1.Columns["EXAM_TYPE_TEXT"].ColVIndex = 5;

                view1.Columns["BY_TEXT"].Caption = "By";
                view1.Columns["BY_TEXT"].Visible = true;
                view1.Columns["BY_TEXT"].Width = 100;
                view1.Columns["BY_TEXT"].ColVIndex = 6;

                FisrtSetGrid = false;
            }
            if (dt.Rows.Count == 0)
                txtResult.Text = string.Empty;
        }
        private void btnAppend_Click(object sender, EventArgs e)
        {

            //txtResult.Text = Convert.ToChar(13) + Convert.ToChar(10) + txtResult.Text;
            if (rtEdit.Text.Length > 0)
            {
                rtEdit.AppendText("\n \n");
                txtResult.SelectAll();
                txtResult.Copy();
                rtEdit.ReadOnly = false;
                rtEdit.Paste(); //= rtEdit.Rtf.ToString() + txtResult.Rtf.ToString();
                rtEdit.ReadOnly = true;
                txtResult.DeselectAll();
            }
            else
            {
                rtEdit.Rtf = txtResult.Rtf;
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            if (rtEdit.Text.Trim().Length > 0)
            {
                if (msg.ShowAlert("UID1121", env.CurrentLanguageID) == "1")
                    return;
            }
            System.IO.MemoryStream mem = null;
            rtEdit.Text = string.Empty;
            try
            {
                char[] chr = view1.GetDataRow(view1.FocusedRowHandle)["TEMPLATE_TEXT_RTF"].ToString().ToCharArray();
                byte[] data = new byte[chr.Length];
                for (int i = 0; i < chr.Length; i++)
                    data[i] = (byte)chr[i];
                mem = new System.IO.MemoryStream(data);
                rtEdit.LoadFile(mem, RichTextBoxStreamType.RichText);
                mem.Dispose();
            }
            catch
            {
                rtEdit.AppendText(view1.GetDataRow(view1.FocusedRowHandle)["TEMPLATE_TEXT"].ToString());
            }
            finally
            {
                mem.Dispose();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (rtEdit.Text.Trim().Length > 0)
            {
                if (msg.ShowAlert("UID1122", env.CurrentLanguageID) == "2")
                    rtEdit.Text = string.Empty;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (msg.ShowAlert("UID1025", env.CurrentLanguageID) == "2") {

                int ID=Convert.ToInt32(view1.GetDataRow(view1.FocusedRowHandle)["TEMPLATE_ID"].ToString());
                result = new RIS.BusinessLogic.ResultEntry();
                result.DeleteTemplate(ID);
                btnDelete.Enabled = false;
                if (ThisExamID > 0)
                {
                    loadData(ThisExamID);
                }
                else
                {
                    loadData();
                }
                checkBox1.Checked = rtEdit.WordWrap;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                rtEdit.WordWrap = true;
            else
                rtEdit.WordWrap = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rtEdit.Text.Trim().Length > 0)
            {
                rtPad.Document.RtfText = rtEdit.Rtf;
            }
            else
            {
                if (view1.FocusedRowHandle < 0) return;
                if (rtEdit.Text.Trim().Length > 0)
                {
                    if (msg.ShowAlert("UID1121", env.CurrentLanguageID) == "1")
                        return;
                }
                System.IO.MemoryStream mem = null;
                rtPad.Text = string.Empty;
                rtPad.Document.RtfText = txtResult.Rtf;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ThisExamID > 0)
            {
                loadData(ThisExamID);
            }
            else
            {
                loadData();
            }
        }

    }
}