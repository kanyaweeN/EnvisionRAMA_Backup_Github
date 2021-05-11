using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.Common;
using System.Data.Common;
using System.Data;


namespace Envision.DataAccess.Select
{
    public class RISModalitySelectData : DataAccessBase
    {
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public RISModalitySelectData()
        {
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select;
        }
        public DataSet Select()
        {
            return ExecuteDataSet();
        }
    }
}
