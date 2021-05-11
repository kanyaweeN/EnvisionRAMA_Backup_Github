using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;

namespace RIS.Forms.Admin
{
    public partial class frmMonitoringConfirm : Form
    {
        private string Accession;
        private string textSendBilling;
        private string AccessionCan, HNCan, ANCan, ISEQCan;
        private string CaseBill;
        public frmMonitoringConfirm()
        {
            InitializeComponent();
        }
        public frmMonitoringConfirm(string SendBilling,string acc)
        {
            InitializeComponent();

            lblShow.Text = "";
            Accession = acc;
            memStrBill.Text = SendBilling;
            CaseBill = "Send";
        }
        public frmMonitoringConfirm(string AccessionC,string HNC,string ANC,string ISEQC)
        {
            InitializeComponent();
            AccessionCan = AccessionC;
            HNCan = HNC;
            ANCan = ANC;
            ISEQCan = ISEQC;
            string strShow = "Accession : " + AccessionCan + "// HN : " + HNCan + "// AN : " + ANCan + "// ISEQ : " + ISEQCan;
            memStrBill.Text = strShow;
            lblShow.Text = "";
            CaseBill = "Cancel";
        }

        private void frmMonitoringConfirm_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            HIS_Patient pat = new HIS_Patient();
            string str = "";
            string His_sync = "";
            if (CaseBill == "Send")
            {
                //str = pat.Set_Billing(memStrBill.Text);

                try
                {
                    if (str == "Success in Set_Billing")
                    {
                        His_sync = "S";
                    }
                    else
                    {
                        His_sync = "F";
                    }
                    //ProcessUpdateRISOrderdtl process = new ProcessUpdateRISOrderdtl();
                    //process.RISOrderdtl.ACCESSION_NO = Accession;
                    //process.RISOrderdtl.HIS_SYNC = His_sync;
                    //process.RISOrderdtl.HIS_ACK = str;
                    //process.UpdateSend();

                }
                catch (Exception exc)
                {

                    //ProcessUpdateRISOrderdtl process = new ProcessUpdateRISOrderdtl();
                    //process.RISOrderdtl.ACCESSION_NO = Accession;
                    //process.RISOrderdtl.HIS_SYNC = "F";
                    //process.RISOrderdtl.HIS_SYNC = His_sync;
                    //process.RISOrderdtl.HIS_ACK = str;
                    //process.UpdateSend();
                }
                lblShow.Text = str;
            }
            else
            {
                //HIS_Patient pat = new HIS_Patient();
                 //str = pat.Cancel_Billing(HNCan, AccessionCan, ANCan, ISEQCan);
                try
                {
                    if (str == "Success in Set_Billing")
                    {
                        His_sync = "S";
                    }
                    else
                    {
                        His_sync = "F";
                    }
                    //ProcessUpdateRISOrderdtl process = new ProcessUpdateRISOrderdtl();
                    //process.RISOrderdtl.ACCESSION_NO = Accession;
                    //process.RISOrderdtl.HIS_SYNC = His_sync;
                    //process.RISOrderdtl.HIS_ACK = str;
                    //process.UpdateSend();

                }
                catch (Exception exc)
                {

                    //ProcessUpdateRISOrderdtl process = new ProcessUpdateRISOrderdtl();
                    //process.RISOrderdtl.ACCESSION_NO = Accession;
                    //process.RISOrderdtl.HIS_SYNC = "F";
                    //process.RISOrderdtl.HIS_SYNC = His_sync;
                    //process.RISOrderdtl.HIS_ACK = str;
                    //process.UpdateSend();
                }
                lblShow.Text = str;
            }




        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}