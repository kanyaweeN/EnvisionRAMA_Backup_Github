using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class RisvPatienSelectData : DataAccessBase
    {
        public RisvPatienSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Risv_Patien_SelectData.ToString();
        }

        public DataSet Select()
        {
            DataSet ds;
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);

            return ds;
        }
    }
}
