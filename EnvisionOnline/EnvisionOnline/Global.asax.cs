using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;

using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;
using EnvisionOnline.Operational;
using System.IO;
namespace EnvisionOnline
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
            ScheduleClass sche = new ScheduleClass();
            RISBaseClass baseManage = new RISBaseClass();
            OrderClass ordManage = new OrderClass();

            DataTable dtt = baseManage.get_His_Department(1);
            dtt.PrimaryKey = new[] { dtt.Columns["UNIT_ID"] };
            Application["UnitData"] = dtt;

            dtt = baseManage.get_Patient_Status();
            dtt.PrimaryKey = new[] { dtt.Columns["STATUS_ID"] };
            Application["PatientStatusData"] = dtt;

            dtt = baseManage.get_RIS_ClinicType();
            dtt.Columns.Add("CLINIC_TYPE_ONLINEDESC");
            foreach (DataRow dr in dtt.Rows)
            {
                switch (dr["CLINIC_TYPE_UID"].ToString())
                {
                    case "Special": dr["CLINIC_TYPE_ONLINEDESC"] = "Special Clinic"; break;
                    case "VIP": dr["CLINIC_TYPE_ONLINEDESC"] = "Premium Clinic"; break;
                    case "Non-Resident": dr["CLINIC_TYPE_ONLINEDESC"] = "Non-Resident"; break;
                    case "CNMI": dr["CLINIC_TYPE_ONLINEDESC"] = "CNMI"; break;
                    default: dr["CLINIC_TYPE_ONLINEDESC"] = "Regular Clinic";break;
                }
            }
            dtt.PrimaryKey = new[] { dtt.Columns["CLINIC_TYPE_ID"] };
            Application["ClinicTypeData"] = dtt;

            dtt = baseManage.get_Ris_InsuranceType(1);
            dtt.PrimaryKey = new[] { dtt.Columns["INSURANCE_TYPE_ID"] };
            Application["InsuranceTypeData"] = dtt;

            dtt = baseManage.get_His_Doctor(1);
            dtt.PrimaryKey = new[] { dtt.Columns["EMP_ID"] };
            Application["HisDoctorData"] = dtt;

            dtt = baseManage.get_Ris_Radiologist();
            Application["RISDoctorData"] = dtt;

            dtt = baseManage.get_HIS_ICD();
            dtt.Columns.Add("ICD_FULL_TEXT");
            Application["HisICDData"] = dtt;

            dtt = baseManage.get_Ris_ExamAll();
            Application["ExamAllData"] = dtt;

            dtt = baseManage.get_Ris_Exam();
            Application["ExamData"] = dtt;

            dtt = baseManage.get_Exam_Panel();
            Application["ExamPanel"] = dtt;

            dtt = baseManage.get_Ris_ModalityType(true);
            dtt.Rows.Add(0, "--ALL--", "--ALL--", "ALL", "--ALL--");
            dtt.AcceptChanges();
            Application["ModalityType"] = dtt;

            dtt = baseManage.get_BP_View();
            Application["BP_VIEW"] = dtt;

            dtt = baseManage.get_GBL_ENV();
            Application["GBL_ENV"] = dtt;

            dtt = baseManage.get_ONL_GroupExamtype();
            Application["ONL_GROUPEXAMTYPE"] = dtt;

            dtt = baseManage.get_ONL_GroupExam();
            Application["ONL_GROUPEXAM"] = dtt;

            dtt = baseManage.get_ONL_GroupDepartment();
            Application["ONL_GROUPDEPARTMENT"] = dtt;

            dtt = ordManage.get_CancelTemplate();
            Application["CANCELTEMPLATE"] = dtt;
            Application["SearchMatch"] = baseManage.get_ONL_SearchMatch();

            Application["SessionTimeAll"] = sche.get_SessionTimeAll();
            Application["SessionType"] = baseManage.get_CLINICSESSION_TYPE();

        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string filePath = Context.Request.FilePath;
            Application["TheException"] = ex;

            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError();

            string strErrorExc = string.Format("********** {0} **********", DateTime.Now) + "\r\n";
            if (exc.InnerException != null)
            {
                strErrorExc += "Inner Exception Type: " + exc.InnerException.GetType().ToString() + "\r\n";
                strErrorExc += "Inner Exception: " + exc.InnerException.Message + "\r\n";
                strErrorExc += "Inner Source: " + exc.InnerException.Source + "\r\n";
                if (exc.InnerException.StackTrace != null)
                {
                    strErrorExc += "Inner Stack Trace: " + exc.InnerException.StackTrace + "\r\n";
                }
            }
            strErrorExc += "Exception Type: " + exc.GetType().ToString() + "\r\n";
            strErrorExc += "Exception: " + exc.Message + "\r\n";
            strErrorExc += "Source: " + exc.Source + "\r\n";
            if (exc.StackTrace != null)
            {
                strErrorExc += "Stack Trace: " + exc.StackTrace + "\r\n";
            }
            //Session["strError"] = strErrorExc;
            Server.Transfer("/Forms/Errors/pageError.aspx?ErrorExc="+strErrorExc);

            // Clear the error from the server
            Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}