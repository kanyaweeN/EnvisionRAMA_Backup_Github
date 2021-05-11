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
                string strCanBil = fnBill.Cancel_Billing(SendHN, Accession, " ", " ");
                fnBill.UpdateHisSync(AccessionCan, strCanBil);

                str = fnBill.Resend_Billing(memStrBill.Text);
                fnBill.UpdateHisSync(Accession, str);

                lblShow.Text = str;

                if (str == "Success in Set_Billing")
                {
                    MessageBox.Show("Successful,a billing already sent.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                    MessageBox.Show("Failure,Can not send a billing.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                str = fnBill.Cancel_Billing(HNCan, AccessionCan, ANCan, ISEQCan);
                fnBill.UpdateHisSync(AccessionCan, str);

                lblShow.Text = str;

                if (str == "Success in Cancel_Billing")
                {
                    MessageBox.Show("Successful,a billing already cancel.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                    MessageBox.Show("Failure,Can not cancel a billing.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

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