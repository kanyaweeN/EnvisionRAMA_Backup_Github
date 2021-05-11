using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class VNAHrUnitSelectData: DataAccessBase
    {
        public VNAHrUnitSelectData()
        {
        }

        public DataSet CheckUnit(string unit_uid)
        {
            DataSet ds = new DataSet();

            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Check;
            DbParameter[] parameters ={		
                                            Parameter( "@UNIT_UID", unit_uid ) ,
			};
            ParameterList = parameters;
            ds = ExecuteDataSetVNA();//ExecuteDataSet();
            return ds;
        }
    }
}

