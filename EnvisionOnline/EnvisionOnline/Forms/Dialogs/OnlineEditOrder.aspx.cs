using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Operational;
using EnvisionOnline.Common.Common;
using System.Globalization;
using EnvisionOnline.Common;
using System.Collections.Generic;
using System.Drawing;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class OnlineEditOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            if (Request.QueryString["EXAM_ID"] != null)
                param.EXAM_ID = Request.QueryString["EXAM_ID"];

            setControl();
        }
    }
    protected void cmbAssignTo_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        btnBackSchedule.Enabled = true;
        btnStat.Enabled = true;
        btnUpdate.Enabled = true;
        btnWaitingList.Enabled = true;

        if (!string.IsNullOrEmpty(cmbAssignTo.Text.Trim()))
        {
            btnBackSchedule.Enabled = false;
            btnStat.Enabled = false;
        }

    }
    protected void cmbAssignTo_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtDoc = Application["RISDoctorData"] as DataTable;
        cmbAssignTo.Items.Clear();

        string text = e.Text;
        DataRow[] rows = dtDoc.Select("RadioName LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbAssignTo.Items.Add(new RadComboBoxItem(rows[i]["RadioName"].ToString()));

    }
    private void setControl()
    {
        btnUpdate.Visible = false;
        btnBackSchedule.Visible = false;
        btnStat.Visible = false;
        btnWaitingList.Visible = false;

        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtDoc = Application["RISDoctorData"] as DataTable;

        DataTable dt = param.dvGridDtl;
        string _exam_id = param.EXAM_ID;
        DataRow[] rows = dt.Select("EXAM_ID=" + _exam_id);

        if (rows[0]["NEED_SCHEDULE"].ToString() != "Y")
        {
            lblHeader.Text = "แก้ไข / เพิ่มเติม รายละเอียดการส่งตรวจ";
            btnUpdate.Visible = true;
        }
        else
        {
            if (rows[0]["NEED_APPROVE"].ToString() == "Y")
            {
                lblHeader.Text = "แก้ไข / เพิ่มเติม รายละเอียดการขอนัดตรวจ";
                btnWaitingList.Visible = true;
            }
            else
            {
                lblHeader.Text = "คิวนัดเต็มในวันที่ระบุ\r\n กรุณาเลือกวันนัดใหม่ หรือขอส่งคิวนัดไปที่แผนกเอกซเรย์";

                if (rows[0]["PRIORITY"].ToString() == "U")
                {
                    btnWaitingList.Visible = true;
                }
                else
                {
                    btnBackSchedule.Visible = true;
                    btnStat.Visible = true;
                    btnWaitingList.Visible = true;
                }


                if (!string.IsNullOrEmpty(rows[0]["ASSIGNED_TO"].ToString()) && rows[0]["ASSIGNED_TO"].ToString() != "0")
                {
                    btnBackSchedule.Enabled = false;
                    btnStat.Enabled = false;
                }
            }
        }
        string _assignto = rows[0]["ASSIGNED_TO"] == null ? "0" : rows[0]["ASSIGNED_TO"].ToString() == "" ? "0" : rows[0]["ASSIGNED_TO"].ToString();
        DataRow[] rowDoc = dtDoc.Select("EMP_ID=" + _assignto);
        cmbAssignTo.Text = rowDoc.Length > 0 ? rowDoc[0]["RadioName"].ToString() : "";
        string PleaseAssign = "##### โปรดระบุส่วนตรวจของ " + rows[0]["EXAM_NAME"] + " ##### " + "\r\n";
        RISBaseClass getBpview = new RISBaseClass();
        DataTable dtBP = getBpview.get_BP_ViewMapping(_exam_id);
        DataRow[] rowsExamGD = param.dvGridDtl.Select("EXAM_ID=" + _exam_id);
        if (rowsExamGD[0]["BPVIEW_ID"].ToString() == "4")
            txtEditor.Text = PleaseAssign + rows[0]["COMMENTS"].ToString().Replace(PleaseAssign, "");
        else
            txtEditor.Text = rows[0]["COMMENTS"].ToString();

        dateRequest.SelectedDate = Convert.ToDateTime(rows[0]["ORDER_DT"]);
        //dateRequest.Enabled = rows[0]["strEXAM_DT"].ToString() == "Pending.." || rows[0]["strEXAM_DT"].ToString() == "Waiting list" ? false : true;
        dateRequest.Visible = rows[0]["NEED_SCHEDULE"].ToString() == "Y" ? false : true;
        labelStudyDatetime.Visible = rows[0]["NEED_SCHEDULE"].ToString() == "Y" ? false : true;
        dateRequest.MinDate = DateTime.Now;

        ProcessGetRISModality mod = new ProcessGetRISModality();
        DataSet dsModChk = mod.GetDataID(Convert.ToInt32(rows[0]["MODALITY_ID"]));
        if (Utilities.IsHaveData(dsModChk))
        {
            if (dsModChk.Tables[0].Rows[0]["DEFAULT_SESSION"].ToString() == "C")
                chkCNMI.Checked = true;
            else
                chkCNMI.Checked = false;

            //ProcessGetONLExamCNMI prc = new ProcessGetONLExamCNMI();
            //prc.Invoke(Convert.ToInt32(_exam_id));
            //if (Utilities.IsHaveData(prc.Result))
            //    chkCNMI.Visible = true;
            //else
            //    chkCNMI.Visible = false;

            ProcessGetRISModalityexam modExam = new ProcessGetRISModalityexam();
            DataSet dsModExam = modExam.getModalityCNMIByExamID(Convert.ToInt32(_exam_id));
            if (Utilities.IsHaveData(dsModExam))
                chkCNMI.Visible = true;
            else
                chkCNMI.Visible = false;
        }

        if (rows[0]["EXAM_TYPE"].ToString() == "2") //2 = CT
        {
            chkCT3D.Visible = true;
            if (rows[0]["COMMENTS"].ToString().Contains("CT 3D") == true)
            {
                chkCT3D.Checked = true;
            }else{
                chkCT3D.Checked = false;
            }
        }
        else
        {
            chkCT3D.Visible = false;
        }
    }
    private void setUpdateData(string confirm_button_by)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dtDoc = Application["RISDoctorData"] as DataTable;

        DataTable dt = param.dvGridDtl;
        string _exam_id = param.EXAM_ID;
        DataRow[] rows = dt.Select("EXAM_ID=" + _exam_id);
        foreach (DataRow dr in rows)
        {
            DataRow[] rowDoc = dtDoc.Select("RadioName='" + cmbAssignTo.Text + "'");

            dr["ASSIGNED_TO"] = rowDoc.Length > 0 ? Convert.ToInt32(rowDoc[0]["EMP_ID"]) : 0;
            dr["COMMENTS"] = txtEditor.Text.Trim();
            string ii = dr["COMMENTS"].ToString();
            switch (confirm_button_by)
            {
                case "btn_Click":
                    if (dr["NEED_SCHEDULE"].ToString() != "Y")// || dr["PRIORITY"].ToString() == "S")
                    {
                        DateTime _order_dt = dateRequest.SelectedDate.Value;
                        DateTime _exam_dt = dateRequest.SelectedDate.Value;
                        string _strExam_dt = dateRequest.SelectedDate.Value.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);

                        dr["ORDER_DT"] = _order_dt;
                        dr["EXAM_DT"] = _exam_dt;
                        dr["strEXAM_DT"] = _strExam_dt;
                        if (!string.IsNullOrEmpty(dr["IS_PORTABLE_VALUE"].ToString()))
                            if (dr["IS_PORTABLE_VALUE"].ToString() == "Y")
                            {
                                DataTable dtPanelPortable = new DataTable();
                                RISBaseClass baseMange = new RISBaseClass();
                                dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(dr["EXAM_ID"]), param.CLINIC_TYPE_ID);
                                foreach (DataRow drPortable in dtPanelPortable.Rows)
                                {
                                    DataRow[] arryrows = dt.Select("EXAM_ID=" + drPortable["AUTO_EXAM_ID"].ToString());
                                    if (arryrows.Length > 0)
                                    {
                                        arryrows[0]["ORDER_DT"] = _order_dt;
                                        arryrows[0]["EXAM_DT"] = _exam_dt;
                                        arryrows[0]["strEXAM_DT"] = _strExam_dt;
                                    }
                                }
                            }
                    }
                    break;
                case "btnWaitingList_Click":
                    DateTime _order_dt_waiting = DateTime.Now;
                    DateTime _exam_dt_waiting = DateTime.Now;
                    string _strExam_dt_waiting = "Waiting list";


                    dr["ORDER_DT"] = _order_dt_waiting;
                    dr["EXAM_DT"] = _exam_dt_waiting;
                    dr["strEXAM_DT"] = _strExam_dt_waiting;
                    //if (dr["PRIORITY"].ToString() == "U")
                    //{
                    //    dr["PRIORITY"] = "U";
                    //    dr["PRIORITY_TEXT"] = "Urgent";
                    //}
                    //else
                    //{
                    //    dr["PRIORITY"] = "R";
                    //    dr["PRIORITY_TEXT"] = "Routine";
                    //}
                    //dr["PRIORITY"] = "U";
                    //dr["PRIORITY_TEXT"] = "Urgent";
                    DataTable dtPanel = Application["ExamPanel"] as DataTable;
                    DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    if (chkPanel.Length > 0)
                    {
                        DataRow[] rowFillPanel = dt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
                        if (rowFillPanel.Length > 0)
                        {
                            rowFillPanel[0]["ORDER_DT"] = _order_dt_waiting;
                            rowFillPanel[0]["EXAM_DT"] = _exam_dt_waiting;
                            rowFillPanel[0]["strEXAM_DT"] = _strExam_dt_waiting;
                            //if (dr["PRIORITY"].ToString() == "U")
                            //{
                            //    dr["PRIORITY"] = "U";
                            //    dr["PRIORITY_TEXT"] = "Urgent";
                            //}
                            //else
                            //{
                            //    dr["PRIORITY"] = "R";
                            //    dr["PRIORITY_TEXT"] = "Routine";
                            //}
                            //rowFillPanel[0]["PRIORITY"] = "U";
                            //rowFillPanel[0]["PRIORITY_TEXT"] = "Urgent";
                            rowFillPanel[0]["ASSIGNED_TO"] = rowDoc.Length > 0 ? Convert.ToInt32(rowDoc[0]["EMP_ID"]) : 0;
                            rowFillPanel[0]["COMMENTS"] = txtEditor.Text.Trim();

                        }
                    }
                    break;
                case "btnBackSchedule_Click":
                    dr["PRIORITY"] = "R";
                    dr["PRIORITY_TEXT"] = "Routine";
                    break;
                case "btnStat_Click":
                    dr["ORDER_DT"] = DateTime.Now;
                    dr["EXAM_DT"] = DateTime.Now;
                    dr["strEXAM_DT"] = "Waiting list";// DateTime.Now.ToString("d MMM yyyy H:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
                    dr["PRIORITY"] = "S";
                    dr["PRIORITY_TEXT"] = "Stat";
                    break;
            }

        }
        param.dvGridDtl = dt;
        param.dvGridDtlRebind = dt;
        Session["ONL_PARAMETER"] = param;

        if (Request.QueryString["WINDOWS"] != null)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "NormalWindow();", true);
        else
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        setUpdateData("btn_Click");
    }
    protected void btnWaitingList_Click(object sender, EventArgs e)
    {
        setUpdateData("btnWaitingList_Click");
    }
    protected void btnBackSchedule_Click(object sender, EventArgs e)
    { setUpdateData("btnBackSchedule_Click"); }
    protected void btnStat_Click(object sender, EventArgs e)
    { setUpdateData("btnStat_Click"); }
    protected void rdoDischarge_CheckedChanged(object source, EventArgs e)
    {
        if (rdoDischarge.Checked)
        {
            lblNextApp.Visible = true;
            dtNextAppoint.Visible = true;
            btnAllNextAppoint.Visible = true;
        }
        else
        {
            lblNextApp.Visible = false;
            dtNextAppoint.Visible = false;
            btnAllNextAppoint.Visible = false;
        }
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        PatientClass getPatient = new PatientClass();
        DataSet ds = getPatient.get_appointment_detail(param.HN);
        Session["ALLNextAppointment"] = ds;
        if (Utilities.IsHaveData(ds))
        {
            if (Utilities.IsHaveData(param.dtBasicData))
            {
                DataRow[] rowChk = ds.Tables[0].Select("appt_doc_code='" + param.dtBasicData.Rows[0]["REF_DOC_UID"].ToString() + "' and appt_doc_dept_code='" + param.dtBasicData.Rows[0]["REF_UNIT_UID"].ToString() + "'");
                if (rowChk.Length > 0)
                {
                    dtNextAppoint.SelectedDate = Convert.ToDateTime(rowChk[0]["appt_date"].ToString());

                    Session["textDisChange"] = "มีนัดตรวจแพทย์ครั้งต่อไป วันที่ " + dtNextAppoint.SelectedDate.Value.ToString("dd/MM/yyyy") + "\r\n";
                    txtEditor.Text = Session["textDisChange"].ToString() + txtEditor.Text;
                }
                else
                {
                    lblNextApp.ForeColor = Color.Red;
                    lblNextApp.Text = "Next Appoint*";
                }
            }
        }
        else
        {
            lblNextApp.ForeColor = Color.Red;
            lblNextApp.Text = "Next Appoint*";
        }
    }
    protected void chkCNMI_CheckedChanged(object source, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        DataTable dt = param.dvGridDtl;
        string _exam_id = param.EXAM_ID;
        DataRow[] rows = dt.Select("EXAM_ID=" + _exam_id);
        ProcessGetRISModality mod = new ProcessGetRISModality();
        DataSet dsModChk = mod.GetDataID(Convert.ToInt32(rows[0]["MODALITY_ID"]));
        if (Utilities.IsHaveData(dsModChk))
        {
            if (chkCNMI.Checked)
            {
                if (dsModChk.Tables[0].Rows[0]["DEFAULT_SESSION"].ToString() != "C")
                {
                    ProcessGetRISModalityexam modExam = new ProcessGetRISModalityexam();
                    DataSet dsModExam = modExam.getModalityCNMIByExamID(Convert.ToInt32(_exam_id));
                    if (Utilities.IsHaveData(dsModExam))
                    {
                        rows[0]["MODALITY_ID"] = dsModExam.Tables[0].Rows[0]["MODALITY_ID"];
                        try
                        {
                            rows[0]["MODALITY_UID"] = dsModExam.Tables[0].Rows[0]["MODALITY_UID"];
                            rows[0]["MODALITY_NAME"] = dsModExam.Tables[0].Rows[0]["MODALITY_NAME"];
                        }
                        catch { }
                    }
                }
            }
            else 
            {
                RISBaseClass risbase = new RISBaseClass();
                DataTable dtDept = Application["UnitData"] as DataTable;
                DataTable dtPatDest = risbase.get_PAT_DEST_ID(param.REF_UNIT_ID, param.CLINIC_TYPE_ID);
                int pat_dest_id = string.IsNullOrEmpty(dtPatDest.Rows[0]["PAT_DEST_ID"].ToString()) ? 0 : Convert.ToInt32(dtPatDest.Rows[0]["PAT_DEST_ID"].ToString());
                DataTable dtMod_ID = risbase.get_ModalityID_With_PatDest(Convert.ToInt32(_exam_id), pat_dest_id, SpecifyData.checkPatientType(param.IS_CHILDEN, dtDept, param.REF_UNIT_ID, param.ENC_CLINIC));
                dtMod_ID = Utilities.filterModalityByClinic(dtMod_ID, param.ENC_CLINIC);
                rows[0]["MODALITY_ID"] = dtMod_ID.Rows[0]["MODALITY_ID"];
                try
                {
                    rows[0]["MODALITY_UID"] = dtMod_ID.Rows[0]["MODALITY_UID"];
                    rows[0]["MODALITY_NAME"] = dtMod_ID.Rows[0]["MODALITY_NAME"];
                }
                catch { }
            }
        }
        if (chkCNMI.Checked)
        {
            txtEditor.Text = chkCNMI.Text + "\r\n" + txtEditor.Text;
        }
        else {
            txtEditor.Text = txtEditor.Text.Replace(chkCNMI.Text, "").Trim();
        }
    }
    protected void chkCt3d_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCT3D.Checked)
        {
            txtEditor.Text = "ขอทำ CT 3D" + "\r\n" + txtEditor.Text;
        }
        else
        {
            txtEditor.Text = txtEditor.Text.Replace("ขอทำ CT 3D", "").Trim();
        }
    }
    protected void dtNextAppoint_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        string txtDischange = Session["textDisChange"] == null ? "" : Session["textDisChange"].ToString();
        string txt = "มีนัดตรวจแพทย์ครั้งหน้า วันที่ " + dtNextAppoint.SelectedDate.Value.ToString("dd/MM/yyyy") + "\r\n";
        if (!string.IsNullOrEmpty(txtDischange))
            txtEditor.Text = txtEditor.Text.Replace(txtDischange, "");
        txtEditor.Text = txt + txtEditor.Text;
        Session["textDisChange"] = txt;
    }
    protected void btnNexAppoint_Click(object sender, EventArgs e)
    {
        if (dtNextAppoint.SelectedDate == null)
        {

        }
        else
        {
            txtEditor.Text = txtEditor.Text + "\r\n มีนัดตรวจแพทย์ครั้งหน้า วันที่ " + dtNextAppoint.SelectedDate.Value.ToString("dd/MM/yyyy");
        }
    }
    protected void btnAllNextAppoint_Click(object sender, EventArgs e)
    {
        DataSet ds = Session["ALLNextAppointment"] as DataSet;
        if (Utilities.IsHaveData(ds))
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openAllAppointPage", "showAllNextAppoint();", true);
        }
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
    }

    
}
