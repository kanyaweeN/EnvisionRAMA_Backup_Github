using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class _LookUpSelect : DataAccessBase
    {
        DataSet ds;
        public _LookUpSelect()
        {

        }
        public DataSet SelectExamREQ(string HN)
        {
            ParameterList = buildParameterSelectExamREQ(HN);
            StoredProcedureName = StoredProcedure.Prc_LookUp_XRAYREQ_SelectByHN;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectAGE(DateTime date)
        {
            
            ParameterList = buildParameterAGE(date);
            StoredProcedureName = StoredProcedure.Prc_LookUp_Age_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadiologistConfig(int id)
        {
            ParameterList = buildParameterRadiologistConfig(id);
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadiologistConfig_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet ScheduleNotParameter(string selectcase)
        {
            ParameterList = buildParameterNotParam(selectcase);
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Lookup;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet ScheduleHaveParameter(string selectcase, int id)
        {
            ParameterList = buildParameterHaveParam(selectcase, id);
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Lookup;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectOrderFrom(string selectcase)
        {
            ParameterList = buildParameterOrderForm(selectcase);
            StoredProcedureName = StoredProcedure.Prc_LookUp_OrderForm_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectOPNoteExam(int reg_id)
        {
            ParameterList = buildParameterOpnoteExam(reg_id);
            StoredProcedureName = StoredProcedure.Prc_LookUp_ExamOPNote_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectOPNoteHN(string HN)
        {
            ParameterList = buildParameterHN(HN);
            StoredProcedureName = StoredProcedure.Prc_LookUp_OPNoteHN_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRIS_RADSTUDYGROUP(int RADIOLOGIST_ID, string ACCESSION_NO, bool IS_FAVOURITE, bool IS_TEACHING,bool IS_OTHERS,string Type)
        {
            ParameterList = buildParameterRadStudyGroup(RADIOLOGIST_ID, ACCESSION_NO, IS_FAVOURITE, IS_TEACHING, IS_OTHERS, Type);
            StoredProcedureName = StoredProcedure.Prc_LookUp_RIS_RADSTUDYGROUP_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectExamResultLock(string AccessionNO,int UserID)
        {
            ParameterList = buildParameterAccession(AccessionNO, UserID);
            StoredProcedureName = StoredProcedure.Prc_LookUp_ResultLock_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectClinicSession()
        {
            RISClinicsessionSelectData proc = new RISClinicsessionSelectData();
            return proc.GetData();
        }
        public DataSet SelectHeaderReport()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_HeaderReport_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSumaryReport(int id, DateTime FromDate, DateTime ToDate, string Header)
        {
            ds = new DataSet();
            ParameterList = buildParameterSummary(FromDate, ToDate, Header);
            switch (id)
            {
                case 1:
                case 2:
                case 3:
                    StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_Order;
                    break;
                case 4:
                    StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_Schedule;
                    break;
                case 5:
                    StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_ResultSpecialClinic;
                    break;
                case 6:
                    StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_Order;
                    break;
                case 7:
                    StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_ScheduleByModality;
                    break;
                default:
                    break;
            }
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSummaryDF(DateTime FromDate, DateTime ToDate,int EmpID)
        {
            ds = new DataSet();
            ParameterList = buildParameterSummaryDF(FromDate, ToDate, EmpID);
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_Rate;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSummaryDFAIMC(DateTime FromDate,DateTime ToDate,int EmpID,int Unit)
        {
            ds = new DataSet();
            ParameterList = buildParameterSummaryDFAIMC(FromDate, ToDate, EmpID,Unit);
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByAIMC;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectExamConsumable()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_ExamConsumable_Select;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectWorkloadReport(DateTime FromDate, DateTime ToDate, int UserID, string JobType)
        {
            ds = new DataSet();
            ParameterList = buildParameterWorkLoad(FromDate, ToDate, UserID, JobType);
            StoredProcedureName = StoredProcedure.Prc_RIS_RptWorkload;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectPRforPO()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_INV_PR_SelectForPO;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectExamSaveTemp()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_Result_Select;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectrptInvStock(int invUnitID, DateTime FromDate, DateTime ToDate)
        {
            ds = new DataSet();
            ParameterList = buildParameterRptInvStock(invUnitID,FromDate,ToDate);
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_InvStock;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet updateJohnDoeCase(int selectcase,string hn,int reg_id,int reg_idj)
        {
            ds = new DataSet();
            ParameterList = buildParameterJohnDoe(selectcase, hn, reg_id, reg_idj);
            StoredProcedureName = StoredProcedure.Prc_LookUp_JohnDoeCase_Update;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectEditOrder(string HN)
        {
            ParameterList = buildParameterSelectEditOrder(HN);
            StoredProcedureName = StoredProcedure.Prc_LookUp_EditOrder_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet PR_Report(int id)
        {
            ParameterList = buildParameterPRReport(id);
            StoredProcedureName = StoredProcedure.Prc_RIS_rptPR;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet PO_Report(int id)
        {
            ParameterList = buildParameterPOReport(id);
            StoredProcedureName = StoredProcedure.Prc_RIS_rptPO;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectPatientFlowReport(DateTime FromDate, DateTime ToDate)
        {
            ParameterList = buildParameterPatientFlowReport(FromDate, ToDate);
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_PATIENT_FLOW;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectClinicalData(string HN)
        {
            ParameterList = buildParameterClinicalData(HN);
            StoredProcedureName = StoredProcedure.Prc_LookUp_ClinicalData_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetBillingMessage(string ACCESSION_NO)
        {
            ParameterList = buildParameterGetBillingMessage(ACCESSION_NO);
            StoredProcedureName = StoredProcedure.Prc_RIS_BillingGenMessageMulti;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectReasonReject(int LangID)
        {
            ParameterList = buildParameteReasonReject(LangID);
            StoredProcedureName = StoredProcedure.Prc_LookUp_ResultReject_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectHrJobtitle()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_JOBTITLE_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectReleaseCombobox(string combobox)
        {
            ParameterList = buildParameterReleaseCombobox(combobox);
            StoredProcedureName = StoredProcedure.Prc_LookUp_ReleaseCombox_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRptAIMCSummaryPayment(DateTime FromDate, DateTime ToDate)
        {
            ParameterList = new DbParameter[] { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                       };

            StoredProcedureName = StoredProcedure.Prc_RIS_RPT_SummaryPaymentAIMC_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRptSummaryPatientAppointment(DateTime FromDate, DateTime ToDate)
        {
            ParameterList = new DbParameter[] { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                       };     

            StoredProcedureName = StoredProcedure.Prc_RIS_RPT_SummaryPatientAppointment_Select;
            ds = new DataSet();               
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRptAIMCFinancialInvoice(int ORDER_ID)
        {
            ParameterList = new DbParameter[] { 
                                          Parameter("@ORDER_ID",ORDER_ID),
                                       };

            StoredProcedureName = StoredProcedure.Prc_RIS_RPT_AIMCFinancialInvoice_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSummaryDFTech(DateTime FromDate, DateTime ToDate, int EmpID)
        {
            //ds = new DataSet();
            //SqlParameter[] Parameters =
            //{
            //    new SqlParameter("@FromDate", FromDate)
            //    ,new SqlParameter("@ToDate", ToDate)
            //    ,new SqlParameter("@EMP_ID", EmpID)
            //};

            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_DF_RateByTech.ToString());
            //ds = dbhelper.Run(base.ConnectionString, Parameters);
            //return ds;

            ParameterList = new DbParameter[] { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@EMP_ID",EmpID),
                                       };

            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByTech;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectAIMCFinancialInvoiceFrom(string HN)
        {
            ParameterList = new DbParameter[] { Parameter("@HN", HN) };
            StoredProcedureName = StoredProcedure.Prc_LookUp_AIMCInvoiceForm_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectACAcademicReport(DateTime DateFrom, DateTime DateTo, int RadID, string Mode)
        {
            ParameterList = new DbParameter[] 
            { 
                    Parameter("@DateFrom", DateFrom) 
                    ,Parameter("@DateTo", DateTo) 
                    ,Parameter("@RadID", RadID) 
                    ,Parameter("@Mode", Mode) 
            };
            StoredProcedureName = StoredProcedure.Prc_AC_SUMMARY_ACADEMIC_REPORTING;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectACBodySystemReport(DateTime DateFrom, DateTime DateTo, int RadID, string Mode)
        {
            ParameterList = new DbParameter[] 
            { 
                    Parameter("@DateFrom", DateFrom) 
                    ,Parameter("@DateTo", DateTo) 
                    ,Parameter("@RadID", RadID) 
                    ,Parameter("@Mode", Mode) 
            };
            StoredProcedureName = StoredProcedure.Prc_AC_SUMMARY_BODYSYSTEM_REPORTING;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSummaryDFRadPremium(DateTime FromDate, DateTime ToDate, int EmpID, int clinic_id, int modality_id)
        {
            ParameterList = new DbParameter[] { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@EMP_ID",EmpID),
                                          Parameter("@CLINICAL_TYPE_ID",clinic_id),
                                          Parameter("@MODALITY_ID",modality_id),
                                       };

            //StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByRad_Premium;
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByRad_Premium2; 
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSummaryDFNuero(DateTime FromDate, DateTime ToDate, int EmpID, int clinic_id, int modality_id)
        {
            ParameterList = new DbParameter[] { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@EMP_ID",EmpID),
                                          Parameter("@CLINICAL_TYPE_ID",clinic_id),
                                          Parameter("@MODALITY_ID",modality_id),
                                       };

            //StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByRad_Premium;
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_Nuero;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectSummaryDFTechPremium(DateTime FromDate, DateTime ToDate, int EmpID, int clinic_id, int modality_id)
        {
            ParameterList = new DbParameter[] { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@EMP_ID",EmpID),
                                          Parameter("@CLINICAL_TYPE_ID",clinic_id),
                                          Parameter("@MODALITY_ID",modality_id),
                                       };

            //StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByTech_Premium;
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Summary_DF_RateByTech_Premium2;  
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectExamConsultCase()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_ExamConsultCase_Select;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectACR_CPT_ICD()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_ACR_CPT_ICD_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectRadStudyManagementTags(int RADIOLOGIST_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementTags_Select;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@RADIOLOGIST_ID",RADIOLOGIST_ID),
            };
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadStudyManagementBodyPart()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementBodyPart_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadStudyManagementCPT()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementCPT_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadStudyManagementICD()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementICD_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectReportChangeStatus(DateTime FromDate, DateTime ToDate)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RPT_RESULTSTATUSCHANGELOG;

            ds = new DataSet();
            ParameterList = buildParameterReportChangeStatus(FromDate, ToDate);
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectReportER(DateTime FromDate, DateTime ToDate)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_ReportER;

            ds = new DataSet();
            ParameterList = buildParameterReportER(FromDate, ToDate);
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadStudyManagementShareWith()
        {
            ParameterList = new DbParameter[] 
            { 
                Parameter("@EMP_ID",new GBLEnvVariable().UserID),
            };
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementShareWith_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadStudyManagementACR()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementACR_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadStudyManagementConference()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadStudyManagementConference_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectMultipleAssignmentRad()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_MultipleAssignmentRad_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectMultipleAssignmentNurse()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_MultipleAssignmentNurse_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectMultipleAssignmentTech()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_MultipleAssignmentTech_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectMammogramSummary(DateTime DateFrom, DateTime DateTo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_Mammogram_Summary;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectPatientDestination(string AccessionNo)
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_PatientDestination_Select;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@ACCESSION_NO",AccessionNo),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectOlapOrder(DateTime DateFrom, DateTime DateTo)
        {
            StoredProcedureName = StoredProcedure.Prc_OLAPV_ORDER_Select;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectStudiesWorkloadbyModality(string SelectMode, DateTime DateFrom, DateTime DateTo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_ModalityWorkload_Select;

            ParameterList = new DbParameter[]
            { 
                Parameter("@SelectMode",SelectMode),
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRadiologistWorkload(DateTime DateFrom, DateTime DateTo, int EMP_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_RadiologistWorkload;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@FromDate",DateFrom),
                Parameter("@ToDate",DateTo),
                Parameter("@EMP_ID",EMP_ID),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectDatetimeNowFromSQLServer()
        {
            StoredProcedureName = StoredProcedure.Prc_LookUp_SelectDatetimeNowFromSQLServer;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectSummaryDFRadWithModalityUnitID(DateTime DateFrom, DateTime DateTo, int EMP_ID, int UNIT_ID)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_SummaryDFRad_WithModalityUnitID;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@FromDate",DateFrom),
                Parameter("@ToDate",DateTo),
                Parameter("@EMP_ID",EMP_ID),
                Parameter("@UNIT_ID",UNIT_ID),
            };

            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectTATCombobox()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_ComboboxTATReport;
            ds = ExecuteDataSetReportSearch();
            return ds;
        }
        public DataSet SelectTATReport(DateTime DateFrom, DateTime DateTo,int value)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_TATReport;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
                Parameter("@GEN_DTL_ID",value),
            };

            ds = ExecuteDataSetReportSearch();
            return ds;
        }
        public DataSet SelectFeedBackReport(DateTime DateFrom, DateTime DateTo)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_FeedBackReport;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
            };

            ds = ExecuteDataSetReportSearch();
            return ds;
        }
        
        public DataSet SelectRadiologistWorkloadER(string MODE, DateTime DateFrom, DateTime DateTo, string strEmpID)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_RadiologistWorkload_ER;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@MODE",MODE),
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
                Parameter("@strEmpID",strEmpID),
            };

            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectAcFinalizePrivilegeCanUserFinalize(int EMP_ID, int EXAM_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_AC_FINALIZEPRIVILEGE_CanUserFinalize;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@EMP_ID",EMP_ID),
                Parameter("@EXAM_ID",EXAM_ID),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectGBLGetCurrentDatetime()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_GetCurrentDatetime;

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectGBLGetReportDataTimeForSynapse(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_GetReportDataTimeForSynapse;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@ACCESSION_NO",ACCESSION_NO),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectGBLGeneral(int GEN_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_GENERAL_Select;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@GEN_ID",GEN_ID),
            };

            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectSummaryDFRadAIMC(int Mode,DateTime DateFrom, DateTime DateTo)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_SummaryDFAIMC;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@MODE",Mode),
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
            };

            ds = ExecuteDataSetReportSearch();
            return ds;
        }
        public DataSet SelectDateStatisticMode()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_DateStatisticMode_Select;
            ds = ExecuteDataSetReportSearch();
            return ds;
        }
        public DataSet SelectDateStatistic(int Mode, DateTime FromDate, DateTime ToDate)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_DateStatistic_Select;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@MODE",Mode),
                Parameter("@DATE_FROM",FromDate),
                Parameter("@DATE_TO",ToDate),
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public string GetAIImageLink(int mode,string Accession)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_AIImageLink_SelectMulti;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@MODE",mode),
                Parameter("@ACCESSION_NO",Accession),
            };
            ds = ExecuteDataSet();
            
            return ds.Tables[0].Rows[0]["AI_IMAGELINK"].ToString();
        }
        private DbParameter[] buildParameterReleaseCombobox(string combobox)
        {
            DbParameter[] parameters = { 
                                          Parameter("@combobox",combobox)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPatientFlowReport(DateTime FromDate, DateTime ToDate)
        {
            DbParameter[] parameters = { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPRReport(int id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@PR_ID",id)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterPOReport(int id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@PO_ID",id)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterRptInvStock(int invUnitID,DateTime FromDate,DateTime ToDate)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UNIT_ID",invUnitID),
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterJohnDoe(int SELECTCASE,string HN,int REG_ID,int REG_IDJ)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN),
                                          Parameter("@REG_ID",REG_ID),
                                          Parameter("@REG_IDJ",REG_IDJ),
                                          Parameter("@SELECTCASE",SELECTCASE),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterSelectExamREQ(string HN)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterAGE(DateTime date)
        {
            DbParameter[] parameters = { 
                                          Parameter("@Datetime",date),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterRadiologistConfig(int id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@RADIOLOGIST_ID",id),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterNotParam(string selectcase)
        {
            DbParameter[] parameters = { 
                                          Parameter("@selectcase",selectcase),
                                          Parameter("@parameter",0),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterHaveParam(string selectcase,int id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@selectcase",selectcase),
                                          Parameter("@parameter",id),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterOrderForm(string selectcase)
        {
            DbParameter[] parameters = { 
                                          Parameter("@selectcase",selectcase),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterOpnoteExam(int id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@REG_ID",id),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterHN(string HN)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterRadStudyGroup(int RADIOLOGIST_ID, string ACCESSION_NO, bool IS_FAVOURITE, bool IS_TEACHING, bool IS_OTHERS, string Type)
        {
            DbParameter[] parameters = { 
                                          Parameter("@RADIOLOGIST_ID", RADIOLOGIST_ID)
                                         ,Parameter("@ACCESSION_NO", ACCESSION_NO)
                                         ,Parameter("@IS_FAVOURITE", IS_FAVOURITE)
                                         ,Parameter("@IS_TEACHING", IS_TEACHING)
                                         ,Parameter("@IS_OTHERS", IS_OTHERS)
                                         ,Parameter("@Type", Type)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterAccession(string ACCESSION_NO, int USER_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",ACCESSION_NO),
                                          Parameter("@USER_ID",USER_ID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterSummary(DateTime FromDate, DateTime ToDate, string Header)
        {
            DbParameter[] parameters = { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@ReportHeader",Header),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterSummaryDF(DateTime FromDate, DateTime ToDate, int EMP_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@EMP_ID",EMP_ID),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterSummaryDFAIMC(DateTime FromDate, DateTime ToDate, int EMP_ID,int Unit)
        {
            DbParameter[] parameters = { 
                                          Parameter("@FromDate",FromDate),
                                          Parameter("@ToDate",ToDate),
                                          Parameter("@EMP_ID",EMP_ID),
                                           Parameter("@UNIT",Unit),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterWorkLoad(DateTime FromDate, DateTime ToDate, int UserID, string JobType)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UserID"   ,UserID),
                                          Parameter("@FromDate" ,FromDate),
                                          Parameter("@ToDate"   ,ToDate),
                                          Parameter("@JobType"  ,JobType ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterSelectEditOrder(string HN)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterClinicalData(string HN)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN",HN)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterGetBillingMessage(string ACCESSION_NO)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",ACCESSION_NO)
                                          ,Parameter("@CREATED_BY",new GBLEnvVariable().UserName)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameteReasonReject(int _langID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@LANG_ID",_langID)
                                       };
            return parameters;
        }
        public DataSet SelectRadiologistWorkloadAIMC(DateTime DateFrom, DateTime DateTo)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_RadiologistWorkload_AIMC;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@DateFrom",DateFrom),
                Parameter("@DateTo",DateTo),
            };

            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet SelectContrastManagement(int Mode, DateTime FromDate, DateTime ToDate, string Hn)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_ContrastManagement_Select;

            ParameterList = new DbParameter[] 
            { 
                Parameter("@MODE",Mode),
                Parameter("@DATE_FROM",FromDate),
                Parameter("@DATE_TO",ToDate),
                Parameter("@HN",Hn),
            };

            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectContrastLot(int contrastId)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_ContrastLot_Select;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@CONTRAST_ID",contrastId),
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectOrderIdByAccession(string accessionNo) {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_OrderIdByAccession_Select;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@ACCESSION_NO",accessionNo),
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRegIdByScheduleId(int scheduleId)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_RegIdByScheduleId_Select;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@SCHEDULE_ID",scheduleId),
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectRptFindingAll()
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_LookUp_RptFindingAll_Select;
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterReportChangeStatus(DateTime FromDate, DateTime ToDate)
        {
            DbParameter[] parameters = { 
                                          Parameter("@dateBegin",FromDate),
                                          Parameter("@dateEnd",ToDate)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterReportER(DateTime FromDate, DateTime ToDate)
        {
            DbParameter[] parameters = { 
                                          Parameter("@dateBegin",FromDate),
                                          Parameter("@dateEnd",ToDate)
                                       };
            return parameters;
        }
    }
}
