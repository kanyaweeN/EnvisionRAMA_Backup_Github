using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISContrastLotSelectData : DataAccessBase
    {
        public RISContrastLotSelectData()
        {

        }
        public DataSet SelectAll()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTLOT_Select;
            return ExecuteDataSet();
        }
        public DataSet getMappingByLotId(int lotId)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTLOTMAPPING_Select;
            DbParameter[] parameters ={
Parameter("@LOT_ID",lotId),
            };
            ParameterList = parameters;
            return ExecuteDataSet();
        }
    }
}
