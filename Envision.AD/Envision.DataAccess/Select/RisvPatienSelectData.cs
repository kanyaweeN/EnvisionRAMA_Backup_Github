using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RisvPatienSelectData : DataAccessBase
    {
        public RisvPatienSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_Risv_Patien_SelectData;
        }

        public DataSet Select()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
