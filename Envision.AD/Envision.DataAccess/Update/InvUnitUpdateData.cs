using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvUnitUpdateData : DataAccessBase
    {
        public INV_UNIT INV_UNIT { get; set; }

        public InvUnitUpdateData()
        {
            INV_UNIT = new INV_UNIT();
            this.StoredProcedureName = StoredProcedure.Prc_INV_UNIT_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@UNIT_ID",INV_UNIT.UNIT_ID),
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
