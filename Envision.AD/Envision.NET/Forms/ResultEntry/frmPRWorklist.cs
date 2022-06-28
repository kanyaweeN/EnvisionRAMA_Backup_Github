using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using Envision.NET.Forms.ResultEntry.ResultDialog;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPRWorklist : Envision.NET.Forms.Main.MasterForm
    {
        public frmPRWorklist()
        {
            InitializeComponent();
        }

        private void frmPRWorklist_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}
