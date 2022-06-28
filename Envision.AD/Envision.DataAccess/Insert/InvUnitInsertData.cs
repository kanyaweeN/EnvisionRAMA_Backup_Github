using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvUnitInsertData : DataAccessBase
    {
        public INV_UNIT INV_UNIT { get; set; }

        public InvUnitInsertData()
        {
            INV_UNIT = new INV_UNIT();
            this.StoredProcedureName = StoredProcedure.Prc_INV_UNIT_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                           Parameter("@UNIT_UID",INV_UNIT.UNIT_UID),
                            Parameter("@UNIT_NAME",INV_UNIT.UNIT_NAME),
                            Parameter("@UNIT_DESC",INV_UNIT.UNIT_DESC),
                            Parameter("@EXTERNAL_UNIT",INV_UNIT.EXTERNAL_UNIT),
                            Parameter("@ORG_ID",INV_UNIT.ORG_ID),
			            };
            return parameters;
        }
    }
}
