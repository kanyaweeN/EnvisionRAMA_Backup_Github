using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Common.Common;
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.Webservice.HISWebService;
using EnvisionOnline.BusinessLogic.ProcessUpdate;

namespace EnvisionOnline.BusinessLogic
{
    public class RISBaseClass
    {
        public EnvisionOnline.Common.HR_EMP HR_EMP { get; set; }
        public EnvisionOnline.Common.RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }
        public EnvisionOnline.Common.RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }
        public EnvisionOnline.Common.RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }
        public RISBaseClass()
        {
            HR_EMP = new EnvisionOnline.Common.HR_EMP();
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
        }
        public DataTable get_His_Department(int org_id)
        {
            DataTable dtDepartment;
            ProcessGetHRUnit processDep = new ProcessGetHRUnit();
            processDep.HR_UNIT.ORG_ID = org_id;
            processDep.Invoke();
            dtDepartment = processDep.Result.Tables[0].Copy();
            dtDepartment.TableName = "HIS_DEPARTMENT";
            return dtDepartment;
        }
        public DataTable get_BP_View()
        {
            DataTable dtBPView = new DataTable();
            ProcessGetRISBpview prcBP = new ProcessGetRISBpview();
            prcBP.Invoke();
            dtBPView = prcBP.Result.Tables[0].Copy();
            dtBPView.TableName = "BP_VIEW";
            return dtBPView;
        }
        public DataTable get_BP_ViewMapping(string exam_uid)
        {
            DataTable dtBPViewMap = new DataTable();
            ProcessGetRISBpviewMapping prcBPM = new ProcessGetRISBpviewMapping();
            prcBPM.Exam_UID = exam_uid;
            prcBPM.Invoke();
            dtBPViewMap = prcBPM.Result.Tables[0].Copy();
            dtBPViewMap.TableName = "BPVIEWMAPPING";
            return dtBPViewMap;
        }
        public DataTable get_His_Doctor(int org_id)
        {
            DataTable dtDoctor = new DataTable();
            ProcessGetHISDoctor processDoctor = new ProcessGetHISDoctor();
            dtDoctor = processDoctor.getData(org_id).Tables[0].Copy();
            dtDoctor.TableName = "HIS_DOCTOR";
            return dtDoctor;
        }
        public DataTable get_Ris_Radiologist()
        {
            DataTable dtRadiologist = new DataTable();
            ProcessGetRISOrderdtl processRadiologist = new ProcessGetRISOrderdtl();
            dtRadiologist = processRadiologist.GetRadioLogist().Copy();
            dtRadiologist.TableName = "HR_EMP";
            return dtRadiologist;
        }
        public DataTable get_Ris_ExamAll()
        {
            DataTable dtExam = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam(true);
            processExam.Invoke();
            dtExam = processExam.Result.Tables[0].Copy();
            dtExam.TableName = "RIS_EXAMALL";
            return dtExam;
        }
        public DataTable get_Ris_Exam()
        {
            DataTable dtExam = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            processExam.InvokeOnline();
            dtExam = processExam.Result.Tables[0].Copy();
            dtExam.TableName = "RIS_EXAM";
            return dtExam;
        }
        public DataTable get_Exam_Panel()
        {
            DataTable dtExampan = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            dtExampan = processExam.GetExamPanel();
            dtExampan.TableName = "RIS_EXAMPANEL";
            return dtExampan;
        }
        public DataTable get_ExamPortable_Panel(int exam_id)
        {
            DataTable dtExamport = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            dtExamport = processExam.GetExamPanelPortable(exam_id);
            dtExamport.TableName = "RIS_EXAMPANELPORTABLE";
            return dtExamport;
        }
        public DataTable get_ExamPortable_Panel(int exam_id, int clinic_type_id)
        {
            DataTable dtExamport = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            dtExamport = processExam.GetExamPanelPortable(exam_id,clinic_type_id);
            dtExamport.TableName = "RIS_EXAMPANELPORTABLE";
            return dtExamport;
        }
        public DataTable get_Ris_Priority()
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
        public DataTable get_Ris_Modality()
        {
            DataTable dtModality = new DataTable();
            ProcessGetRISModality processModality = new ProcessGetRISModality();
            processModality.Invoke();
            dtModality = processModality.Result.Tables[0].Copy();
            dtModality.TableName = "RIS_MODALITY";
            return dtModality;
        }
        public DataTable get_Ris_ModalityType(bool is_online)
        {
            DataTable dtModalityType = new DataTable();
            ProcessGetRISModalitytype modType = new ProcessGetRISModalitytype(is_online);
            modType.Invoke();
            dtModalityType = modType.Result.Tables[0];
            return dtModalityType;
        }
        public DataTable get_Ris_ModalityExam(int user_id, int value, RIS_MODALITYEXAM_MODE _modalityexam_mode)
        {
            DataTable dtModalityExam = new DataTable();
            ProcessGetRISModalityexam processMath;
            switch (_modalityexam_mode)
            {
                case RIS_MODALITYEXAM_MODE.ALL:
                    processMath = new ProcessGetRISModalityexam(true);
                    processMath.Invoke();
                    dtModalityExam = processMath.Result.Tables[0].Copy();
                    break;
                case RIS_MODALITYEXAM_MODE.BY_MODALITY:
                    processMath = new ProcessGetRISModalityexam(value);
                    processMath.Invoke();
                    dtModalityExam = processMath.Result.Tables[0].Copy();
                    break;
                case RIS_MODALITYEXAM_MODE.BY_USER:
                    processMath = new ProcessGetRISModalityexam(value);
                    dtModalityExam = processMath.rptModalityexam(user_id).Tables[0].Copy();
                    break;
                case RIS_MODALITYEXAM_MODE.EXAM_ID_SDMC:
                    processMath = new ProcessGetRISModalityexam();
                    dtModalityExam = processMath.getModalityFilter(value, 3).Tables[0].Copy();
                    break;
                default:
                    break;
            }

            return dtModalityExam;
        }
        public DataTable get_Ris_ModalityExamTop10(int unit_id, int lengthDay)
        {
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam();
            return process.getModalityExamTop10(unit_id, lengthDay).Tables[0];
        }
        public DataTable get_Ris_ModalityExamFavorite(int emp_id, int modality_id, int org_id)
        {
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(modality_id);
            return process.getModalityExamFavorite(emp_id).Tables[0];
        }
        public DataTable get_Ris_ModalityExamByModalityType(int modality_type,int org_id)
        {
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam();
            return process.getModalityExamByModalityType(modality_type).Tables[0];
        }
        public DataTable get_Ris_InsuranceType(int org_id)
        {
            DataTable dtInsuranceType = new DataTable();
            ProcessGetRISInsurancetype processInsure = new ProcessGetRISInsurancetype(org_id);
            processInsure.Invoke();
            dtInsuranceType = processInsure.Result.Tables[0].Copy();
            dtInsuranceType.TableName = "RIS_INSURANCETYPE";
            return dtInsuranceType;
        }
        public DataTable get_Patient_Status()
        {
             ProcessGetRISPatstatus pat = new ProcessGetRISPatstatus(true);
            pat.Invoke();
            return pat.ResultSet.Tables[0];
        }
        public DataTable get_RIS_ClinicType()
        {
            DataTable dtClinicType = new DataTable();
            ProcessGetRISClinictype processClinic = new ProcessGetRISClinictype();
            processClinic.Invoke();
            dtClinicType = processClinic.Result.Tables[0].Copy();
            dtClinicType.TableName = "RIS_CLINICTYPE";
            return dtClinicType;
        }
        public DataTable get_HR_Emp()
        {
            DataTable dt = new DataTable();
            ProcessGetHREmp hremp = new ProcessGetHREmp();
            hremp.HR_EMP.MODE = HR_EMP.MODE;
            hremp.HR_EMP.EMP_ID = HR_EMP.EMP_ID;
            hremp.HR_EMP.USER_NAME = HR_EMP.USER_NAME;
            hremp.HR_EMP.UNIT_ID = HR_EMP.UNIT_ID;
            hremp.HR_EMP.AUTH_LEVEL_ID = HR_EMP.AUTH_LEVEL_ID;
            hremp.Invoke();
            return hremp.Result.Tables[0];
        }
        public DataTable check_HR_Emp()
        {
            Service proxy = new Service();
            DataTable dt = new DataTable();
            ProcessGetHREmp hremp = new ProcessGetHREmp();
            hremp.HR_EMP.MODE = HR_EMP.MODE;
            hremp.HR_EMP.EMP_UID = HR_EMP.EMP_UID;
            hremp.HR_EMP.USER_NAME = HR_EMP.USER_NAME;
            hremp.HR_EMP.PWD = HR_EMP.PWD;
            hremp.checkUser();
            dt = hremp.Result.Tables[0];

            if (dt.Rows.Count <= 0)
            {
                DataSet dsEmp = proxy.Get_staff_fulldetail(HR_EMP.EMP_UID);
                foreach (DataRow dr in dsEmp.Tables[0].Rows)
                {
//R = Resident
//S = Staff
//X = Extern
//O = Other

                    //switch (dr["role"].ToString())
                    //{
                    //    case "R": break;
                    //    case "S": break;
                    //    case "X": break;
                    //    case "O": break;
                    //}
                    ProcessAddHREmp add = new ProcessAddHREmp(queryString());
                    add.HR_EMP.EMP_UID = HR_EMP.EMP_UID;
                    add.HR_EMP.USER_NAME = HR_EMP.EMP_UID;
                    add.HR_EMP.FNAME = dr["firstname"].ToString();
                    add.HR_EMP.LNAME = dr["lastname"].ToString();
                    add.Invoke();
                }
            }

            return dt;
        }
        private string queryString()
        {
            string query = @"		insert into HR_EMP
			(
				EMP_UID,			USER_NAME,			JOB_TYPE,			IS_RADIOLOGIST,
				FNAME,				LNAME,								
				IS_ACTIVE,			SUPPORT_USER,		CAN_KILL_SESSION,	ORG_ID,				
				CREATED_BY,			CREATED_ON,			LAST_MODIFIED_BY,	LAST_MODIFIED_ON
			)
		values
		(
				@EMP_UID,			@USER_NAME,			'D',				'N',
				@FNAME,				@LNAME,						
				'Y',				'N',				'N',				1,			
				1,					GETDATE(),			1,					GETDATE()
		)";
            return query;
        }
        public DataTable get_HIS_ICD()
        {
            ProcessGetHisICD icd = new ProcessGetHisICD();
            icd.Invoke();
            return icd.Result.Tables[0];
        }
        public DataTable get_GBL_Alert(string UID, int LANGID)
        {
            ProcessGetGlobalAlert gblprocess = new ProcessGetGlobalAlert();
            GBL_ALERT galert = new GBL_ALERT();
            galert.ALT_UID = UID;
            galert.LangID = LANGID;
            gblprocess.GBL_ALERT = galert;
            gblprocess.Invoke();
            return gblprocess.ResultSet.Tables[0];
        }
        public DataTable get_GBL_ENV()
        {
            ProcessGetGBLEnv process = new ProcessGetGBLEnv();
            process.Invoke();
            return process.ResultSet.Tables[0];
        }
        public DataTable get_RIS_PATIENTDESTINATION(int org_id)
        {
            ProcessGetRISPatientdestination pat_dest = new ProcessGetRISPatientdestination();
            pat_dest.Invoke();
            return pat_dest.ResultSet.Tables[0];
        }
        public DataTable get_RIS_AUTHLEVEL()
        {
            ProcessGetRISAuthlevel auth = new ProcessGetRISAuthlevel();
            auth.Invoke();
            return auth.Result.Tables[0];
        }
        public DataSet get_RIS_CLINICALINDICATION(int org_id, int emp_id)
        {
            ProcessGetRISClinicalIndication proc = new ProcessGetRISClinicalIndication();
            proc.RIS_CLINICALINDICATION.ORG_ID = org_id;
            proc.RIS_CLINICALINDICATION.EMP_ID = emp_id;
            proc.Invoke();
            return proc.Result;
        }
        public DataSet get_RIS_CLINICALINDICATIONTYPE(int org_id, int emp_id)
        {
            ProcessGetRISClinicalIndicationType proc = new ProcessGetRISClinicalIndicationType();
            proc.RIS_CLINICALINDICATIONTYPE.ORG_ID = org_id;
            proc.RIS_CLINICALINDICATIONTYPE.EMP_ID = emp_id;
            proc.Invoke();
            return proc.Result;
        }
        public DataTable get_RIS_CLINICALINDICATIONFAVORITE()
        {
            ProcessGetRISClinicalIndicationFavorite select = new ProcessGetRISClinicalIndicationFavorite();
            select.RIS_CLINICALINDICATION.EMP_ID = this.RIS_CLINICALINDICATION.EMP_ID;
            select.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            select.Invoke();
            return select.Result.Tables[0];
        }
        public DataTable get_RIS_CLINICALINDICATIONTYPEFAVORITE()
        {
            ProcessGetRISClinicalIndicationTypeFavorite select = new ProcessGetRISClinicalIndicationTypeFavorite();
            select.RIS_CLINICALINDICATIONTYPE.EMP_ID = this.RIS_CLINICALINDICATIONTYPE.EMP_ID;
            select.RIS_CLINICALINDICATIONTYPE.ORG_ID = this.RIS_CLINICALINDICATIONTYPE.ORG_ID;
            select.Invoke();
            return select.Result.Tables[0];
        }
        public DataTable get_RIS_CLINICALINDICATION_WITH_UNIT(int org_id,int unit_id)
        {
            ProcessGetRISClinicalIndicationWithUnit proc = new ProcessGetRISClinicalIndicationWithUnit();
            proc.RIS_CLINICALINDICATION.ORG_ID = org_id;
            proc.RIS_CLINICALINDICATION.UNIT_ID = unit_id;
            proc.Invoke();
            return proc.Result.Tables[0];
        }
        public DataTable get_PAT_DEST_ID(string ENCOUNTER_TYPE, string ENCOUNTER_CLINIC_TYPE, string ORDERING_DEPT, string EXAM_UNIT)
        {
            ProcessGetRISPatientdestination pt = new ProcessGetRISPatientdestination();
            pt.Invoke();
            DataTable dt = pt.ResultSet.Tables[0];
            DataView dv = new DataView();
            DataTable dtResult = new DataTable();
            DataTable dtTmp = new DataTable();

            dtResult.Columns.Add("PAT_DEST_ID",typeof(int));
            dtResult.Columns.Add("LABEL",typeof(string));
            dtResult.AcceptChanges();
            DataTable dtt = new DataTable();
            dtt.Columns.Add("ENCOUNTER_CLINIC_TYPE");
            dtt.Columns.Add("ENCOUNTER_TYPE");
            dtt.Columns.Add("ORDERING_DEPT");
            dtt.Columns.Add("EXAM_UNIT");
            dtt.AcceptChanges();
            dtt.Rows.Add(
                ENCOUNTER_CLINIC_TYPE.Trim(),
                ENCOUNTER_TYPE.Trim(),
                ORDERING_DEPT.Trim(),
                EXAM_UNIT.Trim()
                );
            bool flag_break = false;
            foreach (DataRow dr in dt.Rows)
            {
                string strFilter = "";
                switch (dr["TYPE"].ToString())
                {
                    case "=":
                        dv = dt.DefaultView;

                        strFilter = "TYPE='='";
                        if (!string.IsNullOrEmpty(dr["ENCOUNTER_TYPE"].ToString()))
                            strFilter += " AND ENCOUNTER_TYPE='" + dtt.Rows[0]["ENCOUNTER_TYPE"].ToString() + "'";
                        if (!string.IsNullOrEmpty(dr["ENCOUNTER_CLINIC_TYPE"].ToString()))
                            strFilter += " AND ENCOUNTER_CLINIC_TYPE='" + dtt.Rows[0]["ENCOUNTER_CLINIC_TYPE"].ToString() + "'";
                        if (!string.IsNullOrEmpty(dr["ORDERING_DEPT"].ToString()))
                            strFilter += " AND ORDERING_DEPT like '%" + dtt.Rows[0]["ORDERING_DEPT"].ToString() + "%'";

                        dv.RowFilter = strFilter;

                        dtTmp = dv.ToTable();
                        if (dtTmp.Rows.Count > 0)
                        {
                            dtResult.Rows.Add(Convert.ToInt32(dtTmp.Rows[0]["PAT_DEST_ID"]), dtTmp.Rows[0]["LABEL"].ToString());
                            flag_break = true;
                        }
                        break;
                    case "!=":
                        dv = dt.DefaultView;
                        strFilter = "TYPE='!='";
                        if (!string.IsNullOrEmpty(dr["ENCOUNTER_TYPE"].ToString()))
                            strFilter += " AND ENCOUNTER_TYPE<>'" + dtt.Rows[0]["ENCOUNTER_TYPE"].ToString() + "'";
                        if (!string.IsNullOrEmpty(dr["ENCOUNTER_CLINIC_TYPE"].ToString()))
                            strFilter += " AND ENCOUNTER_CLINIC_TYPE<>'" + dtt.Rows[0]["ENCOUNTER_CLINIC_TYPE"].ToString() + "'";
                        if (!string.IsNullOrEmpty(dr["ORDERING_DEPT"].ToString()))
                            strFilter += " AND ORDERING_DEPT not like '%" + dtt.Rows[0]["ORDERING_DEPT"].ToString() + "%'";

                        dv.RowFilter = strFilter;

                        dtTmp = dv.ToTable();
                        if (dtTmp.Rows.Count > 0)
                            if (Convert.ToInt32(dr["EXAM_UNIT"]) == Convert.ToInt32(EXAM_UNIT))
                            {
                                dtResult.Rows.Add(Convert.ToInt32(dr["PAT_DEST_ID"]), dr["LABEL"].ToString());
                                flag_break = true;
                            }
                        break;

                }
                if (flag_break)
                    break;
            }
            if (dtResult.Rows.Count == 0)
            {
                dv = dt.DefaultView;
                dv.RowFilter = "EXAM_UNIT="+EXAM_UNIT;
                dtTmp = dv.ToTable();
                if (dtTmp.Rows.Count > 0)
                    dtResult.Rows.Add(Convert.ToInt32(dtTmp.Rows[0]["PAT_DEST_ID"]), dtTmp.Rows[0]["LABEL"].ToString());
                else
                    dtResult.Rows.Add(2, "DIAG");
            }
            return dtResult;
        }
        public DataTable get_ModalityID_With_PatDest(int exam_id,int pat_dest_id)
        {
            ProcessGetRISModalityexam mod_id = new ProcessGetRISModalityexam();
            return mod_id.getModalityIDByPatDestID(exam_id, pat_dest_id).Tables[0];;
            
        }
        public DataTable get_ModalityFilter(bool is_children,int ref_unit_id,int exam_id)
        {


            //if (is_children)
            //{
            //    ProcessGetRISClinicsession mod_id = new ProcessGetRISClinicsession();
            //    return mod_id.getSessionTimeChildren(ref_unit_id);
            //}
            //else
            //{
                ProcessGetRISClinicsession mod_id = new ProcessGetRISClinicsession();
                return mod_id.getSessionTimeWithUnit(ref_unit_id,exam_id,is_children?'Y':'N');
            //}
        }
        public DataTable get_RIS_ORDERCLINICALINDICATION(int order_id,int schedule_id)
        {
            ProcessGetRISOrderClinicalIndication data = new ProcessGetRISOrderClinicalIndication();
            data.RIS_ORDERCLINICALINDICATION.ORDER_ID = order_id;
            data.RIS_ORDERCLINICALINDICATION.SCHEDULE_ID = schedule_id;
            data.Invoke();
            return data.ResultSet.Tables[0];
        }
        public DataTable get_RIS_ORDERCLINICALINDICATIONTYPE(int order_id, int schedule_id)
        {
            ProcessGetRISOrderClinicalIndicationType data = new ProcessGetRISOrderClinicalIndicationType();
            data.RIS_ORDERCLINICALINDICATIONTYPE.ORDER_ID = order_id;
            data.RIS_ORDERCLINICALINDICATIONTYPE.SCHEDULE_ID = schedule_id;
            data.Invoke();
            return data.ResultSet.Tables[0];
        }
        public DataTable get_CLINICSESSION_TYPE()
        {
            ProcessGetONLClinicsession session = new ProcessGetONLClinicsession();
            session.Invoke();
            return session.Result.Tables[0];
        }
        public DataTable get_ONL_SearchMatch()
        {
            ProcessGetONLSearchMatch prc = new ProcessGetONLSearchMatch();
            prc.Invoke();
            return prc.Result.Tables[0];
        }
        
        public int get_CIID_ClinicalIndication(string strFullPath)
        {
            ProcessGetRISClinicalIndication indication = new ProcessGetRISClinicalIndication();
            string[] splFullPath = strFullPath.Split('/');
            int ciid = 0;
            if (splFullPath.Length > 1)
            {
                ciid = indication.get_CI_ID(splFullPath);
            }
            else
                ciid = indication.get_CI_ID(splFullPath[0], "", "Single");

            return ciid;
        }
        public int get_CITypeID_ClinicalIndicationType(string strFullPath)
        {
            string[] splFullPath = strFullPath.Split('/');
            int ciid = 0;
            ProcessGetRISClinicalIndicationType indication = new ProcessGetRISClinicalIndicationType();
            if (splFullPath.Length > 1)
            {
                int i = splFullPath.Length - 1;
                ciid = indication.get_CI_TYPE_ID(splFullPath[i], splFullPath[i - 1], "Multi");
            }
            else
                ciid = indication.get_CI_TYPE_ID(splFullPath[0], "", "Single");
            return ciid;
        }
        
        public enum RIS_MODALITYEXAM_MODE { ALL, BY_MODALITY, BY_USER, EXAM_ID_SDMC }

        public bool set_Ris_ExamFavorite_Insert()
        {
            ProcessAddRISExamFavorite _insert = new ProcessAddRISExamFavorite();
            _insert.RIS_EXAMFAVORITE.CREATED_BY = this.RIS_EXAMFAVORITE.CREATED_BY;
            _insert.RIS_EXAMFAVORITE.EMP_ID = this.RIS_EXAMFAVORITE.EMP_ID;
            _insert.RIS_EXAMFAVORITE.EXAM_ID = this.RIS_EXAMFAVORITE.EXAM_ID;
            _insert.RIS_EXAMFAVORITE.LAST_MODIFIED_BY = this.RIS_EXAMFAVORITE.LAST_MODIFIED_BY;
            _insert.RIS_EXAMFAVORITE.ORG_ID = this.RIS_EXAMFAVORITE.ORG_ID;
            _insert.RIS_EXAMFAVORITE.SL_NO = this.RIS_EXAMFAVORITE.SL_NO;
            _insert.Invoke();
            return true;
        }
        public bool set_Ris_ExamFavorite_Update()
        {
            ProcessUpdateRISExamFavorite _update = new ProcessUpdateRISExamFavorite();
            _update.RIS_EXAMFAVORITE.EMP_ID = this.RIS_EXAMFAVORITE.EMP_ID;
            _update.RIS_EXAMFAVORITE.EXAM_ID = this.RIS_EXAMFAVORITE.EXAM_ID;
            _update.RIS_EXAMFAVORITE.SL_NO = this.RIS_EXAMFAVORITE.SL_NO;
            _update.Invoke();
            return true;
        }
        public bool set_Ris_ExamFavorite_Delete()
        {
            ProcessDeleteRISExamFavorite _delete = new ProcessDeleteRISExamFavorite();
            _delete.RIS_EXAMFAVORITE.CREATED_BY = this.RIS_EXAMFAVORITE.CREATED_BY;
            _delete.RIS_EXAMFAVORITE.EMP_ID = this.RIS_EXAMFAVORITE.EMP_ID;
            _delete.RIS_EXAMFAVORITE.EXAM_ID = this.RIS_EXAMFAVORITE.EXAM_ID;
            _delete.RIS_EXAMFAVORITE.LAST_MODIFIED_BY = this.RIS_EXAMFAVORITE.LAST_MODIFIED_BY;
            _delete.RIS_EXAMFAVORITE.ORG_ID = this.RIS_EXAMFAVORITE.ORG_ID;
            _delete.RIS_EXAMFAVORITE.SL_NO = this.RIS_EXAMFAVORITE.SL_NO;
            _delete.Invoke();
            return true;
        }
        public bool set_RIS_CLINICALINDICATIONFAVORITE_Insert()
        {
            ProcessAddRISClinicalIndicationFavorite add = new ProcessAddRISClinicalIndicationFavorite();
            add.RIS_CLINICALINDICATION.CI_ID = this.RIS_CLINICALINDICATION.CI_ID;
            add.RIS_CLINICALINDICATION.EMP_ID = this.RIS_CLINICALINDICATION.EMP_ID;
            add.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            add.RIS_CLINICALINDICATION.CREATED_BY = this.RIS_CLINICALINDICATION.CREATED_BY;
            add.Invoke();
            return true;

        }
        public bool set_RIS_CLINICALINDICATIONFAVORITE_Delete()
        {
            ProcessDeleteRISClinicalIndicationFavorite del = new ProcessDeleteRISClinicalIndicationFavorite();
            del.RIS_CLINICALINDICATION.CI_ID = this.RIS_CLINICALINDICATION.CI_ID;
            del.RIS_CLINICALINDICATION.EMP_ID = this.RIS_CLINICALINDICATION.EMP_ID;
            del.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            del.Invoke();
            return true;

        }
        public bool set_RIS_CLINICALINDICATIONTYPEFAVORITE_Insert()
        {
            ProcessAddRISClinicalIndicationTypeFavorite add = new ProcessAddRISClinicalIndicationTypeFavorite();
            add.RIS_CLINICALINDICATIONTYPE.EMP_ID = this.RIS_CLINICALINDICATIONTYPE.EMP_ID;
            add.RIS_CLINICALINDICATIONTYPE.ORG_ID = this.RIS_CLINICALINDICATIONTYPE.ORG_ID;
            add.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID = this.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID;
            add.RIS_CLINICALINDICATIONTYPE.CREATED_BY = this.RIS_CLINICALINDICATIONTYPE.CREATED_BY;
            add.Invoke();
            return true;

        }
        public bool set_RIS_CLINICALINDICATIONTYPEFAVORITE_Delete()
        {
            ProcessDeleteRISClinicalIndicationTypeFavorite del = new ProcessDeleteRISClinicalIndicationTypeFavorite();
            del.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID = this.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID;
            del.RIS_CLINICALINDICATIONTYPE.EMP_ID = this.RIS_CLINICALINDICATIONTYPE.EMP_ID;
            del.RIS_CLINICALINDICATIONTYPE.ORG_ID = this.RIS_CLINICALINDICATIONTYPE.ORG_ID;
            del.Invoke();
            return true;

        }
        public bool set_RIS_CLINICALINDICATIONWITHUNIT_Insert()
        {
            ProcessAddRISClinicalIndicationWithUnit add = new ProcessAddRISClinicalIndicationWithUnit();
            add.RIS_CLINICALINDICATION.CI_ID = this.RIS_CLINICALINDICATION.CI_ID;
            add.RIS_CLINICALINDICATION.UNIT_ID = this.RIS_CLINICALINDICATION.UNIT_ID;
            add.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            add.RIS_CLINICALINDICATION.CREATED_BY = this.RIS_CLINICALINDICATION.CREATED_BY;
            add.Invoke();
            return true;
        }
        public bool set_RIS_CLINICALINDICATIONWITHUNIT_Delete()
        {
            ProcessDeleteRISClinicalIndicationWithUnit del = new ProcessDeleteRISClinicalIndicationWithUnit();
            del.RIS_CLINICALINDICATION.CI_ID = this.RIS_CLINICALINDICATION.CI_ID;
            del.RIS_CLINICALINDICATION.UNIT_ID = this.RIS_CLINICALINDICATION.UNIT_ID;
            del.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            del.Invoke();
            return true;

        }
        public bool set_RIS_CLINICALINDICATIONWITHUNIT_DeleteAll()
        {
            ProcessDeleteRISClinicalIndicationWithUnit del = new ProcessDeleteRISClinicalIndicationWithUnit();
            del.RIS_CLINICALINDICATION.UNIT_ID = this.RIS_CLINICALINDICATION.UNIT_ID;
            del.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            del.DeleteAll();
            return true;

        }
        public void set_RIS_CLINICALINDICATION_Delete()
        {
            ProcessDeleteRISClinicalIndication del = new ProcessDeleteRISClinicalIndication();
            del.RIS_CLINICALINDICATION.CI_ID = this.RIS_CLINICALINDICATION.CI_ID;
            del.RIS_CLINICALINDICATION.EMP_ID = this.RIS_CLINICALINDICATION.EMP_ID;
            del.RIS_CLINICALINDICATION.ORG_ID = this.RIS_CLINICALINDICATION.ORG_ID;
            del.Invoke();
        }
        public void set_RIS_CLINICALINDICATIONTYPE_Delete()
        {
            ProcessDeleteRISClinicalIndicationType del = new ProcessDeleteRISClinicalIndicationType();
            del.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID = this.RIS_CLINICALINDICATIONTYPE.CI_TYPE_ID;
            del.RIS_CLINICALINDICATIONTYPE.EMP_ID = this.RIS_CLINICALINDICATIONTYPE.EMP_ID;
            del.RIS_CLINICALINDICATIONTYPE.ORG_ID = this.RIS_CLINICALINDICATIONTYPE.ORG_ID;
            del.Invoke();
        }
    }
}
