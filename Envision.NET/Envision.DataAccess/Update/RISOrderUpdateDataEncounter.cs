using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISOrderUpdateDataEncounter : DataAccessBase
    {
        public RIS_ORDER RIS_ORDER { get; set; }

        public RISOrderUpdateDataEncounter()
        {
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateEncounter;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void UpdateRefUnit()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_UpdateEncounterRefunit;
            ParameterList = buildParameterRefUnit();
            ExecuteNonQuery();
        }
        public void Update_ADMISSION_NO()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Update_ADMISSION_NO;
            ParameterList = buildParameter_ADMISSION_NO();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@ORDER_ID"         ,   RIS_ORDER.ORDER_ID   ),
                Parameter( "@ENC_ID"        ,   RIS_ORDER.ENC_ID  ),
                Parameter( "@ENC_TYPE"       ,   RIS_ORDER.ENC_TYPE ),
                Parameter( "@CREATED_BY"     ,   new GBLEnvVariable().UserID  ),
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterRefUnit()
        {
            DbParameter[] parameters ={
                Parameter( "@ORDER_ID"         ,   RIS_ORDER.ORDER_ID   ),
                Parameter( "@ENC_ID"        ,   RIS_ORDER.ENC_ID  ),
                Parameter( "@ENC_TYPE"       ,   RIS_ORDER.ENC_TYPE ),
                Parameter( "@UNIT_ID"       ,   RIS_ORDER.REF_UNIT ),
                Parameter( "@CREATED_BY"     ,   new GBLEnvVariable().UserID  ),
                                      };
            return parameters;
        }
        private DbParameter[] buildParameter_ADMISSION_NO()
        {
            DbParameter[] parameters ={
                Parameter( "@ORDER_ID"         ,   RIS_ORDER.ORDER_ID   ),
                Parameter( "@ADMISSION_NO"        ,   RIS_ORDER.ADMISSION_NO  ),
                Parameter( "@CREATED_BY"     ,   new GBLEnvVariable().UserID  ),
                                      };
            return parameters;
        }
    }
}
