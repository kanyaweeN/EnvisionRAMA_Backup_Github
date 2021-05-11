using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.ScheduleEmployee
{
    public partial class OccurenceDialog : Form
    {
        public OccurenceDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        public int SelectType {
            get
            {
                return rdoType.SelectedIndex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
