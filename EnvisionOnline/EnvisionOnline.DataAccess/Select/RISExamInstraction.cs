using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISExamInstraction: DataAccessBase
    {
        public RIS_EXAMINSTRUCTION  RIS_EXAMINSTRUCTION { get; set; }
        public RISExamInstraction()
        {
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
        }

        public DataSet getNavigateInstruction(int exam_id)
        {
            DataSet ds = new DataSet();

            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMINSTRUCTIONS_SelectNavigation;
            ParameterList = buildParameterNavigateInstruction(exam_id);
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameterNavigateInstruction(int exam_id)
        {
            DbParameter[] parameters ={		
                                            Parameter( "@EXAM_ID", exam_id ) ,
			};
            return parameters;
        }
    }
}

