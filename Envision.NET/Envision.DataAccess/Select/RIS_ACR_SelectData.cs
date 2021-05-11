using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RIS_ACR_SelectData : DataAccessBase 
    {
        public RIS_ACR_SelectData() {
            StoredProcedureName = StoredProcedure.Prc_RIS_ACR_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
