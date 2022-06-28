//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISModalitytypeInsertData : DataAccessBase 
	{
        public RIS_MODALITYTYPE RIS_MODALITYTYPE { get; set; }
		public  RISModalitytypeInsertData()
		{
            RIS_MODALITYTYPE = new RIS_MODALITYTYPE();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYTYPE_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@TYPE_UID",RIS_MODALITYTYPE.TYPE_UID)
                ,Parameter("@TYPE_NAME",RIS_MODALITYTYPE.TYPE_NAME)
                ,Parameter("@TYPE_NAME_ALIAS",RIS_MODALITYTYPE.TYPE_NAME_ALIAS)
                ,Parameter("@DESCR",RIS_MODALITYTYPE.DESCR)
                ,Parameter("@CREATED_BY",new GBLEnvVariable().UserID)
                ,Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                ,Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
			};
            return parameters;

        }
	}
}

