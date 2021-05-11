using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Order
{
    public partial class Form1 : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public Form1(UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            CloseControl = Cls;
        }

      
    }
}