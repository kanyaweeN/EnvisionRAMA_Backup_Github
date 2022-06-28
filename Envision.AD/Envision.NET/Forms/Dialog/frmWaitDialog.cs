using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Order.WaitDialog
{
    public partial class frmWaitDialog : Form
    {
        public frmWaitDialog()
        {
            InitializeComponent();
        }

        private void frmWaitDialog_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            marqueeProgressBarControl1.Properties.ShowTitle = true;
            marqueeProgressBarControl1.Text = " Loading Thai Romanization... ";
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (processProcess.Value == processProcess.Maximum)
        //    {
        //        processProcess.Value = 0;
        //        timer1.Start();
        //    }
        //    else
        //        processProcess.Value += 1;
        //}

      
    }
}