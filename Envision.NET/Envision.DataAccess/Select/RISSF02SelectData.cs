using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISSF02SelectData : DataAccessBase
    {
        public RISSF02SelectData()
        {
            StoredProcedureName = StoredProcedure.PRC_RIS_SF02_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }     
    }
}
