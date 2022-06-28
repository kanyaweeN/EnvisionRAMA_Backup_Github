using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACGradeSelectData : DataAccessBase
    {
        DataSet ds;
        public ACGradeSelectData()
        {

        }
        public DataSet SelectAll()
        {
            ParameterList = buildParameteSelectAll();
            StoredProcedureName = StoredProcedure.Prc_AC_GRADE_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByID(int _id)
        {
            ParameterList = buildParameteSelectByID(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_GRADE_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameteSelectAll()
        {
            DbParameter[] parameters = { 
                                          Parameter("@GRADE_ID",0)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByID(int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@GRADE_ID",_id)

                                       };
            return parameters;
        }
    }
}
