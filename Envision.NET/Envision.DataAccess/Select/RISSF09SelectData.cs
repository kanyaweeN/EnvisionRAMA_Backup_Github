using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISSF09SelectData : DataAccessBase
    {
        public RISSF09SelectData()
        {
            StoredProcedureName = StoredProcedure.PRC_RIS_SF09_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        
    }
}
