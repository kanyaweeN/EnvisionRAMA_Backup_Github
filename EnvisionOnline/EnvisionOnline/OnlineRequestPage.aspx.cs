using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnvisionOnline.Common;
using EnvisionOnline.Operational;
using System.Text;
using System.Data;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.BusinessLogic.ProcessRead;

namespace EnvisionOnline
{
    public partial class OnlineRequestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool flag = false;
                ONL_PARAMETER param = new ONL_PARAMETER();


                if (has_value(Request.Params["HN"]))
                    param.HN = Request.Params["HN"].Trim();
                else
                    flag = true;

                if (has_value(Request.Params["USER_NAME"]))
                    param.USER_NAME = Request.Params["USER_NAME"].Trim();
                else
                    flag = true;

                if (has_value(Request.Params["UNIT"]))
                    param.REF_UNIT_UID = Request.Params["UNIT"].Trim();
                else
                    flag = true;
                if (has_value(Request.Params["CLINIC"]))
                {
                    switch (Request.Params["CLINIC"].ToString().Substring(0, 1))
                    {
                        case "P": param.ENC_CLINIC = "PM"; break;
                        case "R": param.ENC_CLINIC = "RGL"; break;
                        case "S": param.ENC_CLINIC = "SPC"; break;
                        default: param.ENC_CLINIC = Request.Params["CLINIC"].ToString().Trim(); break;
                    }
                }
                else
                    flag = true;
                if (!flag)
                {
                    string check_clinic = SpecifyData.checkClinic(param.REF_UNIT_UID);
                    if (!string.IsNullOrEmpty(param.REF_UNIT_UID))
                        param.ENC_CLINIC = string.IsNullOrEmpty(check_clinic) ? param.ENC_CLINIC : check_clinic;
                }
                if (has_value(Request.Params["INSR"]))
                    param.INSURANCE_TYPE_UID = Request.Params["INSR"].Trim();
                else
                    flag = true;
                if (has_value(Request.Params["ROLE"]))
                    param.ROLE = Request.Params["ROLE"].Trim();
                else
                    flag = true;
                if (has_value(Request.Params["ENC"]))
                {
                    switch (Request.Params["ENC"].ToString().Trim())
                    {
                        case "EMR": param.ENCOUNTER_TYPE = "EMER"; break;
                        default: param.ENCOUNTER_TYPE = Request.Params["ENC"].Trim(); break;
                    }
                }
                else
                    flag = true;

                if (has_value(Request.Params["FORM"]))
                    param.FORM = Request.Params["FORM"].Trim();
                else
                    flag = true;

                if (flag)
                {
                    bool is_worklist = false;
                    Session["ONL_PARAMETER"] = param;
                    Session["QueryString"] = Request.QueryString.ToString();
                    if (param.FORM == "W" &&
                        !string.IsNullOrEmpty(param.USER_NAME))
                        is_worklist = true;
                    else if (string.IsNullOrEmpty(param.FORM))
                    {
                        is_worklist = true;
                        param.FORM = "R1";
                    }

                    if (is_worklist)
                        Response.Redirect(@"Forms/Orders/frmEnvisionOrderWL.aspx", true);
                    else
                        Response.Redirect(@"frmCheckParameterFromHIS.aspx");
                }
                else
                {
                    bool newOnline = false;
                    try
                    {
                        ProcessGetHRUnit process = new ProcessGetHRUnit();
                        DataSet ds = process.checkNewOnlineUnit();

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow[] dr = ds.Tables[0].Select("UNIT_UID = '" + param.REF_UNIT_UID + "'");
                                if (dr.Length > 0)
                                {
                                    newOnline = true;
                                    string str = @"HN=" + param.HN
                                        + "&USER_NAME=" + param.USER_NAME
                                        + "&CLINIC=" + param.ENC_CLINIC
                                        + "&UNIT=" + param.REF_UNIT_UID
                                        + "&INSR=" + param.INSURANCE_TYPE_UID
                                        + "&ROLE=" + param.ROLE
                                        + "&ENC=" + param.ENCOUNTER_TYPE
                                        + "&FORM=" + param.FORM;
                                    //Response.Redirect(@"http://miracleonline/Envision6Online/#/OnlineRequestPage?" + str, true);
                                    Response.Redirect(@"http://miracleonline/Envision6OnlineTest/#/OnlineRequestPage?" + str, true);
                                    //Response.Redirect(@"http://127.0.0.1:8080/#/OnlineRequestPage?" + str, true);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        newOnline = false;
                    }

                    if (!newOnline)
                    {
                        Session["ONL_PARAMETER"] = param;
                        Response.Redirect(@"Forms/Orders/frmEnvisionOrderWL.aspx", true);
                    }
                }

            }
        }
        private bool has_value(object source)
        {
            bool flag;
            if (source != null)
            {
                if (string.IsNullOrEmpty(source.ToString()))
                    flag = false;
                else
                    flag = true;
            }
            else {
                flag = false;
            }
            return flag;
        }
    }
}