using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISSessionMaxappSelectData: DataAccessBase
    {
        public RIS_SESSIONMAXAPP RIS_SESSIONMAXAPP { get; set; }
        public RISSessionMaxappSelectData()
        {
            RIS_SESSIONMAXAPP = new RIS_SESSIONMAXAPP();
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONMAXAPP_Select;
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
            DbParameter[] parameters = { 
                                           Parameter("@MODALITY_ID", RIS_SESSIONMAXAPP.MODALITY_ID) 
                                           ,Parameter("@WEEKDAY", RIS_SESSIONMAXAPP.WEEKDAY) 
                                       };
            return parameters;
        }
    }
}
