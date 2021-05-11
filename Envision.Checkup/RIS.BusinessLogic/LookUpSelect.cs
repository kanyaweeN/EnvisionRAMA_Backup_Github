using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
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
        public DataSet SelectReleaseCombobox(string combobox)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectReleaseCombobox(combobox);
        }
        public DataSet SelectSummaryDFRad(DateTime FromDate, DateTime ToDate, int EmpID, int UNIT)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectSummaryDFRad(FromDate, ToDate, EmpID, UNIT);
        }
    }
}
