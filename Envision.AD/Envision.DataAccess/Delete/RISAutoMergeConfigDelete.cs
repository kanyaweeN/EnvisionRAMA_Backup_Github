using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class RISAutoMergeConfigDelete : DataAccessBase
    {

        public string Config_Name
        {
            get;
            set;
        }
        public RISAutoMergeConfigDelete() {
            StoredProcedureName = StoredProcedure.Prc_RIS_AUTOMERGECONFIG_DELETE;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@config_name",Config_Name)
                                     };
            return parameters;
        }
    }
}
