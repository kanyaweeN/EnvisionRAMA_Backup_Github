using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISUnlockedUpdateData: DataAccessBase 
	{
        public RIS_UNLOCKEDCASE RIS_UNLOCKEDCASE { get; set; }
        public RISUnlockedUpdateData()
		{
            RIS_UNLOCKEDCASE = new RIS_UNLOCKEDCASE();
            StoredProcedureName = StoredProcedure.Prc_RIS_UNLOCKED_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
            Parameter("@SCHEDULE_ID",RIS_UNLOCKEDCASE.SCHEDULE_ID)
                                      };
            return parameters;
        }
	}
}

