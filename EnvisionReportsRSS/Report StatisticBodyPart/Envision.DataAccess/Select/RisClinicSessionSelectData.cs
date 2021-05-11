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
    public class RisClinicSessionSelectData : DataAccessBase
    {
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }
        public RisClinicSessionSelectData()
        {
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
            StoredProcedureName = StoredProcedure.Prc_ONL_CLINICSESSION_Select;
        }
        public DataSet Select()
        {
            return ExecuteDataSet();
        }
    }
}
