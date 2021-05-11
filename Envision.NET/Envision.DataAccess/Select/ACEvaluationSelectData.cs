using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACEvaluationSelectData : DataAccessBase
    {
        DataSet ds;
        public ACEvaluationSelectData()
        {

        }
        public DataSet SelectAll()
        {
            ParameterList = buildParameteSelectAll();
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByID(int _id)
        {
            ParameterList = buildParameteSelectByID(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameteSelectAll()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ASSIGNMENT_ID",0)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByID(int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ASSIGNMENT_ID",_id)

                                       };
            return parameters;
        }

        private DbParameter[] buildParameteWorkList(int EmpId)
        {
            DbParameter[] parameters = { 
                                            Parameter("@EMP_ID",EmpId)
                                       };
            return parameters;
        }
        public DataTable GetWorkList(int empId)
        {
            ParameterList = buildParameteWorkList(empId);
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_WorkList;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }

        private DbParameter[] buildParameteWorkListDate(int EmpId, DateTime dtFrom, DateTime dtTo)
        {
            DbParameter[] parameters = { 
                                                Parameter("@EMP_ID",EmpId),
                                                Parameter("@DtFrom",dtFrom),
                                                Parameter("@DtTo",dtTo)
                                       };
            return parameters;
        }
        public DataTable GetWorkList(int empId, DateTime dtFrom, DateTime dtTo)
        {
            ParameterList = buildParameteWorkListDate(empId, dtFrom, dtTo);
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_WorkListByDateTime;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }

        public DataTable GetWorkListNew(int empId)
        {
            ParameterList = new DbParameter[] { 
                                            Parameter("@EMP_ID",empId)
                                       };
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_WorkListNew;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetWorkListNew(int empId, DateTime dtFrom, DateTime dtTo)
        {
            ParameterList = new DbParameter[] { 
                                                Parameter("@EMP_ID",empId),
                                                Parameter("@DtFrom",dtFrom),
                                                Parameter("@DtTo",dtTo)
                                       };
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_WorkListByDateTimeNew;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }

        public DataTable GetBindData(string AccessionNo)
        {
            ParameterList = new DbParameter[] { 
                                            Parameter("@ACCESSION_NO",AccessionNo)
                                       };
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_GetBindData;
            DataTable dtt = new DataTable();
            dtt = ExecuteDataTable();
            return dtt;
        }
    }
}
