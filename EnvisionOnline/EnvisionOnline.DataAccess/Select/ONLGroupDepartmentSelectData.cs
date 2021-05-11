using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLGroupDepartmentSelectData : DataAccessBase
    {

        public ONLGroupDepartmentSelectData()
        {
        }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPDEPARTMENT_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters ={			

			};
            ParameterList = parameters;
            ds = ExecuteDataSet();

            return ds;
        }
        public DataSet GetDataByGDeptType(string groupDepartmentType)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPDEPARTMENT_SelectByGDeptTYPE;
            DataSet ds = new DataSet();
            DbParameter[] parameters ={			
                Parameter("@GDEPT_TYPE",groupDepartmentType)
			};
            ParameterList = parameters;
            ds = ExecuteDataSet();

            return ds;
        }
    }
}

