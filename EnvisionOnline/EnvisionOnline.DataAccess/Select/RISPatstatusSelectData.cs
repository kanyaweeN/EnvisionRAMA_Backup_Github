using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{

    public class RISPatstatusSelectData : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public RISPatstatusSelectData()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATSTATUS_SelectActive;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}

