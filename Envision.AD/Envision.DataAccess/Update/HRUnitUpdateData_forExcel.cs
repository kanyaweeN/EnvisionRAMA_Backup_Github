//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    18/06/2009 04:37:10
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class HRUnitUpdateData_forExcel : DataAccessBase
    {
        public HR_UNIT HR_UNIT { get; set; }

        public HRUnitUpdateData_forExcel()
        {
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_UpdateExcel;
            //StoredProcedureName = StoredProcedure.Prc_HR_EMP_Update_withJobTitle;		
        }
        public bool Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        public bool Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
            {
                Parameter("@UNIT_ID",HR_UNIT.UNIT_ID)
                ,Parameter("@UNIT_UID",HR_UNIT.UNIT_UID)
                ,Parameter("@UNIT_ID_PARENT",HR_UNIT.UNIT_ID_PARENT)
                ,Parameter("@UNIT_NAME",HR_UNIT.UNIT_NAME)
                ,Parameter("@UNIT_NAME_ALIAS",HR_UNIT.UNIT_NAME_ALIAS)
                ,Parameter("@PHONE_NO",HR_UNIT.PHONE_NO)
                ,Parameter("@DESCR",HR_UNIT.DESCR)
                ,Parameter("@UNIT_ALIAS",HR_UNIT.UNIT_ALIAS)
                ,Parameter("@UNIT_TYPE",HR_UNIT.UNIT_TYPE)
                ,Parameter("@UNIT_INS",HR_UNIT.UNIT_INS)
                ,Parameter("@IS_EXTERNAL",HR_UNIT.IS_EXTERNAL)
                ,Parameter("@LOC",HR_UNIT.LOC)
                ,Parameter("@LOC_ALIAS",HR_UNIT.LOC_ALIAS)
                ,Parameter("@LAST_MODIFIED_BY",HR_UNIT.LAST_MODIFIED_BY)
                ,Parameter("@ORG_ID",HR_UNIT.ORG_ID)
                ,Parameter("@UNIT_PARENT_NAME",HR_UNIT.UNIT_PARENT_NAME)
            };
            return parameters;
        }
    }
}

