using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISExamresulttimeSelectDta : DataAccessBase
    {
        DataSet ds;
        private string _execExamType;
        public string execExamType
        {
            get { return _execExamType; }
            set { _execExamType = value; }
        }
        public RISExamresulttimeSelectDta()
        {

        }
        public DataSet SelectAll(int _ID)
        {
            ParameterList = buildParameteSelectAll(_ID);
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTIME_SelectTAT;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByAccessionNo(string _acc)
        {
            ParameterList = buildParameteSelectByAccessionNo(_acc);
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTIME_SelectTAT;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByAccessionNoRad(string _acc, int _id)
        {
            ParameterList = buildParameteSelectByAccessionNoRad(_acc, _id);
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTIME_SelectTAT;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByDate(int _id, DateTime _from, DateTime _to)
        {
            ParameterList = buildParameteSelectByByDate(_id, _from, _to);
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTIME_SelectTAT;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectExecSummary(string _ExecSummary)
        {
            ParameterList = buildParameteSelectExecSummary(_ExecSummary);
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTIME_SelectTATExecSummary;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameteSelectExecSummary(string _ExecSummary)
        {
            DbParameter[] parameters = {
                                          Parameter("@ExecSummary",_ExecSummary)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByAccessionNoRad(string _acc, int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",_acc),
                                            Parameter("@RAD_ID",_id),
                                                Parameter("@FROM",DateTime.Now),
                                                    Parameter("@TO",DateTime.Now),
                                                        Parameter("@TYPE",4),
                                                            Parameter("@execExamType",_execExamType)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectAll(int _ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",""),
                                            Parameter("@RAD_ID",_ID),
                                                Parameter("@FROM",DateTime.Now),
                                                    Parameter("@TO",DateTime.Now),
                                                        Parameter("@TYPE",1),
                                                            Parameter("@execExamType",_execExamType)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByAccessionNo(string _acc)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",_acc),
                                            Parameter("@RAD_ID",0),
                                                Parameter("@FROM",DateTime.Now),
                                                    Parameter("@TO",DateTime.Now),
                                                        Parameter("@TYPE",2),
                                                            Parameter("@execExamType",_execExamType)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByByDate(int _id, DateTime _from, DateTime _to)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",""),
                                            Parameter("@RAD_ID",_id),
                                                Parameter("@FROM",_from),
                                                    Parameter("@TO",_to),
                                                        Parameter("@TYPE",3),
                                                            Parameter("@execExamType",_execExamType)

                                       };
            return parameters;
        }
    }
}
