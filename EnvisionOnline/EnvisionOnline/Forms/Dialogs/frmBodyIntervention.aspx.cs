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
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.Common;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Operational;
using System.Globalization;
using System.Collections.Generic;

public partial class frmBodyIntervention : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clearData();
            loadData();
        }
    }
    private void clearData()
    {
        //Organ
        chkOrganThyroid.Checked = false;
        chkOrganCervical.Checked = false;

        //side
        chkRight.Checked = false;
        chkLeft.Checked = false;
        chkRightUpper.Checked = false;
        chkRightMiddle.Checked = false;
        chkRightLower.Checked = false;
        chkLeftUpper.Checked = false;
        chkLeftMiddle.Checked = false;
        chkLeftLower.Checked = false;

        chkRight.Enabled = false;
        chkLeft.Enabled = false;
        chkOther.Enabled = false;
        chkRightUpper.Enabled = false;
        chkRightMiddle.Enabled = false;
        chkRightLower.Enabled = false;
        chkLeftUpper.Enabled = false;
        chkLeftMiddle.Enabled = false;
        chkLeftLower.Enabled = false;

        txtOther.Text = string.Empty;

        //Imaging
        chkImagingYes.Checked = false;
        chkImagingMRI.Checked = false;
        chkImagingCT.Checked = false;
        chkImagingUS.Checked = false;
        dateImaging.SelectedDate = null;

        chkImagingNo.Checked = false;
        chkImagingUSNeck.Checked = false;
        chkImagingUSThyroid.Checked = false;

        chkImagingMRI.Enabled = false;
        chkImagingCT.Enabled = false;
        chkImagingUS.Enabled = false;
        dateImaging.Enabled = false;

        chkImagingUSNeck.Enabled = false;
        chkImagingUSThyroid.Enabled = false;

        //Drug
        chkDrugYes.Checked = false;
        chkDrugNo.Checked = false;

    }
    private void loadData()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        PatientClass getPatient = new PatientClass();

        DataSet ds = param.dsPatientData;// getPatient.get_Patient_Registration_ByHN(_hn, env);
        DateTime end = DateTime.Now;
        DateTime start = end.AddYears(-2);

        btnCancle.Visible = true;
        if (Session["savecheckAppointCase"] != null)
        {
            if (Session["savecheckAppointCase"] == "Y")
                btnCancle.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;

        DataSet ds = param.dsPatientData;// getPatient.get_Patient_Registration_ByHN(_hn, env);

        bool flge = false;
        if ((!chkOrganThyroid.Checked && !chkOrganCervical.Checked) ||
            (!chkImagingYes.Checked && !chkImagingNo.Checked) ||
            (!chkDrugYes.Checked && !chkDrugNo.Checked))
            flge = true;
        else if (chkImagingYes.Checked && (!chkImagingCT.Checked && !chkImagingUS.Checked && !chkImagingMRI.Checked && dateImaging.SelectedDate == null))
            flge = true;
        else if (chkOther.Checked && string.IsNullOrEmpty(txtOther.Text.Trim()))
            flge = true;
        else if (chkImagingNo.Checked && (!chkImagingUSNeck.Checked && !chkImagingUSThyroid.Checked))
            flge = true;

        if (flge)
            lblAlert.Text = "กรุณาเลือกข้อมูลให้ครบ";
        else
        {
            saveBodyIntervention();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "CloseAndRebind('BodyIntervention');", true);
        }
        
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "OnClientClose();", true);
    }
    private void saveBodyIntervention()
    {
        string strComment = string.Empty;
        string strHeader = string.Empty;
        string strExamPanal = string.Empty;
        int qty = 0;

        //พยายามเอา Header กับ ข้อมูลให้อยู่บรรทัดเดียวกันเช่น lblOrgan -> yes \r\n ประมาณนี้เวลาลบคอมเมนจะได้ง่าย
        #region Organ
        strHeader += lblOrgan.Text + "|";
        strComment += lblOrgan.Text + " -> ";
        if (chkOrganThyroid.Checked)
            strComment += chkOrganThyroid.Text;
        else
            strComment += chkOrganCervical.Text;
        strComment += "\r\n";
        #endregion

        #region Side
        strHeader += lblSide.Text + "|";
        strComment += lblSide.Text + " -> ";

        string strRight = string.Empty;
        string strLeft = string.Empty;
        string strOther = string.Empty;

        string strSide = string.Empty;
        //if (chkOrganThyroid.Checked)
        //{
        //    if (chkRightUpper.Checked)
        //    {
        //        qty++;
        //        strRight = checkStrAddComma(strRight) + chkRightUpper.Text;
        //    }
        //    if (chkRightMiddle.Checked)
        //    {
        //        qty++;
        //        strRight = checkStrAddComma(strRight) + chkRightMiddle.Text;
        //    }
        //    if (chkRightLower.Checked)
        //    {
        //        qty++;
        //        strRight = checkStrAddComma(strRight) + chkRightLower.Text;
        //    }

        //    if (chkLeftUpper.Checked)
        //    {
        //        qty++;
        //        strLeft = checkStrAddComma(strLeft) + chkLeftUpper.Text;
        //    }
        //    if (chkLeftMiddle.Checked)
        //    {
        //        qty++;
        //        strLeft = checkStrAddComma(strLeft) + chkLeftMiddle.Text;
        //    }
        //    if (chkLeftLower.Checked)
        //    {
        //        qty++;
        //        strLeft = checkStrAddComma(strLeft) + chkLeftLower.Text;
        //    }

        //    if (chkOther.Checked)
        //    {
        //        qty++;
        //        strOther = checkStrAddComma(strOther) + chkOther.Text;
        //    }

        //    if (!string.IsNullOrEmpty(strRight))
        //        strSide = chkRight.Text + " : " + strRight;

        //    if (!string.IsNullOrEmpty(strLeft))
        //    {
        //        if (!string.IsNullOrEmpty(strSide))
        //            strSide += " -> ";
        //        strSide += chkLeft.Text + " : " + strLeft;
        //    }

        //    if (!string.IsNullOrEmpty(strOther))
        //    {
        //        if (!string.IsNullOrEmpty(strSide))
        //            strSide += " -> ";
        //        strSide += strOther;
        //    }
        //}
        //else
        //{
        //    if (chkRight.Checked)
        //    {
        //        qty++;
        //        strRight = chkRight.Text;
        //    }

        //    if (chkLeft.Checked)
        //    {
        //        qty++;
        //        strLeft = chkLeft.Text;
        //    }

        //    if (!string.IsNullOrEmpty(strRight))
        //        strSide = strRight;

        //    if (!string.IsNullOrEmpty(strLeft))
        //    {
        //        if (!string.IsNullOrEmpty(strSide))
        //            strSide += ", " + strLeft;
        //    }
        //}
        if (chkOrganThyroid.Checked)
        {
            if (chkRightUpper.Checked)
            {
                qty++;
                strRight = checkStrAddComma(strRight) + chkRightUpper.Text;
            }
            if (chkRightMiddle.Checked)
            {
                qty++;
                strRight = checkStrAddComma(strRight) + chkRightMiddle.Text;
            }
            if (chkRightLower.Checked)
            {
                qty++;
                strRight = checkStrAddComma(strRight) + chkRightLower.Text;
            }

            if (chkLeftUpper.Checked)
            {
                qty++;
                strLeft = checkStrAddComma(strLeft) + chkLeftUpper.Text;
            }
            if (chkLeftMiddle.Checked)
            {
                qty++;
                strLeft = checkStrAddComma(strLeft) + chkLeftMiddle.Text;
            }
            if (chkLeftLower.Checked)
            {
                qty++;
                strLeft = checkStrAddComma(strLeft) + chkLeftLower.Text;
            }

            if (chkOther.Checked)
            {
                qty++;
                strOther = checkStrAddComma(strOther) + chkOther.Text;
            }

            if (!string.IsNullOrEmpty(strRight))
                strSide = strRight;

            if (!string.IsNullOrEmpty(strLeft))
                strSide = checkStrAddComma(strSide) + strLeft;

            if (!string.IsNullOrEmpty(strOther))
                strSide = checkStrAddComma(strSide) + strOther + " " + txtOther.Text.Trim();
            
        }
        else
        {
            if (chkRight.Checked)
            {
                qty++;
                strRight = chkRight.Text;
            }

            if (chkLeft.Checked)
            {
                qty++;
                strLeft = chkLeft.Text;
            }

            if (chkOther.Checked)
            {
                qty++;
                strOther = checkStrAddComma(strOther) + chkOther.Text;
            }

            if (!string.IsNullOrEmpty(strRight))
                strSide = strRight;

            if (!string.IsNullOrEmpty(strLeft))
                strSide = checkStrAddComma(strSide) + strLeft;

            if (!string.IsNullOrEmpty(strOther))
                strSide = checkStrAddComma(strSide) + strOther + " " + txtOther.Text.Trim();
        }

        //if (!string.IsNullOrEmpty(strSide))
        //    strComment += strSide;

        strComment += "\r\n";
        #endregion

        #region Imaging
        strHeader += lblImaging.Text + "|";
        strComment += lblImaging.Text + " -> ";
        if (chkImagingYes.Checked)
        {
            strComment += chkImagingYes.Text;

            string strImagingYes = string.Empty;
            if (chkImagingMRI.Checked)
                strImagingYes = checkStrAddComma(strImagingYes) + chkImagingMRI.Text;
            if (chkImagingCT.Checked)
                strImagingYes = checkStrAddComma(strImagingYes) + chkImagingCT.Text;
            if (chkImagingUS.Checked)
                strImagingYes = checkStrAddComma(strImagingYes) + chkImagingUS.Text;

            if (!string.IsNullOrEmpty(strImagingYes))
                strComment += " : " + strImagingYes + " " + dateImaging.SelectedDate.Value.ToString("dd/MM/yyyy");
        }
        else
        {
            strComment += chkImagingNo.Text;

            string strImagingNo = string.Empty;

            if (chkImagingUSNeck.Checked)
            {
                strExamPanal = checkStrAddComma(strExamPanal) + chkImagingUSNeck.Value;
                strImagingNo = checkStrAddComma(strImagingNo) + chkImagingUSNeck.Value + ':' + chkImagingUSNeck.Text;
            }

            if (chkImagingUSThyroid.Checked)
            {
                strExamPanal = checkStrAddComma(strExamPanal) + chkImagingUSThyroid.Value;
                strImagingNo = checkStrAddComma(strImagingNo) + chkImagingUSThyroid.Value + ':' + chkImagingUSThyroid.Text;
            }

            if (!string.IsNullOrEmpty(strImagingNo))
                strComment += " : " + strImagingNo;
        }
        strComment += "\r\n";
        #endregion

        #region Drug
        strHeader += lblDrug.Text + "|";
        strComment += lblDrug.Text + " -> ";
        if (chkOrganThyroid.Checked)
            strComment += chkDrugYes.Text;
        else
            strComment += chkDrugNo.Text;
        strComment += "\r\n";
        #endregion

        DataTable dt = new DataTable();
        dt.Columns.Add("Comment", typeof(string));
        dt.Columns.Add("Side", typeof(string));
        dt.Columns.Add("Header", typeof(string));
        dt.Columns.Add("ExamPanel", typeof(string));
        dt.Columns.Add("QTY", typeof(int));
        DataRow dr = dt.NewRow();
        dr["Header"] = strHeader;   //เอาไว้ลบคอมเมนอันเก่า ถ้า user เข้ามา edit มันจะมีคอมเมนเดิมอยู่ เลยสร้างตัวนี้เอาไว้ค้นหาและลบคอมเมนเก่าออก ไม่อย่างนั้นมันจะซ้ำ
        dr["Comment"] = strComment;
        dr["Side"] = lblSide.Text + " -> " + "|" + strSide;
        dr["ExamPanel"] = strExamPanal;
        dr["QTY"] = qty == 0 ? 1 : qty;
        dt.Rows.Add(dr);
        Session["dataBodyIntervention"] = dt;
    }

    string checkStrAddComma(string str)
    {
        string addstr = str;
        if (!string.IsNullOrEmpty(addstr))
            addstr += ", ";
        return addstr;
    }

    protected void chkImaging_CheckedChanged(object sender, EventArgs e)
    {
        if (chkImagingYes.Checked)
        {
            chkImagingMRI.Enabled = true;
            chkImagingCT.Enabled = true;
            chkImagingUS.Enabled = true;
            dateImaging.Enabled = true;

            chkImagingUSNeck.Enabled = false;
            chkImagingUSThyroid.Enabled = false;
        }
        else
        {
            chkImagingMRI.Enabled = false;
            chkImagingCT.Enabled = false;
            chkImagingUS.Enabled = false;
            dateImaging.Enabled = false;

            chkImagingUSNeck.Enabled = true;
            chkImagingUSThyroid.Enabled = true;
        }

        chkImagingMRI.Checked = false;
        chkImagingCT.Checked = false;
        chkImagingUS.Checked = false;

        chkImagingUSNeck.Checked = false;
        chkImagingUSThyroid.Checked = false;
        dateImaging.SelectedDate = null;
    }
    protected void chkOrgan_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOrganThyroid.Checked)
        {
            chkRightLower.Visible = true;
            chkRightMiddle.Visible = true;
            chkRightUpper.Visible = true;
            chkLeftLower.Visible = true;
            chkLeftMiddle.Visible = true;
            chkLeftUpper.Visible = true;

            chkRight.Visible = false;
            chkLeft.Visible = false;

            chkRightLower.Enabled = true;
            chkRightMiddle.Enabled = true;
            chkRightUpper.Enabled = true;
            chkLeftLower.Enabled = true;
            chkLeftMiddle.Enabled = true;
            chkLeftUpper.Enabled = true;

            chkRight.Enabled = false;
            chkLeft.Enabled = false;
        }
        else
        {
            chkRightLower.Visible = false;
            chkRightMiddle.Visible = false;
            chkRightUpper.Visible = false;
            chkLeftLower.Visible = false;
            chkLeftMiddle.Visible = false;
            chkLeftUpper.Visible = false;

            chkRight.Visible = true;
            chkLeft.Visible = true;

            chkRightLower.Enabled = false;
            chkRightMiddle.Enabled = false;
            chkRightUpper.Enabled = false;
            chkLeftLower.Enabled = false;
            chkLeftMiddle.Enabled = false;
            chkLeftUpper.Enabled = false;

            chkRight.Enabled = true;
            chkLeft.Enabled = true;
        }
        chkOther.Visible = true;
        txtOther.Visible = true;

        chkOther.Enabled = true;
        txtOther.Enabled = true;
        txtOther.Text = string.Empty;

        chkRight.Checked = false;
        chkLeft.Checked = false;

        chkRightLower.Checked = false;
        chkRightMiddle.Checked = false;
        chkRightUpper.Checked = false;
        chkLeftLower.Checked = false;
        chkLeftMiddle.Checked = false;
        chkLeftUpper.Checked = false;
        chkOther.Checked = false;
    }
    protected void chkOther_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOther.Checked)
        {
            txtOther.Enabled = true;
        }
        else
        {
            txtOther.Enabled = false;
        }
        txtOther.Text = string.Empty;
    }
   
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    { 
    }
}
