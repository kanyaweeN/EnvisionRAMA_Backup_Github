//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/01/2552 03:44:19
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
	public class GBLHospitalInsertData : DataAccessBase 
	{
        public GBL_HOSPITAL GBL_HOSPITAL { get; set; }
		public  GBLHospitalInsertData()
		{
            GBL_HOSPITAL = new GBL_HOSPITAL();
			StoredProcedureName = StoredProcedure.Prc_GBL_HOSPITAL_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@HOS_UID",GBL_HOSPITAL.HOS_UID)
                ,Parameter("@HOS_NAME",GBL_HOSPITAL.HOS_NAME)
                ,Parameter("@HOS_NAME_ALIAS",GBL_HOSPITAL.HOS_NAME_ALIAS)
                ,Parameter("@PHONE_NO",GBL_HOSPITAL.PHONE_NO)
                ,Parameter("@DESCR",GBL_HOSPITAL.DESCR)
                ,Parameter("@ORG_ID",GBL_HOSPITAL.ORG_ID)
                ,Parameter("@CREATED_BY",GBL_HOSPITAL.CREATED_BY)
            };
            return parameters;
        }
	}
}

