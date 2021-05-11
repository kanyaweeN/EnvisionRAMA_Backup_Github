using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class FavouriteSelectData : DataAccessBase
    {

        public FavouriteSelectData(string sp)
        {
            if (sp == "1")
            {
                StoredProcedureName = StoredProcedure.Prc_GBLUserMenu;
            }
            else if (sp == "2")
            {
                StoredProcedureName = StoredProcedure.Prc_GBLUserSubMenu;
            }
            else
            {
                StoredProcedureName = StoredProcedure.Prc_GBLMyFavourite;
            }
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter( "@EMP_ID"	, new GBLEnvVariable().UserID)
                                       };
            return parameters;
        }

    }
}
