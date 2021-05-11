using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISSessionMaxAppSelectData: DataAccessBase 
	{
        private int _modality_id;
        public RISSessionMaxAppSelectData()
        {
        }
        public RISSessionMaxAppSelectData(int modality_id)
		{
            _modality_id = modality_id;
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONMAXAPP_SelectByModality;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",_modality_id)
			};
            return parameters;
        }
        public DataSet GetSetupData()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONMAXAPP_SelectSetup;
            ds = ExecuteDataSet();
            return ds;
        }
	}
}

