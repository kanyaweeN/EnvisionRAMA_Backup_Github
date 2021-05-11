using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class VNAWorklistSelectData: DataAccessBase
    {
        public VNA_WORKLIST VNA_WORKLIST { get; set; }
        public VNAWorklistSelectData()
        {
            VNA_WORKLIST = new VNA_WORKLIST();
        }

        public DataSet getData()
        {
            DataSet ds = new DataSet();

            StoredProcedureName = StoredProcedure.Prc_VNA_Worklist_Select;

            DbParameter param1 = Parameter("@FROM_DATE", VNA_WORKLIST.FROM_DATE);
            param1.Value = VNA_WORKLIST.FROM_DATE == DateTime.MinValue ? (object)DBNull.Value : VNA_WORKLIST.FROM_DATE;
            DbParameter param2 = Parameter("@TO_DATE", VNA_WORKLIST.TO_DATE);
            param2.Value = VNA_WORKLIST.TO_DATE == DateTime.MinValue ? (object)DBNull.Value : VNA_WORKLIST.TO_DATE;

            DbParameter[] parameters ={		
                                            Parameter( "@MODE", VNA_WORKLIST.MODE ) ,
                                            Parameter( "@HN", VNA_WORKLIST.HN ) ,
                                            Parameter( "@UNIT_ID", VNA_WORKLIST.REF_UNIT ) ,
                                            param1,
                                            param2 ,
			};
            ParameterList = parameters;
            ds = ExecuteDataSetVNA();
            return ds;
        }
    }
}
