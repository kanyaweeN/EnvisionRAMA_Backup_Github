//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 03:51:49
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class HRUnitInsertData_forExcel : DataAccessBase 
	{
        public HR_UNIT HR_UNIT { get; set; }
        public HRUnitInsertData_forExcel()
		{
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_InsertExcel;
		}
		public int Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return (int)ParameterList[0].Value;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@UNIT_ID", HR_UNIT.UNIT_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
                    param1
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
                    ,Parameter("@CREATED_BY",HR_UNIT.CREATED_BY)
                    ,Parameter("@ORG_ID",HR_UNIT.ORG_ID)
                    ,Parameter("@LOC_ALIAS",HR_UNIT.LOC_ALIAS)
                    ,Parameter("@UNIT_PARENT_NAME",HR_UNIT.UNIT_PARENT_NAME)
            };
            return parameters;
        }
	}
}

