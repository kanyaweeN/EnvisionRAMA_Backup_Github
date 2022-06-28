using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class frmCancelOrder : MasterForm
    {
        public frmCancelOrder()
        {
            InitializeComponent();
        }

        private void frmCancelOrder_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}
