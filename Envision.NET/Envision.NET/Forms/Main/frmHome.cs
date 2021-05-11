using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.NET.Forms.Main
{
    public partial class frmHome : Envision.NET.Forms.Main.MasterForm
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            ProcessGetGBLNotification nofSelect = new ProcessGetGBLNotification();
            nofSelect.GBL_NOTIFICATION.MODE = 1;
            nofSelect.Invoke();

            DataSet ds = nofSelect.ResultSet;
            grdDetail.DataSource = ds.Tables[0];
            for (int i = 0; i < viewDetail.Columns.Count; i++)
            {
                viewDetail.Columns[i].Visible = false;
                viewDetail.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            
            viewDetail.Columns["SUBJECT"].Visible = true;
            viewDetail.Columns["SUBJECT"].Caption = "Subject";

            viewDetail.Columns["CREATED_ON"].Visible = true;
            viewDetail.Columns["CREATED_ON"].Caption = "Date Updated";
            viewDetail.Columns["CREATED_ON"].Width = 100;
            viewDetail.Columns["NOTIFICATION_NAME"].Visible = true;
            viewDetail.Columns["NOTIFICATION_NAME"].Caption = "Name";
            viewDetail.Columns["NOTIFICATION_NAME"].Width = 100;
            
            base.CloseWaitDialog();
        }
        private void viewDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewDetail.FocusedRowHandle >= 0)
            {
                DataRow row = viewDetail.GetDataRow(viewDetail.FocusedRowHandle);
                rtDescription.Document.RtfText = row["NOTIFICATION_DESC"].ToString();
            }
        }
    }
}
