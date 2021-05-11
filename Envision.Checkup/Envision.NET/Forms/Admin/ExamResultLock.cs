using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;

namespace RIS.Forms.Admin
{
    public partial class ExamResultLock : Form
    {
        DataTable dtWL = new DataTable();
        UUL.ControlFrame.Controls.TabControl tab;
        RIS.Forms.GBLMessage.MyMessageBox msg = new RIS.Forms.GBLMessage.MyMessageBox();
        RIS.Common.Common.GBLEnvVariable env = new RIS.Common.Common.GBLEnvVariable();

        public ExamResultLock(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();
            tab = tabcontrol;
            txtFromDT.DateTime = txtToDT.DateTime = DateTime.Now;

            LoadTable();
            LoadGrid();
        }

        public void LoadTable()
        {
            ProcessGetRISExamresultlocks bget = new ProcessGetRISExamresultlocks();
            bget.RISExamresultlocks.MODE = "selectALL";
            bget.Invoke();
            dtWL = bget.Result.Tables[0];
            dtWL.Columns.Add(new DataColumn("UNLOCK"));
            dtWL.AcceptChanges();
        }

        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL.Copy();

            for (int i = 0; gridView1.Columns.Count > i; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;  
            }

            #region setColumn

            gridView1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridView1.Columns["ACCESSION_NO"].Width = 125;
            gridView1.Columns["ACCESSION_NO"].Visible = true;
            gridView1.Columns["ACCESSION_NO"].ColVIndex = 1;

            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView1.Columns["EXAM_NAME"].Width = 125;
            gridView1.Columns["EXAM_NAME"].Visible = true;
            gridView1.Columns["EXAM_NAME"].ColVIndex = 2;

            gridView1.Columns["HN"].Caption = "HN";
            gridView1.Columns["HN"].Width = 100;
            gridView1.Columns["HN"].Visible = true;
            gridView1.Columns["HN"].ColVIndex = 3;

            gridView1.Columns["PATIENTNAME"].Caption = "Patient Name";
            gridView1.Columns["PATIENTNAME"].Width = 150;
            gridView1.Columns["PATIENTNAME"].Visible = true;
            gridView1.Columns["PATIENTNAME"].ColVIndex = 4;

            gridView1.Columns["RADIOLOGIST"].Caption = "Radiologist";
            gridView1.Columns["RADIOLOGIST"].Width = 150;
            gridView1.Columns["RADIOLOGIST"].Visible = true;
            gridView1.Columns["RADIOLOGIST"].ColVIndex = 5;

            gridView1.Columns["CREATED_ON"].Caption = "Lock On";
            gridView1.Columns["CREATED_ON"].Width = 75;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CREATED_ON"].Visible = true;
            gridView1.Columns["CREATED_ON"].ColVIndex = 6;

            gridView1.Columns["UNLOCK"].Caption = "Unlock";
            gridView1.Columns["UNLOCK"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["UNLOCK"].Width = 75;
            gridView1.Columns["UNLOCK"].Visible = true;
            gridView1.Columns["UNLOCK"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["UNLOCK"].ColVIndex = 7;

            gridView1.BestFitColumns();

            #endregion

            #region setRepoItem

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            rep.Buttons.Clear();
            DevExpress.XtraEditors.Controls.EditorButton edtn = new DevExpress.XtraEditors.Controls.EditorButton();
            edtn.Caption = "Unlock";
            edtn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            rep.Buttons.Add(edtn);
            rep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            rep.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rep_ButtonPressed);
            gridView1.Columns["UNLOCK"].ColumnEdit = rep;

            #endregion
        }

        private void rep_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                string str = msg.ShowAlert("UID2115", env.CurrentLanguageID);
                if (str == "2")
                {
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                    ProcessUpdateRISExamresultlocks bUp = new ProcessUpdateRISExamresultlocks();
                    bUp.RISExamresultlocks.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                    bUp.RISExamresultlocks.SL_NO = (byte)dr["SL_NO"];
                    bUp.RISExamresultlocks.IS_LOCKED = "N";
                    bUp.RISExamresultlocks.UNLOCKED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                    bUp.RISExamresultlocks.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                    bUp.RISExamresultlocks.LAST_MODIFIED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                    bUp.Invoke();

                    if (chkAll.Checked)
                    {
                        LoadTable();
                        LoadGrid();
                    }
                    else
                    {
                        ReLoadTable();
                        LoadGrid();
                    }
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                LoadTable();
                LoadGrid();
            }
            else
            {
                ReLoadTable();
                LoadGrid();
            }
        }

        private void ReLoadTable()
        {
            DateTime fd = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
            ProcessGetRISExamresultlocks bg = new ProcessGetRISExamresultlocks();
            bg.RISExamresultlocks.MODE = "DateRange";
            bg.RISExamresultlocks.FROM_DATE = fd;
            bg.RISExamresultlocks.TO_DATE = td;
            bg.Invoke();
            dtWL = bg.Result.Tables[0];
            dtWL.Columns.Add(new DataColumn("UNLOCK"));
            dtWL.AcceptChanges();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                LoadTable();
                LoadGrid();
            }
            else
            {
                ReLoadTable();
                LoadGrid();
            }
        }
    }
}