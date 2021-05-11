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
    public class RISHrUnitSelectData : DataAccessBase
    {
        public HR_UNIT HR_UNIT { get; set; }
        public RISHrUnitSelectData()
        {
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Select;
        }
        public DataSet Select()
        {
            return ExecuteDataSet();
        }
    }
}
