using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLGroupExamSelectData: DataAccessBase
    {

        public ONLGroupExamSelectData()
        {
        }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAM_Select;
            DataSet ds = new DataSet();

            DbParameter[] parameters ={			

			};
            ParameterList = parameters;
                ds = ExecuteDataSet();

            return ds;
        }
        public DataSet GetDataByGTypeID(int GTypeID)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAM_SelectByGTypeID;
            DataSet ds = new DataSet();

            DbParameter[] parameters ={		
	                                      Parameter("@GTYPE_ID", GTypeID)

			};
            ParameterList = parameters;
            ds = ExecuteDataSet();

            return ds;
        }
    }
}
