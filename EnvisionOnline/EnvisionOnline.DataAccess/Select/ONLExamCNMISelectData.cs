using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLExamCNMISelectData: DataAccessBase
    {
        public ONLExamCNMISelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_EXAMCNMI_Select;
        }

        public DataSet Get(int exam_id)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(exam_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int exam_id)
        {
            DbParameter[] parameters ={		
                                            Parameter( "@EXAM_ID", exam_id ) ,
			};
            return parameters;
        }
    }
}

