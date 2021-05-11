using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RIS.DataAccess.Select
{
    public class RisvFreqUsedExam : DataAccessBase
    {
        public RisvFreqUsedExam()
        {
            base.StoredProcedureName = StoredProcedure.Name.Prc_RISV_FREQUSEDEXAM.ToString();
        }

        public DataSet Select()
        { 
            DataSet ds;
            DataBaseHelper dbhelper = new DataBaseHelper(base.StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString);
            return ds;
        }
    }
}
