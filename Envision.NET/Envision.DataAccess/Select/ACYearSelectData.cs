using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACYearSelectData : DataAccessBase
    {
        DataSet ds;
        public ACYearSelectData()
        {

        }
        public DataSet SelectAll()
        {
            ParameterList = buildParameteSelectAll();
            StoredProcedureName = StoredProcedure.Prc_AC_YEAR_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByID(int _id)
        {
            ParameterList = buildParameteSelectByID(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_YEAR_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByDatenow()
        {
            //ParameterList = buildParameteSelectByDatenow(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_YEAR_SelectByDatenow;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        
        private DbParameter[] buildParameteSelectAll()
        {
            DbParameter[] parameters = { 
                                          Parameter("@YEAR_ID",0)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByID(int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@YEAR_ID",_id)

                                       };
            return parameters;
        }
    }
}
