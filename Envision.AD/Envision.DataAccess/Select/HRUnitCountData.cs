using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
        public class HRUnitCountData : DataAccessBase 
	{
        public HR_UNIT HR_UNIT { get; set; }
        public HRUnitCountData()
		{
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Count;
		}
        public DataSet Count()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {

            DbParameter[] parameters ={
                                          Parameter("@UNIT_UID",HR_UNIT.UNIT_UID)
                                        };
                                        return parameters;
        }
	}
}

