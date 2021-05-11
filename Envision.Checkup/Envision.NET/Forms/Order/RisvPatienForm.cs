using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Forms.GBLMessage;
using RIS.Common.Common;
using RIS.BusinessLogic;
using DevExpress.XtraEditors.Repository;
using System.Drawing.Drawing2D;
using System.Globalization;
using DevExpress.XtraGrid;


namespace RIS.Forms.Order
{
    public partial class RisvPatienForm : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();

        //private Color color1 = Color.LightBlue;
        //private Color color2 = Color.LightSkyBlue;

        private Color color1 = Color.LightBlue;
        private Color color2 = Color.LightSkyBlue;

        private DataTable dtWL = new DataTable();

        public RisvPatienForm(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;

            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;

            LoadTable();
            LoadFilter();
            LoadGrid();
        }

        private void LoadTable()
        {
            CultureInfo culture = new CultureInfo("en-US", true);

            DateTime _fromdate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
            DateTime _todate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

            ProcessGetRisvPatienDate risvdate = new ProcessGetRisvPatienDate();
            risvdate.DateTime1 = _fromdate;
            risvdate.DateTime2 = _todate;
            risvdate.Invoke();

            dtWL = risvdate.DataResult.Tables[0];
        }

        private void LoadFilter()
        {
            if (dtWL.Rows.Count < 1)
                labelControl1.Text = "no patient";
            else
                labelControl1.Text = dtWL.Rows.Count.ToString() + " patients";
        }

        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL.Copy();

            //for (int i = 0; i < gridView1.Columns.Count; ++i)
            //{
            //    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            //    gridView1.Columns[i].Visible = false;
            //}

            //gridView1.BestFitColumns();
            //gridView1.Columns["EXAM_NAME"].Width = 175;

            if (checkEdit1.Checked == true)
                Colour_Setting();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadTable();
            LoadFilter();
            LoadGrid();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyData == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void Colour_Setting()
        {
            gridView1.FormatConditions.Clear();

            StyleFormatCondition cn;
            string strcond = "  ";

            cn = new StyleFormatCondition(FormatConditionEnum.NotEqual, gridView1.Columns["PRELIM_BY"], null, strcond);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = color1;
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition(FormatConditionEnum.NotEqual, gridView1.Columns["FINALIZE_BY"], null, strcond);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = color2;
            gridView1.FormatConditions.Add(cn);

            gridView1.BestFitColumns();
            gridView1.Columns["EXAM_NAME"].Width = 175;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                Colour_Setting();
            }
            else
            {
                gridView1.FormatConditions.Clear();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (ColorDialog coldia1 = new ColorDialog())
            {
                if (coldia1.ShowDialog(this) == DialogResult.OK)
                {
                    this.color1 = coldia1.Color;
                }
            }

            using (ColorDialog coldia2 = new ColorDialog())
            {
                if (coldia2.ShowDialog(this) == DialogResult.OK)
                {
                    this.color2 = coldia2.Color;
                }
            }

            Colour_Setting();
        }

    }
}

