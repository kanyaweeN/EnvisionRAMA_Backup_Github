using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class ManageGroupsDeleteDataDtl : DataAccessBase
    {
        public GBL_GROUPDTL GBL_GROUPDTL { get; set; }
     
        public ManageGroupsDeleteDataDtl()
        {
            GBL_GROUPDTL = new GBL_GROUPDTL();
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_Delete_Dtl;
        }

        public void Set()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@Gid",GBL_GROUPDTL.GROUP_ID),
                                     };
            return parameters;
        }
     
    }
}
