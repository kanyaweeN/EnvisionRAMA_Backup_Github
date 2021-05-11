using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACFinalizePrivilegeSelectData : DataAccessBase
    {
        DataSet ds;
        public ACFinalizePrivilegeSelectData()
        {

        }
        public DataSet SelectJobTitle()
        {
            StoredProcedureName = StoredProcedure.Prc_AC_FINALIZEPRIVILEGE_SelectJobTitle;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectExamTypeWithIsActive(int EMP_ID)
        {
            ParameterList = buildParameteSelectExamTypeWithIsActive(EMP_ID);
            StoredProcedureName = StoredProcedure.Prc_AC_FINALIZEPRIVILEGE_SelectExamTypeWithIsActive;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameteSelectExamTypeWithIsActive(int EMP_ID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@EMP_ID",EMP_ID)

                                       };
            return parameters;
        }
    }
}
