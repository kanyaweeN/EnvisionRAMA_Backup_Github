using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACClassSelectData : DataAccessBase
    {
         DataSet ds;
         public ACClassSelectData()
        {

        }
        public DataSet SelectAll()
        {
            ParameterList = buildParameteSelectAll();
            StoredProcedureName = StoredProcedure.Prc_AC_CLASS_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByID(int _id)
        {
            ParameterList = buildParameteSelectByID(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_CLASS_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameteSelectAll()
        {
            DbParameter[] parameters = { 
                                          Parameter("@CLASS_ID",0)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByID(int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@CLASS_ID",_id)

                                       };
            return parameters;
        }
    }
}
