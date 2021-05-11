using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Financial
{
    public partial class frmBillingViewer_result : Form
    {
        public frmBillingViewer_result(DataTable tb)
        {
            InitializeComponent();
            gridControl1.DataSource = tb;
        }
    }
}
