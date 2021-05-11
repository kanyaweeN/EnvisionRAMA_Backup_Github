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
    public partial class QAWorklist : Form
    {
        bool firstLoad = true;
        DataTable dtWL = new DataTable();

        public QAWorklist(UUL.ControlFrame.Controls.TabControl Tab)
        {
            InitializeComponent();
        }

        private void QAWorklist_Load(object sender, EventArgs e)
        {
            txtFromDT.DateTime = txtToDT.DateTime = DateTime.Now;

            LoadTable();
            LoadGrid();

            firstLoad = false;
        }

        private void LoadTable()
        {
            if (chkAll.Checked)
            {
                ProcessGetRISQAWorks bg = new ProcessGetRISQAWorks();
                bg.RISQaworks.MODE = "selectALL";
                bg.RISQaworks.FROM_DATE = DateTime.Now;
                bg.RISQaworks.TO_DATE = DateTime.Now;
                bg.Invoke();
                dtWL = bg.Result.Tables[0].Copy();
                dtWL.AcceptChanges();
            }
            else
            {
                ProcessGetRISQAWorks bg = new ProcessGetRISQAWorks();
                bg.RISQaworks.MODE = "DateRange";
                DateTime fd = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
                DateTime td = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
                bg.RISQaworks.FROM_DATE = fd;
                bg.RISQaworks.TO_DATE = td;
                bg.Invoke();
                dtWL = bg.Result.Tables[0].Copy();
                dtWL.AcceptChanges();
            }
        }

        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL.Copy();
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView1.Columns["ACCESSION_NO"].Visible = true;
            gridView1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            gridView1.Columns["ACCESSION_NO"].VisibleIndex = 1;
            gridView1.Columns["ACCESSION_NO"].Width = 125;

            gridView1.Columns["SL"].Visible = true;
            gridView1.Columns["SL"].Caption = "SL No.";
            gridView1.Columns["SL"].VisibleIndex = 2;
            gridView1.Columns["SL"].Width = 50;

            gridView1.Columns["QA_RESULT"].Visible = true;
            gridView1.Columns["QA_RESULT"].Caption = "Qa Result";
            gridView1.Columns["QA_RESULT"].VisibleIndex = 3;
            gridView1.Columns["QA_RESULT"].Width = 50;

            gridView1.Columns["COMMENTS"].Visible = true;
            gridView1.Columns["COMMENTS"].Caption = "Comments";
            gridView1.Columns["COMMENTS"].VisibleIndex = 4;
            gridView1.Columns["COMMENTS"].Width = 175;

            //gridView1.Columns["START_TIME"].Visible = false;
            //gridView1.Columns["START_TIME"].Caption = "Start Time";
            //gridView1.Columns["START_TIME"].VisibleIndex = 5;
            //gridView1.Columns["START_TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gridView1.Columns["START_TIME"].DisplayFormat.FormatString = "g";
            //gridView1.Columns["START_TIME"].Width = 75;

            //gridView1.Columns["END_TIME"].Visible = false;
            //gridView1.Columns["END_TIME"].Caption = "End Time";
            //gridView1.Columns["END_TIME"].VisibleIndex = 6;
            //gridView1.Columns["END_TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gridView1.Columns["END_TIME"].DisplayFormat.FormatString = "g";
            //gridView1.Columns["END_TIME"].Width = 75;

            gridView1.Columns["NO_OF_IMAGES_PRINT"].Visible = true;
            gridView1.Columns["NO_OF_IMAGES_PRINT"].Caption = "Image No.";
            gridView1.Columns["NO_OF_IMAGES_PRINT"].VisibleIndex = 7;
            gridView1.Columns["NO_OF_IMAGES_PRINT"].Width = 50;

            gridView1.Columns["CREATED_ON"].Visible = true;
            gridView1.Columns["CREATED_ON"].Caption = "Create on";
            gridView1.Columns["CREATED_ON"].VisibleIndex = 8;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CREATED_ON"].Width = 100;

            #endregion setColumn
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadTable();
            LoadGrid();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
            LoadGrid();
        }
    }
}