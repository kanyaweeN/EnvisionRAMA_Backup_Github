using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Data.Common;

using Envision.Common;
using Envision.Common.Linq;

using Envision.DataAccess.Select;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.BusinessLogic
{
    public static class RISBaseData
    {
        public static int DefaultClinicType { get; set; }
        
        public static DataTable His_Department()
        {
            DataTable dtDepartment;
            ProcessGetHRUnit processDep = new ProcessGetHRUnit();
            processDep.Invoke();
            dtDepartment = processDep.Result.Tables[0].Copy();
            dtDepartment.TableName = "HIS_DEPARTMENT";
            return dtDepartment;
        }
        public static DataTable His_DepartmentCNMI()
        {
            DataTable dtDepartment;
            ProcessGetHRUnit processDep = new ProcessGetHRUnit();
            processDep.InvokeCNMI();
            dtDepartment = processDep.Result.Tables[0].Copy();
            dtDepartment.TableName = "HIS_DEPARTMENT";
            return dtDepartment;
        }
        public static DataTable BP_View()
        {
           
            DataTable dtBPView = new DataTable();
            ProcessGetRISBpview prcBP = new ProcessGetRISBpview();
            prcBP.Invoke();
            dtBPView = prcBP.Result.Tables[0].Copy();
            dtBPView.TableName = "BP_VIEW";
            return dtBPView;
        }
        public static DataTable His_Doctor()
        {
            DataTable dtDoctor = new DataTable();
            ProcessGetHISDoctor processDoctor = new ProcessGetHISDoctor();
            processDoctor.Invoke();
            dtDoctor = processDoctor.Result.Tables[0].Copy();
            dtDoctor.TableName = "HIS_DOCTOR";
            return dtDoctor;
        }
        public static DataTable Ris_Exam()
        {
            DataTable dtExam = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            processExam.Invoke();
            dtExam = processExam.Result.Tables[0].Copy();
            dtExam.TableName = "RIS_EXAM";
            return dtExam;
        }
        public static DataTable Ris_ExamCNMI()
        {
            DataTable dtExam = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            processExam.InvokeCNMI();
            dtExam = processExam.Result.Tables[0].Copy();
            dtExam.TableName = "RIS_EXAM";
            return dtExam;
        }
        public static DataTable Ris_Priority()
        {
           
            DataTable dtPrioriy = new DataTable();
            dtPrioriy.Columns.Add("PRI_ID", typeof(string));
            dtPrioriy.Columns.Add("PRIORITY", typeof(string));
            DataRow dr = dtPrioriy.NewRow();
            dr["PRI_ID"] = "S";
            dr["PRIORITY"] = "Stat";
            dtPrioriy.Rows.Add(dr);
            dr = dtPrioriy.NewRow();
            dr["PRI_ID"] = "R";
            dr["PRIORITY"] = "Routine";
            dtPrioriy.Rows.Add(dr);
            dr = dtPrioriy.NewRow();
            dr["PRI_ID"] = "U";
            dr["PRIORITY"] = "Urgent";
            dtPrioriy.Rows.Add(dr);
            dtPrioriy.TableName = "RIS_PRIORITY";
            return dtPrioriy;
        }
        public static DataTable Ris_Modality()
        {
            DataTable dtModality = new DataTable();
            ProcessGetRISModality processModality = new ProcessGetRISModality();
            processModality.Invoke();
            dtModality = processModality.Result.Tables[0].Copy();
            dtModality.TableName = "RIS_MODALITY";
            return dtModality;
        }
        public static DataTable Ris_ModalityExam()
        {
            DataTable dtModalityExam = new DataTable();
            ProcessGetRISModalityexam processMath = new ProcessGetRISModalityexam(true);
            processMath.Invoke();
            dtModalityExam = processMath.Result.Tables[0].Copy();
            dtModalityExam.TableName = "RIS_MODALITYEXAM";
            return dtModalityExam;
        }
        public static DataTable Ris_Radiologist()
        {
            DataTable dtRadiologist = new DataTable();
            ProcessGetRISOrderdtl processRadiologist = new ProcessGetRISOrderdtl();
            dtRadiologist = processRadiologist.GetRadioLogist().Copy();
            dtRadiologist.TableName = "HR_EMP";
            return dtRadiologist;
        }
        public static DataTable Ris_InsuranceType()
        {
           
            DataTable dtInsuranceType = new DataTable();
            ProcessGetRISInsurancetype processInsure = new ProcessGetRISInsurancetype();
            processInsure.Invoke();
            dtInsuranceType = processInsure.Result.Tables[0].Copy();
            dtInsuranceType.TableName = "RIS_INSURANCETYPE";
            return dtInsuranceType;
        }
        public static DataTable RIS_PatStatus()
        {
            DataTable dtPatStatus = new DataTable();
            ProcessGetRISPatstatus processPat = new ProcessGetRISPatstatus(true);
            processPat.Invoke();
            dtPatStatus = processPat.ResultSet.Tables[0].Copy();
            dtPatStatus.TableName = "RIS_PATSTATUS";
            return dtPatStatus;
        }
        public static DataTable RIS_ClinicType()
        {
            DataTable dtClinicType = new DataTable();
            ProcessGetRISClinictype processClinic = new ProcessGetRISClinictype();
            processClinic.Invoke();
            dtClinicType = processClinic.Result.Tables[0].Copy();
            dtClinicType.TableName = "RIS_CLINICTYPE";
            DefaultClinicType = 0;
            if (processClinic.Result != null)
                if (processClinic.Result.Tables.Count > 0)
                    if (processClinic.Result.Tables[0].Rows.Count > 0)
                        foreach (DataRow drClinic in processClinic.Result.Tables[0].Rows)
                        {
                            if (drClinic["IS_DEFAULT"].ToString().Trim() == "Y")
                            {
                                DefaultClinicType = Convert.ToInt32(drClinic["CLINIC_TYPE_ID"]);
                                break;
                            }
                        }
            return dtClinicType;
        }
        public static DbConnection ConnectionDataBase()
        {
            //DbTransaction tran = null;
            DbConnection con = null;
            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
            con = db.Connection();
            //con.Open();
            //tran = con.BeginTransaction();
            return con;
        }
    }
}
