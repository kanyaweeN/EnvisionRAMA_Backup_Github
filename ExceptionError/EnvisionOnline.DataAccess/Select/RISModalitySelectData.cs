using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISModalitySelectData : DataAccessBase
    {
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public RISModalitySelectData()
        {
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select;
        }
        public RISModalitySelectData(bool selectAll)
        {
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectAll;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

    }
}

