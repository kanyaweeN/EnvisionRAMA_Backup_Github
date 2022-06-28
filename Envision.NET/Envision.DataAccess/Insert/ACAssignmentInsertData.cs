using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ACAssignmentInsertData : DataAccessBase 
    {
       public AC_ASSIGNMENT AC_ASSIGNMENT { get; set; }
        int _id = 0;
        public ACAssignmentInsertData()
		{
            AC_ASSIGNMENT = new AC_ASSIGNMENT();
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_Insert_New;
            //StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_Insert_TEST;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter _ASSIGNEMENT_ID = Parameter("@ASSIGNEMENT_ID", AC_ASSIGNMENT.ASSIGNEMENT_ID);
            _ASSIGNEMENT_ID.Direction = ParameterDirection.Output;

            DbParameter _paramAssignedBy = Parameter();
            _paramAssignedBy.ParameterName = "@ASSIGNED_BY";
            _paramAssignedBy.Direction = ParameterDirection.Input;
            if (this.AC_ASSIGNMENT.ASSIGNED_BY == 0)
                _paramAssignedBy.Value = DBNull.Value;
            else
                _paramAssignedBy.Value = this.AC_ASSIGNMENT.ASSIGNED_BY;

            DbParameter[] parameters ={
_ASSIGNEMENT_ID
,Parameter("@ENROLL_ID",AC_ASSIGNMENT.ENROLL_ID)
,_paramAssignedBy
,Parameter("@ASSIGNMENT_TYPE",AC_ASSIGNMENT.ASSIGNMENT_TYPE)
//,Parameter("@ASSIGNED_ON",AC_ASSIGNMENT.ASSIGNED_ON)
,Parameter("@ACCESSION_NO",AC_ASSIGNMENT.ACCESSION_NO)
,Parameter("@ORG_ID",AC_ASSIGNMENT.ORG_ID)
,Parameter("@CREATED_BY",AC_ASSIGNMENT.CREATED_BY)
//,Parameter("@CREATED_ON",AC_CLASS.CREATED_ON)
,Parameter("@LAST_MODIFIED_BY",AC_ASSIGNMENT.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",AC_CLASS.LAST_MODIFIED_ON)
,Parameter("@REPORT_TYPE",AC_ASSIGNMENT.REPORT_TYPE)
,Parameter("@REPORT_TEXT",AC_ASSIGNMENT.REPORT_TEXT)
,Parameter("@SEVERITY_ID",AC_ASSIGNMENT.SEVERITY_ID)
,Parameter("@RESULT_STATUS",AC_ASSIGNMENT.RESULT_STATUS)
            };
            return parameters;
        }
    }
}
