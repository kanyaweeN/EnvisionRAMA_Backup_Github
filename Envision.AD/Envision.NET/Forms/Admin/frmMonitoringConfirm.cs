using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Admin
{
    public partial class frmMonitoringConfirm : Form
    {
        private string Accession;
        private string textSendBilling;
        private string AccessionCan, HNCan, ANCan, ISEQCan;
        private string CaseBill;
        private string SendHN;

        private DateTime justClickSend;
        private bool firstLoad = true;

        private FinancialBilling fnBill = new FinancialBilling();

        public frmMonitoringConfirm()
        {
            InitializeComponent();
        }
        public frmMonitoringConfirm(string SendBilling,string acc,string hn)
        {
            InitializeComponent();

            lblShow.Text = "";
            Accession = acc;
            memStrBill.Text = SendBilling;
            CaseBill = "Send";
            SendHN = hn;
        }
        public frmMonitoringConfirm(string AccessionC,string HNC,string ANC,string ISEQC)
        {
            InitializeComponent();
            AccessionCan = AccessionC;
            HNCan = HNC;
            ANCan = ANC;
            ISEQCan = ISEQC;
            string strShow = " Accession : " + AccessionCan + "\r\n HN : " + HNCan + "\r\n AN : " + ANCan + "\r\n ISEQ : " + ISEQCan;
            memStrBill.Text = strShow;
            lblShow.Text = "";
            CaseBill = "Cancel";
        }

        private void frmMonitoringConfirm_Load(object sender, EventArgs e)
        {
            justClickSend = DateTime.Now;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;

            double totalsecond = (DateTime.Now - justClickSend).TotalSeconds;
            if (totalsecond < 10)
            {
                if (!firstLoad)
                {
                    MessageBox.Show("Please wait until 10 seconds before resend the billing.", "Please waiting.");
                    btnSend.Enabled = true;
                    return;
                }
            }
            justClickSend = DateTime.Now;

            firstLoad = false;

            HIS_Patient pat = new HIS_Patient();
            string str = "";
            if (CaseBill == "Send")
            {
                DataTable dtCancelBill = fnBill.GetBillingMessage(Accession).Tables[0];
                foreach (DataRow rowCancelBill in dtCancelBill.Rows)
                    str = fnBill.Cancel_Billing(SendHN, rowCancelBill["EXAM_UID"].ToString().Trim() + Accession, " ", " ");

                string[] arrStr = memStrBill.Text.Split('^');
                foreach (string strBill in arrStr)
                    str = fnBill.Resend_Billing(strBill);
                fnBill.UpdateHisSync(Accession, str);

                lblShow.Text = str;

            }
            else
            {
                DataTable dtCancelBill = fnBill.GetBillingMessage(AccessionCan).Tables[0];
                foreach (DataRow rowCancelBill in dtCancelBill.Rows)
                    str = fnBill.Cancel_Billing(HNCan, rowCancelBill["EXAM_UID"].ToString().Trim() + AccessionCan, " ", " ");

                fnBill.UpdateHisSync(AccessionCan, str);

                lblShow.Text = str;
            }


            btnSend.Enabled = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}