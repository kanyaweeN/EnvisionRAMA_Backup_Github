using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Admin
{
    public partial class ExamResultLock : Envision.NET.Forms.Main.MasterForm
    {
        DataTable dtWL = new DataTable();
        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();

        public ExamResultLock()
        {
            InitializeComponent();
            //tab = tabcontrol;
            txtFromDT.DateTime = txtToDT.DateTime = DateTime.Now;

            LoadTable();
            LoadGrid();
        }

        public void LoadTable()
        {
            ProcessGetRISUnlocked get = new ProcessGetRISUnlocked();
            get.Invoke();
            dtWL = get.Result.Tables[0];
            dtWL.Columns.Add(new DataColumn("UNLOCK"));
            dtWL.AcceptChanges();
            gridControl1.DataSource = dtWL.Copy();
        }

        private void LoadGrid()
        {

            for (int i = 0; gridView1.Columns.Count > i; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;  
            }

            gridView1.OptionsView.ShowAutoFilterRow = true;

            #region setColumn
            gridView1.Columns["FORM"].Caption = "Form";
            gridView1.Columns["FORM"].Width = 125;
            gridView1.Columns["FORM"].Visible = true;
            gridView1.Columns["FORM"].ColVIndex = 1;

            gridView1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridView1.Columns["ACCESSION_NO"].Width = 125;
            gridView1.Columns["ACCESSION_NO"].Visible = true;
            gridView1.Columns["ACCESSION_NO"].ColVIndex = 2;

            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView1.Columns["EXAM_NAME"].Width = 125;
            gridView1.Columns["EXAM_NAME"].Visible = true;
            gridView1.Columns["EXAM_NAME"].ColVIndex =3;

            gridView1.Columns["STUDY_DATETIME"].Caption = "Study On";
            gridView1.Columns["STUDY_DATETIME"].Width = 75;
            gridView1.Columns["STUDY_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["STUDY_DATETIME"].DisplayFormat.FormatString = "g";
            gridView1.Columns["STUDY_DATETIME"].Visible = true;
            gridView1.Columns["STUDY_DATETIME"].ColVIndex = 4;

            gridView1.Columns["HN"].Caption = "HN";
            gridView1.Columns["HN"].Width = 100;
            gridView1.Columns["HN"].Visible = true;
            gridView1.Columns["HN"].ColVIndex = 5;

            gridView1.Columns["PATIENTNAME"].Caption = "Patient Name";
            gridView1.Columns["PATIENTNAME"].Width = 150;
            gridView1.Columns["PATIENTNAME"].Visible = true;
            gridView1.Columns["PATIENTNAME"].ColVIndex = 6;

            gridView1.Columns["RADIOLOGIST"].Caption = "Using By";
            gridView1.Columns["RADIOLOGIST"].Width = 150;
            gridView1.Columns["RADIOLOGIST"].Visible = true;
            gridView1.Columns["RADIOLOGIST"].ColVIndex = 7;

            gridView1.Columns["CREATED_ON"].Caption = "Lock On";
            gridView1.Columns["CREATED_ON"].Width = 75;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CREATED_ON"].Visible = true;
            gridView1.Columns["CREATED_ON"].ColVIndex = 8;

            gridView1.Columns["UNLOCK"].Caption = "Unlock";
            gridView1.Columns["UNLOCK"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["UNLOCK"].Width = 75;
            gridView1.Columns["UNLOCK"].Visible = true;
            gridView1.Columns["UNLOCK"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["UNLOCK"].ColVIndex = 9;

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

                        switch (dr["FORM"].ToString())
                        {
                            case "REPORT":
                                ProcessUpdateRISExamresultlocks bUp = new ProcessUpdateRISExamresultlocks();
                                bUp.RIS_EXAMRESULTLOCK.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                bUp.RIS_EXAMRESULTLOCK.SL_NO = Convert.ToByte( dr["SL_NO"]);
                                bUp.RIS_EXAMRESULTLOCK.IS_LOCKED = 'N';
                                bUp.RIS_EXAMRESULTLOCK.UNLOCKED_BY = new GBLEnvVariable().UserID;
                                bUp.RIS_EXAMRESULTLOCK.ORG_ID = new GBLEnvVariable().OrgID;
                                bUp.RIS_EXAMRESULTLOCK.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                                bUp.Invoke();
                                break;
                            case "SCHEDULE":
                                ProcessUpdateRISUnlockedCase busyUp = new ProcessUpdateRISUnlockedCase();
                                busyUp.RIS_UNLOCKEDCASE.SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"]);
                                busyUp.Invoke();
                                break;
                            case "XRAYREQ":
                                ProcessUpdateXRAYREQ busyReq = new ProcessUpdateXRAYREQ();
                                busyReq.updateLockCase(Convert.ToInt32(dr["XRAYREQ_ID"]), "N", new GBLEnvVariable().UserID);
                                break;
                        }
                   

                    if (chkAll.Checked)
                    {
                        LoadTable();
                        //LoadGrid();
                    }
                    else
                    {
                        ReLoadTable();
                        //LoadGrid();
                    }
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                LoadTable();
                //LoadGrid();
            }
            else
            {
                ReLoadTable();
                ////LoadGrid();
            }
        }

        private void ReLoadTable()
        {
            DateTime fd = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
            DateTime td = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
            ProcessGetRISExamresultlocks bg = new ProcessGetRISExamresultlocks();
            bg.RIS_EXAMRESULTLOCK.MODE = "DateRange";
            bg.RIS_EXAMRESULTLOCK.FROM_DATE = fd;
            bg.RIS_EXAMRESULTLOCK.TO_DATE = td;
            bg.Invoke();
            dtWL = bg.Result.Tables[0];
            dtWL.Columns.Add(new DataColumn("UNLOCK"));
            dtWL.AcceptChanges();
            gridControl1.DataSource = dtWL.Copy();
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

        private void ExamResultLock_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}