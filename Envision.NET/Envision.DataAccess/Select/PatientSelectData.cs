using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class PatientSelectData : DataAccessBase
    {
        public PatientSelectData()
        {
            StoredProcedureName = StoredProcedure.PRC_RIS_SF04_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        
    }
}
