using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common;
namespace EnvisionOnline.DataAccess.Select
{
	public class RISExamresultSelectData : DataAccessBase 
	{
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }
		
        public  RISExamresultSelectData()
		{
			//StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMRESULT_Select.ToString();


            //StoredProcedureName = string.Empty;
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
		}
		
        
        public DataTable GetNextData(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Next;
            ParameterList = buildParameterAccessionNumber(ACCESSION_NO);
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt; 
        }
        public DataTable GetPreviousData(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Previous;
            ParameterList = buildParameterAccessionNumber(ACCESSION_NO);
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt; 
        }
        public DataTable GetWorkList()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_WorkList;
            //StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_WorkList_forTest;
            ParameterList = buildParameterWorkList();
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
		}
        public DataTable GetCaseSelect(string AccessionNo,int _EMPID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_CaseSelect;
            ParameterList = buildParameterCaseSelect(AccessionNo, _EMPID);
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;

        }
        public DataSet   GetCaseAmount()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_CaseAmt;
            ParameterList = buildParameterEmpID();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet   GetHistory() {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_History;
            ParameterList = buildParameterHistory();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable GetArchive()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_BrowseArchive_Select;
            ParameterList = buildParameterArchive();
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetTransfer()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Transfer_Select;
            ParameterList = buildParameterTransfer();
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetMergeData() {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_MergeSelect;
            ParameterList = buildParameterMerge();
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
            
        }
        public DataTable GetExamResult() {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Select;
            ParameterList = buildParameterAccessionNumber(RIS_EXAMRESULT.ACCESSION_NO);
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetReportStatus(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Status;
            ParameterList = buildParameterAccessionNumber(ACCESSION_NO);
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt; 
        }
        public DataSet GetExamNote()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTNOTE_Select;
            ParameterList = buildParameterAccessionNumber(RIS_EXAMRESULT.ACCESSION_NO);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public void UpdateTransfer()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Transfer_Update;
            ParameterList = buildParameterUpdateTransfer();
            ExecuteNonQuery();
        }
        public void Merge() {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_MergeSplit;
            ParameterList = buildParameterMerge();
            ExecuteNonQuery();
        }
        public DataSet GetConsultCase(string ACCESSION_NO)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_SelectConsultCase;
            ParameterList = new DbParameter[] { Parameter("ACCESSION_NO", ACCESSION_NO) };
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameterAccessionNumber(string ACCESSION_NO)
        {
            DbParameter[] parameters = { 
                                              Parameter("ACCESSION_NO",ACCESSION_NO),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterWorkList() {
            DbParameter[] parameters = { 
                                                 Parameter("@MODE",RIS_EXAMRESULT.MODE)
                                                , Parameter("@EMP_ID",RIS_EXAMRESULT.EMP_ID)
                                                , Parameter("@HN",RIS_EXAMRESULT.HN)
                                                , Parameter("@FROM_DT",RIS_EXAMRESULT.FROM_DATE)
                                                , Parameter("@TO_DT",RIS_EXAMRESULT.TO_DATE)
                                                , Parameter("@STATUS",RIS_EXAMRESULT.STATUS)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterCaseSelect(string AccessionNo,int _EMPID)
        {
            DbParameter[] parameters = { 
                                                 Parameter("@ACCESSION_NO",AccessionNo)
                                                 , Parameter("@EMP_ID",_EMPID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterEmpID()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@EMP_ID",RIS_EXAMRESULT.EMP_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterHistory()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@ACCESSION_NO",RIS_EXAMRESULT.ACCESSION_NO)
                                                , Parameter("@HN",RIS_EXAMRESULT.HN)
                                                , Parameter("@ORDER_ID",RIS_EXAMRESULT.ORDER_ID)
                                                , Parameter("@EMP_ID",RIS_EXAMRESULT.EMP_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterArchive()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@MODE",RIS_EXAMRESULT.MODE)
                                                , Parameter("@EMP_ID",RIS_EXAMRESULT.EMP_ID)
                                                , Parameter("@FROM_DT",RIS_EXAMRESULT.FROM_DATE)
                                                , Parameter("@TO_DT",RIS_EXAMRESULT.TO_DATE)
                                                , Parameter("@HN",RIS_EXAMRESULT.HN)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterTransfer()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@MODE",RIS_EXAMRESULT.MODE)
                                                , Parameter("@EMP_ID",RIS_EXAMRESULT.EMP_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterMerge()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@MERGE",RIS_EXAMRESULT.MERGE)
                                                , Parameter("@MERGE_WITH",RIS_EXAMRESULT.MERGE_WITH)
                                                , Parameter("@ACCESSION_NO",RIS_EXAMRESULT.ACCESSION_NO)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateTransfer()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@ORDER_ID",RIS_EXAMRESULT.ORDER_ID)
                                                , Parameter("@EXAM_ID",RIS_EXAMRESULT.EXAM_ID)
                                                , Parameter("@ASSIGNED_TO",RIS_EXAMRESULT.EMP_ID)
                                       };
            return parameters;
        }
	}
}

