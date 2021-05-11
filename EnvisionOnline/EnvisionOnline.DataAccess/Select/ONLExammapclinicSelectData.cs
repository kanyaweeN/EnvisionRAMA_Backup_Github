using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLExammapclinicSelectData: DataAccessBase
    {
        public ONL_EXAMMAPCLINIC ONL_EXAMMAPCLINIC { get; set; }
        public ONLExammapclinicSelectData()
        {
            ONL_EXAMMAPCLINIC = new ONL_EXAMMAPCLINIC();
            StoredProcedureName = StoredProcedure.Prc_ONL_EXAMMAPCLINIC_Select;
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
            DbParameter[] parameters ={		
                                            Parameter( "@EXAM_ID", ONL_EXAMMAPCLINIC.EXAM_ID ) ,
                                            Parameter( "@CLINIC_TYPE_ID", ONL_EXAMMAPCLINIC.CLINIC_TYPE_ID ) ,
			};
            return parameters;
        }
    }
}