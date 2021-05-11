using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace RIS.Forms.Admin
{
    public partial class frmHL7Monitoring : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public frmHL7Monitoring(UUL.ControlFrame.Controls.TabControl Cls)
        {
            InitializeComponent();
            CloseControl = Cls;
        }
        private DateTime dt11, dt22;
        private GBLEnvVariable env = new GBLEnvVariable();
        private string HNCan, AccessionCan, ANCan, ISEQCan;
        private void frmHL7Monitoring_Load(object sender, EventArgs e)
        {
            dedFromdate.DateTime = DateTime.Now;
            dedTodate.DateTime = DateTime.Now;
            BindData();
            //SetData();
        }
        private void BindData()
        {
            ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            geHL.HL7MonitoringNew.SP_TYPES = 1;
            geHL.Invoke();
            DataTable dt = geHL.Result.Tables[0];
            grdData.DataSource = dt;
            SetGrid();
        }
        private void SetData()
        {
            DateTime dtFrom = new DateTime(dedFromdate.DateTime.Year, dedFromdate.DateTime.Month, dedFromdate.DateTime.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(dedTodate.DateTime.Year, dedTodate.DateTime.Month, dedTodate.DateTime.Day, 23, 59, 59);
            ProcessGetRISHL7MonitoringNew geHL = new ProcessGetRISHL7MonitoringNew();
            geHL.HL7MonitoringNew.SP_TYPES = 2;
            geHL.HL7MonitoringNew.FROM_DATE = dtFrom;
            geHL.HL7MonitoringNew.TO_DATE = dtTo;
            geHL.Invoke();
            DataTable dt = geHL.Result.Tables[0];

            grdData.DataSource = dt;
            SetGrid();
        }
        private void SetGrid()
        {
            viewData.OptionsView.ShowAutoFilterRow = true;

            viewData.Columns["ORDER ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ORDER ID"].Visible = true;
            viewData.Columns["ORDER ID"].Caption = "ORDER ID";
            viewData.Columns["ORDER ID"].ColVIndex = 0;
            viewData.Columns["ORDER ID"].OptionsColumn.ReadOnly = true;


            viewData.Columns["ACCESSION NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ACCESSION NO"].Visible = true;
            viewData.Columns["ACCESSION NO"].Caption = "ACCESSION NO";
            viewData.Columns["ACCESSION NO"].ColVIndex = 1;
            viewData.Columns["ACCESSION NO"].OptionsColumn.ReadOnly = true;


            viewData.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HN"].Visible = true;
            viewData.Columns["HN"].Caption = "HN";
            viewData.Columns["HN"].ColVIndex = 2;
            viewData.Columns["HN"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EXAM CODE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM CODE"].Visible = true;
            viewData.Columns["EXAM CODE"].Caption = "EXAM CODE";
            viewData.Columns["EXAM CODE"].ColVIndex = 3;
            viewData.Columns["EXAM CODE"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EXAM NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EXAM NAME"].Visible = true;
            viewData.Columns["EXAM NAME"].Caption = "EXAM NAME";
            viewData.Columns["EXAM NAME"].ColVIndex = 4;
            viewData.Columns["EXAM NAME"].OptionsColumn.ReadOnly = true;


            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtRp = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            viewData.Columns["ORDER TIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["ORDER TIME"].Visible = true;
            viewData.Columns["ORDER TIME"].Caption = "ORDER TIME";
            viewData.Columns["ORDER TIME"].ColumnEdit = txtRp;
            viewData.Columns["ORDER TIME"].ColVIndex = 5;
            viewData.Columns["ORDER TIME"].OptionsColumn.ReadOnly = true;

            viewData.Columns["EMP_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["EMP_UID"].Visible = true;
            //viewData.Columns["SENTC"].ColumnEdit = btnCan;
            viewData.Columns["EMP_UID"].Caption = "Emp Code";
            viewData.Columns["EMP_UID"].ColVIndex = 6;
            viewData.Columns["EMP_UID"].OptionsColumn.ReadOnly = true;

            viewData.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["QTY"].Visible = true;
            //viewData.Columns["HISSYNC"].ColumnEdit = btnSend;
            viewData.Columns["QTY"].Caption = "QTY";
            viewData.Columns["QTY"].ColVIndex = 7;
            viewData.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewData.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["RATE"].Visible = true;
            //viewData.Columns["HISSYNC"].ColumnEdit = btnSend;
            viewData.Columns["RATE"].Caption = "RATE";
            viewData.Columns["RATE"].ColVIndex = 8;
            viewData.Columns["RATE"].OptionsColumn.ReadOnly = true;

            viewData.Columns["HISSYNC"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["HISSYNC"].Visible = true;
            //viewData.Columns["HISSYNC"].ColumnEdit = btnSend;
            viewData.Columns["HISSYNC"].Caption = "His SYNC";
            viewData.Columns["HISSYNC"].ColVIndex = 9;
            viewData.Columns["HISSYNC"].OptionsColumn.ReadOnly = true;


            viewData.Columns["STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["STATUS"].Visible = false;
            viewData.Columns["STATUS"].Caption = "STATUS";
            viewData.Columns["STATUS"].OptionsColumn.ReadOnly = true;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSend = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnSend.ButtonsStyle = BorderStyles.Office2003;
            //btnSend.Buttons[0].Caption = "";
            btnSend.Buttons[0].Kind = ButtonPredefines.Plus;
            btnSend.TextEditStyle = TextEditStyles.HideTextEditor;
            btnSend.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnSend_ButtonClick);


            viewData.Columns["CHANGE TO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["CHANGE TO"].Visible = true;
            viewData.Columns["CHANGE TO"].ColumnEdit = btnSend;
            viewData.Columns["CHANGE TO"].ColVIndex = 10;
            viewData.Columns["CHANGE TO"].Caption = "";
            viewData.Columns["CHANGE TO"].OptionsColumn.ReadOnly = true;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnCan = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnCan.ButtonsStyle = BorderStyles.Office2003;
            //btnSend.Buttons[0].Caption = "";
            btnCan.Buttons[0].Kind = ButtonPredefines.Delete;
            btnCan.TextEditStyle = TextEditStyles.HideTextEditor;
            btnCan.ButtonClick += new ButtonPressedEventHandler(btnCan_ButtonClick);

            viewData.Columns["SENTC"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["SENTC"].Visible = true;
            viewData.Columns["SENTC"].ColumnEdit = btnCan;
            viewData.Columns["SENTC"].Caption = "";
            viewData.Columns["SENTC"].ColVIndex = 11;
            viewData.Columns["SENTC"].OptionsColumn.ReadOnly = true;





            viewData.Columns["NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["NAME"].Visible = false; ;
            viewData.Columns["NAME"].Caption = "NAME";
            viewData.Columns["NAME"].OptionsColumn.ReadOnly = true;








            viewData.Columns["SENT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["SENT"].Visible = false;
            viewData.Columns["SENT"].Caption = "SENT HL7";
            viewData.Columns["SENT"].OptionsColumn.ReadOnly = true;




            viewData.Columns["REQUESTED BY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["REQUESTED BY"].Visible = false;
            viewData.Columns["REQUESTED BY"].Caption = "REQUESTED BY";
            viewData.Columns["REQUESTED BY"].OptionsColumn.ReadOnly = true;



            viewData.Columns["INSURANCE_TYPE_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["INSURANCE_TYPE_ID"].Visible = false;
            //viewData.Columns["HISSYNC"].ColumnEdit = btnSend;
            viewData.Columns["INSURANCE_TYPE_ID"].Caption = "His SYNC";
            viewData.Columns["INSURANCE_TYPE_ID"].OptionsColumn.ReadOnly = true;



            viewData.Columns["CLINIC_TYPE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["CLINIC_TYPE"].Visible = false;
            //viewData.Columns["HISSYNC"].ColumnEdit = btnSend;
            viewData.Columns["CLINIC_TYPE"].Caption = "CLINIC_TYPE";
            viewData.Columns["CLINIC_TYPE"].OptionsColumn.ReadOnly = true;

            viewData.Columns["UNIT_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewData.Columns["UNIT_UID"].Visible = false;
            //viewData.Columns["HISSYNC"].ColumnEdit = btnSend;
            viewData.Columns["UNIT_UID"].Caption = "UNIT_UID";
            viewData.Columns["UNIT_UID"].OptionsColumn.ReadOnly = true;





            

        }

        private void btnCan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CancelBilling();
            frmMonitoringConfirm frmMC = new frmMonitoringConfirm(AccessionCan, HNCan, ANCan, ISEQCan);
            frmMC.MinimizeBox = false;
            frmMC.MaximizeBox = false;
            frmMC.StartPosition = FormStartPosition.CenterParent;
            frmMC.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmMC.Text = "Take Billing";
            frmMC.ShowDialog();

        }

        private void btnSend_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = viewData.GetDataRow(viewData.FocusedRowHandle);
            string str = SendBilling();

            frmMonitoringConfirm frmMC = new frmMonitoringConfirm(str, dr["ACCESSION NO"].ToString());
            frmMC.MinimizeBox = false;
            frmMC.MaximizeBox = false;
            frmMC.StartPosition = FormStartPosition.CenterParent;
            frmMC.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmMC.Text = "Take Billing";
            frmMC.ShowDialog();


        }


        private void btnResend_Click(object sender, EventArgs e)
        {
            SetData();
            SetGrid();
        }
        private string SendBilling()
        {
            DataTable dtG = (DataTable)grdData.DataSource;
            dtG.AcceptChanges();
            
            string his_sync = "";
            string strBilling = "";
            #region Billing
            try
            {
                HIS_Patient BillHis = new HIS_Patient();
                string strAN = "";
                string strMstype = "";
                string strISEQ = "";
                string strClinic = "";
                string strInSu = "";
                //string strAcc = Acc;//getAccessionNo(processAddDetails.RISOrderdtl.MODALITY_ID);
                int Amt = 0;


                DataRow drv= viewData.GetDataRow(viewData.FocusedRowHandle);

                string HN = drv["HN"].ToString();//dtG.Rows[viewData.FocusedRowHandle]["HN"].ToString();
                string Accession = drv["ACCESSION NO"].ToString();//dtG.Rows[viewData.FocusedRowHandle]["ACCESSION NO"].ToString();

                DataSet dsIPD = null;// BillHis.Get_ipd_detail(HN);
                for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
                {
                    strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                    if (strAN != "")
                    {
                        strMstype = "I";
                        strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                    }
                    else
                    {
                        strMstype = "O";
                        strAN = " ";
                    }

                    //strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
                    //if (strISEQ != "")
                    //{
                    //    strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
                    //}
                    //else
                    //{
                    //    //strISEQ = " ";
                    //}
                }
                for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
                {
                    strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                    if (strAN != "")
                    {
                        strMstype = "I";
                    }
                    else
                    {
                        strMstype = "O";
                    }
                    strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
                }
                if (string.IsNullOrEmpty(strISEQ)) strISEQ = "1";
                if (string.IsNullOrEmpty(strAN)) strAN = " ";

                string unit_uid = drv["UNIT_UID"].ToString();//dtG.Rows[viewData.FocusedRowHandle]["UNIT_UID"].ToString();
                DateTime ORDER_DT = Convert.ToDateTime(drv["ORDER TIME"]);//Convert.ToDateTime(dtG.Rows[viewData.FocusedRowHandle]["ORDER TIME"]);
                string exam_uid = drv["EXAM CODE"].ToString();//dtG.Rows[viewData.FocusedRowHandle]["EXAM CODE"].ToString();
                int intQTY = Convert.ToInt32(drv["QTY"]); //Convert.ToInt32(dtG.Rows[viewData.FocusedRowHandle]["QTY"]);
                int rate = Convert.ToInt32(drv["RATE"]);//Convert.ToInt32(dtG.Rows[viewData.FocusedRowHandle]["RATE"]);
                Amt = rate * intQTY;


                if (drv["INSURANCE_TYPE_ID"].ToString() != "")
                {

                    strInSu = drv["INSURANCE_TYPE_ID"].ToString();
                }
                else
                {
                    strInSu = " ";
                }

                if (Convert.ToInt32(drv["CLINIC_TYPE"]) == 1)
                {
                    strClinic = "R";

                }
                else
                {
                    strClinic = "S";
                }

                string OrderDOC = drv["EMP_UID"].ToString();


                strBilling = "#" + " " + "#" + HN + "#" + Accession + "#"
                                    + strAN + "#" + strISEQ + "#" + unit_uid + "#"
                                        + ORDER_DT.ToString("dd/MM") + "/" + ORDER_DT.Year + "#" + "C" + "#" + "3" + "#" + exam_uid + "#"
                                             + intQTY.ToString() + "#" + rate.ToString("#0.0") + "#" + Amt.ToString("#0.0") + "#"
                                                + OrderDOC + "# # # # #" + ORDER_DT.ToString("dd/MM") + "/" + ORDER_DT.Year + "#" + ORDER_DT.ToString("hh:mm") + "#"
                                                    + strMstype + "#" + strClinic + "#" + "3" + "#" + strInSu + "#" + "RD-0101" + "#" + "0" + "#" + env.UserUID + "#";

            }
            catch (Exception exx)
            {

                MessageBox.Show("Error :" + exx.Message);
            }

            #endregion
            return strBilling;
        }
        private void CancelBilling()
        {
            HIS_Patient BillHis = new HIS_Patient();
            DataTable dtG = (DataTable)grdData.DataSource;
            DataRow drv = viewData.GetDataRow(viewData.FocusedRowHandle);
           string strAN ="";
            string strISEQ = "";
            DataSet dsIPD = null;// BillHis.Get_ipd_detail(drv["HN"].ToString());
            for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
            {
                strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                if (strAN != "")
                {
                    //strMstype = "I";
                    strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                }
                else
                {
                    //strMstype = "O";
                    strAN = " ";
                }
                strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
            }
            //for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
            //{
            //    //strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
            //    //if (strAN != "")
            //    //{
            //    //    strMstype = "I";
            //    //}
            //    //else
            //    //{
            //    //    strMstype = "O";
            //    //}
            //    strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
            //}
            if (string.IsNullOrEmpty(strISEQ)) strISEQ = "1";
            if (string.IsNullOrEmpty(strAN)) strAN = " ";

             AccessionCan = drv["ACCESSION NO"].ToString();
             HNCan = drv["HN"].ToString();
             ANCan = strAN;
             ISEQCan = strISEQ;
        }
    }
}