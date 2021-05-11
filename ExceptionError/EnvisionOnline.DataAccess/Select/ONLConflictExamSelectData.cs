using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLConflictExamSelectData : DataAccessBase
    {
        public RIS_CONFLICTEXAMGROUP RIS_CONFLICTEXAMGROUP { get; set; }
        public ONLConflictExamSelectData()
        {
            RIS_CONFLICTEXAMGROUP = new RIS_CONFLICTEXAMGROUP();
            StoredProcedureName = StoredProcedure.Prc_ONL_CONFLICTEXAM_Select;
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
                                            Parameter( "@REG_ID", RIS_CONFLICTEXAMGROUP.REG_ID ) ,
                                            Parameter( "@EXAM_ID", RIS_CONFLICTEXAMGROUP.EXAM_ID ) ,
			};
            return parameters;
        }
    }
}
