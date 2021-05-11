using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class PatientSelectData : DataAccessBase
    {
        public PatientSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PATSTATUS_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }


    }
}

