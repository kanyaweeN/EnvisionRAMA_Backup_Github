using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ModalityLoadSelectData : DataAccessBase
    {
        public ModalityLoadSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_Modality_Load;
        }

        public DataSet Get(int _sptype, DateTime _scdate)
        {

            DataSet ds = new DataSet();
            ParameterList = buildParameter(_sptype, _scdate);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int _sptyp, DateTime scdt)
        {
            DbParameter[] parameters = { 
                                                    Parameter( "@SP_Types"	    ,_sptyp),
                                                    Parameter( "@SCHEDULE_DT"	, scdt),
                                                    Parameter( "@ORG_ID"	    , new GBLEnvVariable().OrgID ),
                                       };
            return parameters;
        }
        
    }
}
