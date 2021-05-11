using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmContrastFillDetail : Envision.NET.Forms.Main.MasterForm
    {
        DataSet dss = new DataSet();
        int orderId = 0;
        public frmContrastFillDetail()
        {
            InitializeComponent();
        }
        public frmContrastFillDetail(DataSet ds, int order_id)
        {
            InitializeComponent();
            dss = ds;
            orderId = order_id;
        }

        private void frmContrastFillDetail_Load(object sender, EventArgs e)
        {
            lblHn.Text = dss.Tables[0].Rows[0]["HN"].ToString();
            lblPatientName.Text = dss.Tables[0].Rows[0]["PATIENT_NAME"].ToString();
            setDataRoute();
        }
        private void setDataRoute()
        {
            base.LabelWaitDialog("Loading Data");

            LookUpSelect sel = new LookUpSelect();
            DataSet ds = sel.SelectContrastManagement(1, DateTime.Now, DateTime.Now, "");
            comboBoxEdit1.Properties.Items.Clear();
            string modName = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBoxEdit1.Properties.Items.Add(ds.Tables[0].Rows[i]["RouteName"]);
            }
            base.CloseWaitDialog();
        }
    }
}
