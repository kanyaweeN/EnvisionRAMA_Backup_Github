using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Envision.NET.Forms.Dialog
{
    public partial class dlgAlgorithm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable dtt = new DataTable();
        public dlgAlgorithm()
        {
            InitializeComponent();
        }

        private void txtHN_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {

        }

        private void dlgAlgorithm_Load(object sender, EventArgs e)
        {
            dtt = new DataTable();
            dtt.Columns.Add("GROUP");
            dtt.Columns.Add("VALUE");
            dtt.Columns.Add("DELETE");
            dtt.AcceptChanges();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                spinEdit2.Visible = true;

                dtt.Rows.Clear();
                dtt.AcceptChanges();

                for (int i = 0; i < spinEdit2.Value; i++)
                {
                    DataRow drNew = dtt.NewRow();
                    drNew[0] = "สังกัด CT";
                    drNew[1] = 0;

                    dtt.Rows.Add(drNew);
                    dtt.AcceptChanges();
                }
                gridControl1.DataSource = dtt;
            }
            else
            {
                spinEdit2.Visible = false;
                dtt.Rows.Clear();
                dtt.AcceptChanges();
                DataRow drNew = dtt.NewRow();
                drNew[0] = "สังกัด CT";
                drNew[1] = 0;

                dtt.Rows.Add(drNew);
                dtt.AcceptChanges();
                gridControl1.DataSource = dtt;
            }
        }

        private void spinEdit2_ValueChanged(object sender, EventArgs e)
        {
            if (!checkEdit1.Checked)
            {
                dtt.Rows.Clear();
                dtt.AcceptChanges();
            }
            else
            {
                dtt.Rows.Clear();
                dtt.AcceptChanges();

                for (int i = 0; i < spinEdit2.Value; i++)
                {
                    DataRow drNew = dtt.NewRow();
                    drNew[0] = "สังกัด CT";
                    drNew[1] = 0;

                    dtt.Rows.Add(drNew);
                    dtt.AcceptChanges();
                }
            }
            gridControl1.DataSource = dtt;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
                lbTypeSampling.Text = "%";
            else
                lbTypeSampling.Text = "Study";
        }
    }
}