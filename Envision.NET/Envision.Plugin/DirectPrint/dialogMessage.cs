using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Envision.Plugin.DirectPrint
{
    public partial class dialogMessage : Form
    {
        public dialogMessage()
        {
            InitializeComponent();
        }
        public dialogMessage(string msg)
        {
            InitializeComponent();

            btnSubmit.Text = msg;
        }
    }
}