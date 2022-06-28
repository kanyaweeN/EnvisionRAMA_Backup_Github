using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISAutoMergeConfigSelect : DataAccessBase
    {
        public DataSet Result { get; set; }

        public RISAutoMergeConfigSelect() {
            Result = null;
        }

        public void Select()
        {
            Result = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_AutoMergeConfig_Select;
            Result = ExecuteDataSet();
        }
    }
}
