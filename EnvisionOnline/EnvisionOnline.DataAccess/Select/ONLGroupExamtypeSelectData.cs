using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLGroupExamtypeSelectData : DataAccessBase
    {

        public ONLGroupExamtypeSelectData()
        {
        }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAMTYPE_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters ={			

			};
            ParameterList = parameters;
            ds = ExecuteDataSet();

            return ds;
        }
        public DataSet GetDataByGDeptID(int gDeptID)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAMTYPE_SelectByGDeptID;
            DataSet ds = new DataSet();
            DbParameter[] parameters ={			
                                    Parameter("@GDEPT_ID",gDeptID)
			};
            ParameterList = parameters;
            ds = ExecuteDataSet();

            return ds;
        }
    }
}
