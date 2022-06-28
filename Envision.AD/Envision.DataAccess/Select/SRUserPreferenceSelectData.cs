using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class SRUserPreferenceSelectData : DataAccessBase 
    {
        public SR_USERPREFERENCE SR_USERPREFERENCE { get; set; }
        public SRUserPreferenceSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_Select;
            SR_USERPREFERENCE = new SR_USERPREFERENCE();
        }
        
        public DataTable GetData() {
            DataTable dtt = new DataTable();
            ParameterList = buildParameter();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@EXAM_ID"	, SR_USERPREFERENCE.EXAM_ID ),
                                          Parameter("@EMP_ID"	, SR_USERPREFERENCE.EMP_ID )
                                       };
            return parameters;
        }

        public DataTable GetDataByEmpId() {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_SelectByEmpId;
            ParameterList = buildParameterByEmpId();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameterByEmpId()
        {
            DbParameter[] parameters = { 
                                          Parameter("@EMP_ID"	, SR_USERPREFERENCE.EMP_ID )
                                       };
            return parameters;
        }

        public DataTable GetExamData()
        {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_SR_USERPREFERENCE_SelectByExam;
            dtt = ExecuteDataTable();
            return dtt;
        }
    }
}
