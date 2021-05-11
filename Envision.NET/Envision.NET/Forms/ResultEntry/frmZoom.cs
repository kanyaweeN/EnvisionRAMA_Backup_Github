using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmZoom : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public int PercentZoom { get; set; }
        public frmZoom()
        {
            InitializeComponent();
        }

        private void frmZoom_Load(object sender, EventArgs e)
        {
            spePercent.EditValue = PercentZoom;
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
                spePercent.Value = 200;
            else if (radioGroup1.SelectedIndex == 1)
                spePercent.Value = 150;
            else if (radioGroup1.SelectedIndex == 2)
                spePercent.Value = 125;
            else if (radioGroup1.SelectedIndex == 3)
                spePercent.Value = 100;
            else if (radioGroup1.SelectedIndex == 4)
                spePercent.Value = 75;

        }

        private void spePercent_EditValueChanged(object sender, EventArgs e)
        {
            if (spePercent.Value == 200)
                radioGroup1.SelectedIndex = 0;
            else if (spePercent.Value == 150)
                radioGroup1.SelectedIndex = 1;
            else if (spePercent.Value == 125)
                radioGroup1.SelectedIndex = 2;
            else if (spePercent.Value == 100)
                radioGroup1.SelectedIndex = 3;
            else if (spePercent.Value == 75)
                radioGroup1.SelectedIndex = 4;
            else
                radioGroup1.SelectedIndex = 5;

        }
        private void spePercent_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (spePercent.Value == 200)
                radioGroup1.SelectedIndex = 0;
            else if (spePercent.Value == 150)
                radioGroup1.SelectedIndex = 1;
            else if (spePercent.Value == 125)
                radioGroup1.SelectedIndex = 2;
            else if (spePercent.Value == 100)
                radioGroup1.SelectedIndex = 3;
            else if (spePercent.Value == 75)
                radioGroup1.SelectedIndex = 4;
            else
                radioGroup1.SelectedIndex = 5;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            PercentZoom = Convert.ToInt32(spePercent.EditValue);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spePercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PercentZoom = Convert.ToInt32(spePercent.EditValue);
                this.Close();
            }
        }

        private void frmZoom_AutoSizeChanged(object sender, EventArgs e)
        {

        }



    }
}
