using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using System.Data.Common;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmDFSetting : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public int SL_NO { get; set; }
        public string CLINIC_TYPE { get; set; }
        public int DF { get; set; }

        public frmDFSetting(int startNumber)
        {
            InitializeComponent();
        }

        private void frmDFSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //SL_NO = num
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}