using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.Dialog
{
    public partial class WaitDialog : Form
    {
        public WaitDialog(BackgroundWorker backGround)
        {
            InitializeComponent();
            bg = backGround;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.TopMost = true;
            this.ShowInTaskbar = false;
        }

        private void WaitDialog_Load(object sender, EventArgs e)
        {
            tm.Interval = 500;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            if (bg.CancellationPending == true)
                this.Close();
        }
    }
}
