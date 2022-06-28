using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
	public class GBL_RADEXPERIENCEDeleteData : DataAccessBase 
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }

        public GBL_RADEXPERIENCEDeleteData()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
            StoredProcedureName = StoredProcedure.Prc_GBL_RADEXPERIENCE_Delete;
		}
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
		public bool Delete(DbTransaction tran) 
		{
			if (tran!=null)
			{
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
			}
			else Delete();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                    //    Parameter("@RADIOLOGIST_ID"		,  GBL_RADEXPERIENCE.RADIOLOGIST_ID)
                                       };
            return parameters;
        }
	}
}

