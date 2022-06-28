using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessRead;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic
{
    public class LookUpSelect
    {
        public LookUpSelect()
        {

        }
        public DataSet SelectAGE(DateTime date)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectAGE(date);
        }
        public DataSet SelectRadiologistConfig(int RadiologistID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadiologistConfig(RadiologistID);
        }
        public DataSet ScheduleNotParameter(string selectcase)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.ScheduleNotParameter(selectcase);
        }
        public DataSet ScheduleHaveParameter(string selectcase, int id)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.ScheduleHaveParameter(selectcase, id);
        }
        public DataSet SelectOrderFrom(string selectcase)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectOrderFrom(selectcase);
        }
        public DataSet SelectOPNoteHN(string HN)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectOPNoteHN(HN);
        }
        public DataSet SelectOPNoteExam(int reg_id)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectOPNoteExam(reg_id);
        }
        public DataSet SelectRIS_RADSTUDYGROUP(int RADIOLOGIST_ID, string ACCESSION_NO, bool IS_FAVOURITE, bool IS_TEACHING, bool IS_OTHERS,string Type)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRIS_RADSTUDYGROUP(RADIOLOGIST_ID, ACCESSION_NO, IS_FAVOURITE, IS_TEACHING, IS_OTHERS, Type);
        }
        public DataSet SelectExamResultLock(string AccessionNO, int UserID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectExamResultLock(AccessionNO, UserID);
        }
        public DataSet SelectSession()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectClinicSession();
        }
        public DataSet SelectHeaderReport()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectHeaderReport();
        }
        public DataSet SelectSumarryReport(int id, DateTime FromDate, DateTime ToDate, string Header)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSumaryReport(id, FromDate, ToDate, Header);
        }
        public DataSet SelectSumarryDF(DateTime FromDate, DateTime ToDate, int EmpID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDF(FromDate, ToDate, EmpID);
        }
        public DataSet SelectSummaryDFAIMC(DateTime FromDate,DateTime ToDate,int EmpID,int UNIT)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFAIMC(FromDate, ToDate, EmpID, UNIT);
        }
        public DataSet SelectWorkloadReport(DateTime FromDate,DateTime ToDate,int UserID,string JobType)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectWorkloadReport(FromDate, ToDate, UserID, JobType);

        }
        public DataSet SelectExamConsumable()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectExamConsumable();
        }
        public DataSet SelectPRforPO()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectPRforPO();
        }
        public DataSet SelectExamSaveTemp()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectExamSaveTemp();
        }
        public DataSet SelectExamREQ(string HN)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectExamREQ(HN);
        }
        public DataSet SelectrptInvStock(int invUnitID, DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectrptInvStock(invUnitID,FromDate,ToDate);
        }
        public DataSet updateJohnDoeCase(int SELECTCASE,string HN,int REG_ID,int REG_IDJ)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.updateJohnDoeCase(SELECTCASE, HN, REG_ID, REG_IDJ);
        }
        public DataSet SelectEditOrder(string HN)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectEditOrder(HN);
        }
        public DataSet PR_Report(int PR_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.PR_Report(PR_ID);
        }
        public DataSet PO_Report(int PO_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.PO_Report(PO_ID);
        }
        public DataSet SelectPatientFlow(DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectPatientFlowReport(FromDate, ToDate);
        }
        public DataSet SelectClinicalData(string HN)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectClinicalData(HN);
        }
        public DataSet GetBillingMessage(string ACCESSION_NO)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.GetBillingMessage(ACCESSION_NO);
        }
        public DataSet SelectReasonReject(int LANG_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectReasonReject(LANG_ID);
        }
        public DataSet SelectHrJobtitle()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectHrJobtitle();
        }
        public DataSet SelectReleaseCombobox(string combobox)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectReleaseCombobox(combobox);
        }
        public DataSet SelectRptAIMCSummaryPayment(DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRptAIMCSummaryPayment(FromDate, ToDate);
        }
        public DataSet SelectRptSummaryPatientAppointment(DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRptSummaryPatientAppointment(FromDate, ToDate);
        }
        public DataSet SelectRptAIMCFinancialInvoice(int ORDER_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRptAIMCFinancialInvoice(ORDER_ID);
        }
        public DataSet SelectSumarryDFTech(DateTime FromDate, DateTime ToDate, int EmpID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFTech(FromDate, ToDate, EmpID);
        }
        public DataSet SelectAIMCFinancialInvoiceFrom(string HN)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectAIMCFinancialInvoiceFrom(HN);
        }

        public DataSet SelectACAcademicReport(DateTime FromDate, DateTime ToDate, int EmpID, string Mode)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectACAcademicReport(FromDate, ToDate, EmpID, Mode);
        }
        public DataSet SelectACBodySystemReport(DateTime FromDate, DateTime ToDate, int EmpID, string Mode)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectACBodySystemReport(FromDate, ToDate, EmpID, Mode);
        }
        public DataSet SelectSummaryDFRadPremium(DateTime FromDate, DateTime ToDate, int EmpID, int clinic_id, int modality_id)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFRadPremium(FromDate, ToDate, EmpID,clinic_id, modality_id);
        }
        public DataSet SelectSummaryDFNuero(DateTime FromDate, DateTime ToDate, int EmpID, int clinic_id, int modality_id)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFNuero(FromDate, ToDate, EmpID, clinic_id, modality_id);
        }
        public DataSet SelectSummaryDFTechPremium(DateTime FromDate, DateTime ToDate, int EmpID, int clinic_id, int modality_id)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFTechPremium(FromDate, ToDate, EmpID, clinic_id, modality_id);
        }
        public DataSet SelectExamConsultCase()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectExamConsultCase();
        }
        public DataSet SelectACR_CPT_ICD()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectACR_CPT_ICD();
        }

        public DataSet SelectRadStudyManagementTags(int RADIOLOGIST_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementTags(RADIOLOGIST_ID);
        }
        public DataSet SelectRadStudyManagementBodyPart()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementBodyPart();
        }
        public DataSet SelectRadStudyManagementCPT()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementCPT();
        }
        public DataSet SelectRadStudyManagementICD()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementICD();
        }
        public DataSet SelectRadStudyManagementACR()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementACR();
        }
        public DataSet SelectRadStudyManagementConference()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementConference();
        }
        public DataSet SelectRadStudyManagementShareWith()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadStudyManagementShareWith();
        }

        public DataSet SelectMultipleAssignmentRad()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectMultipleAssignmentRad();
        }
        public DataSet SelectMultipleAssignmentNurse()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectMultipleAssignmentNurse();
        }
        public DataSet SelectMultipleAssignmentTech()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectMultipleAssignmentTech();
        }

        public DataSet SelectMammogramSummary(DateTime DateFrom, DateTime DateTo)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectMammogramSummary(DateFrom, DateTo);
        }
        public DataSet SelectPatientDestination(string AccessionNo)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectPatientDestination(AccessionNo);
        }
        public DataSet SelectOlapOrder(DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectOlapOrder(FromDate, ToDate);
        }

        public DataSet SelectStudiesWorkloadbyModality(string SelectMode, DateTime DateFrom, DateTime DateTo)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectStudiesWorkloadbyModality(SelectMode, DateFrom, DateTo);
        }
        public DataSet SelectRadiologistWorkload(DateTime FromDate, DateTime ToDate, int EMP_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadiologistWorkload(FromDate, ToDate, EMP_ID);
        }
        public DataSet SelectRadiologistWorkloadAIMC(DateTime DateFrom, DateTime DateTo)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadiologistWorkloadAIMC(DateFrom, DateTo);
        }

        public DataSet SelectDatetimeNowFromSQLServer()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectDatetimeNowFromSQLServer();
        }

        public DataSet SelectSummaryDFRadWithModalityUnitID(DateTime DateFrom, DateTime DateTo, int EMP_ID, int UNIT_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFRadWithModalityUnitID(DateFrom, DateTo, EMP_ID, UNIT_ID);
        }

        public DataSet SelectTATCombobox()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectTATCombobox();
        }
        public DataSet SelectTATReport(DateTime DateFrom, DateTime DateTo,int value)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectTATReport(DateFrom, DateTo,value);
        }
        public DataSet SelectFeedBackReport(DateTime DateFrom, DateTime DateTo)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectFeedBackReport(DateFrom, DateTo);
        }

        public DataSet SelectRadiologistWorkloadER(string MODE, DateTime DateFrom, DateTime DateTo, string strEmpID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRadiologistWorkloadER(MODE, DateFrom, DateTo, strEmpID);
        }
        public DataSet SelectAcFinalizePrivilegeCanUserFinalize(int EMP_ID, int EXAM_ID)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectAcFinalizePrivilegeCanUserFinalize(EMP_ID, EXAM_ID);
        }
        public DataSet SelectGBLGetCurrentDatetime()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectGBLGetCurrentDatetime();
        }
        public DataSet SelectGBLGetReportDataTimeForSynapse(string ACCESSION_NO)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectGBLGetReportDataTimeForSynapse(ACCESSION_NO);
        }
        public DataSet SelectGBLGeneral(int gen_id)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectGBLGeneral(gen_id);
        }

        public DataSet SelectSummaryDFRadAIMC(int Mode,DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFRadAIMC(Mode,FromDate, ToDate);
        }
        public DataSet SelectDateStatisticMode()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectDateStatisticMode();
        }
        public DataSet SelectDateStatistic(int Mode, DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectDateStatistic(Mode,FromDate,ToDate);
        }
        public string GetAIImageLink(int mode,string Accession)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.GetAIImageLink(mode,Accession);
        }

        public DataSet SelectContrastManagement(int Mode, DateTime FromDate, DateTime ToDate, string Hn)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectContrastManagement(Mode, FromDate, ToDate,Hn);
        }
        public DataSet SelectContrastLot(int contrastId)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectContrastLot(contrastId);
        }
        public DataSet SelectOrderIdByAccession(string accessionNo) {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectOrderIdByAccession(accessionNo);
        }
        public DataSet SelectRegIdByScheduleId(int scheduleId)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRegIdByScheduleId(scheduleId);
        }
        public DataSet SelectRptFindingAll()
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectRptFindingAll();
        }
        public DataSet SelectReportChangeStatus(DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectReportChangeStatus(FromDate, ToDate);
        }
        public DataSet SelectReportER(DateTime FromDate, DateTime ToDate)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectReportER(FromDate, ToDate);
        }
    }
}
