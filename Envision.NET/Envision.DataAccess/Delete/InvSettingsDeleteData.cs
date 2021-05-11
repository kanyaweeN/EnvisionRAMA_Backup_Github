using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_SETTINGDeleteData : DataAccessBase
    {
        public INV_SETTING INV_SETTING { get; set; }
        public INV_SETTINGDeleteData()
        {
            INV_SETTING = new INV_SETTING();
            this.StoredProcedureName = StoredProcedure.Prc_INV_SETTINGS_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@SETTINGS_ID",INV_SETTING.SETTINGS_ID)
                                     };
            return parameters;
        }
    }
}
