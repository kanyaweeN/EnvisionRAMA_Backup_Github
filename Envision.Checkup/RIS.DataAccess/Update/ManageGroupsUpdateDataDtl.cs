using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class ManageGroupsUpdateDataDtl : DataAccessBase
    {
        ManageGroups _mng;
        public ManageGroupsUpdateDataDtl()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ManageGroups_Update_Dtl.ToString();
        }

        public void Set()
        {
            ManageGroupsUpdateDataDtlParameters mngpara = new ManageGroupsUpdateDataDtlParameters(ManageGroups);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);

            dbhelper.RunScalar(base.ConnectionString, mngpara.Parameters);
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }

    public class ManageGroupsUpdateDataDtlParameters
    {
        SqlParameter[] _parameters;
        ManageGroups _mng;

        public ManageGroupsUpdateDataDtlParameters(ManageGroups mng)
        {
            _mng = mng;
            Build();
        }

        public void Build()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter(   "@Gid"          ,   _mng.GROUP_ID   ),
                new SqlParameter(   "@Gmemid"       ,   _mng.MEMBER_ID  ),
                new SqlParameter(   "@Gsl"          ,   _mng.SL         ),
                new SqlParameter(   "@Isactive"     ,   _mng.IS_ACTIVE  ),
                //new SqlParameter(   "@Check"        ,   _mng.GROUP_HEAD ),
                new SqlParameter(   "@Orgid"        ,   new Common.Common.GBLEnvVariable().OrgID),
            };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
