using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class _LookUpSelect : DataAccessBase
    {
        DataSet ds;
        public _LookUpSelect()
        {

        }
        public DataSet SelectAGE(DateTime date)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@Datetime", date)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_Age_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectRadiologistConfig(int id)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@RADIOLOGIST_ID", id)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_RadiologistConfig_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet ScheduleNotParameter(string selectcase)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@selectcase", selectcase)
                ,new SqlParameter("@parameter", 0)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_SCHEDULE_Lookup.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet ScheduleHaveParameter(string selectcase, int id)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@selectcase", selectcase)
                ,new SqlParameter("@parameter",id)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_SCHEDULE_Lookup.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectOrderFrom(string selectcase)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@selectcase", selectcase)
                //,new SqlParameter("@parameter", 0)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_OrderForm_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectOPNoteExam(int reg_id)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@REG_ID", reg_id)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_ExamOPNote_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectOPNoteHN(string HN)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@HN", HN)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_OPNoteHN_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectRIS_RADSTUDYGROUP(int RADIOLOGIST_ID, string ACCESSION_NO, bool IS_FAVOURITE, bool IS_TEACHING,bool IS_OTHERS,string Type)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@RADIOLOGIST_ID", RADIOLOGIST_ID)
                ,new SqlParameter("@ACCESSION_NO", ACCESSION_NO)
                ,new SqlParameter("@IS_FAVOURITE", IS_FAVOURITE)
                ,new SqlParameter("@IS_TEACHING", IS_TEACHING)
                ,new SqlParameter("@IS_OTHERS", IS_OTHERS)
                ,new SqlParameter("@Type", Type)
                
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_RIS_RADSTUDYGROUP_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectExamResultLock(string AccessionNO,int UserID)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@ACCESSION_NO", AccessionNO)
                ,new SqlParameter("@USER_ID", UserID)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_ResultLock_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectClinicSession()
        {
            RIS.DataAccess.Select.RISClinicsessionSelectData proc = new RISClinicsessionSelectData();
            return proc.GetData();
        }
        public DataSet SelectHeaderReport()
        {
            ds = new DataSet();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_HeaderReport_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
        public DataSet SelectSumaryReport(int id, DateTime FromDate, DateTime ToDate, string Header)
        {
            ds = new DataSet();
            DataBaseHelper dbhelper = new DataBaseHelper("d");
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@FromDate", FromDate)
                ,new SqlParameter("@ToDate", ToDate)
                ,new SqlParameter("@ReportHeader", Header)
		    };
            switch (id)
            {
                case 1:
                    dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_Order.ToString());
                    break;
                case 2:
                    dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_Order.ToString());
                    break;
                case 3:
                    dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_Order.ToString());
                    break;
                case 4:
                    dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_Schedule.ToString());
                    break;
                case 5:
                    dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_ResultSpecialClinic.ToString());
                    break;
                case 6:
                    dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_Order.ToString());
                    break;
                default:
                    break;
            }
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectReleaseCombobox(string combobox)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@combobox", combobox)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_LookUp_ReleaseCombox_Select.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
        public DataSet SelectSummaryDFRad(DateTime FromDate, DateTime ToDate, int EmpID, int Unit)
        {
            ds = new DataSet();
            SqlParameter[] Parameters =
		    {
				new SqlParameter("@FromDate", FromDate)
                ,new SqlParameter("@ToDate", ToDate)
                ,new SqlParameter("@EMP_ID", EmpID)
                ,new SqlParameter("@Unit", Unit)
		    };

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_Rpt_Summary_DF_RateByAIMC.ToString());
            ds = dbhelper.Run(base.ConnectionString, Parameters);
            return ds;
        }
    }
}
