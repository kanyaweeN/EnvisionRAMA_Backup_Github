using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace Envision.NET.Forms.Orders
{
    public partial class PatientRegistrationHISViewer : Form
    {
        private DataSet dsHISData;
        public DataSet HISData { get; set; }

        public PatientRegistrationHISViewer()
        {
            InitializeComponent();
        }

        private void PatientRegistrationHISViewer_Load(object sender, EventArgs e)
        {
            if (Miracle.Util.Utilities.IsHaveData(HISData))
            {
                gcHISData.DataSource = HISData.Tables[0];

                foreach (BandedGridColumn col in gvHISData.Columns)
                {
                    col.OptionsColumn.ReadOnly = true;
                }
            }
        }
    }
}
