using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class VNAWorklistInsertData: DataAccessBase
    {
        public VNA_WORKLIST VNA_WORKLIST { get; set; }
        public VNAWorklistInsertData()
        {
            VNA_WORKLIST = new VNA_WORKLIST();
        }
        public int AddData()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_VNA_WORKLIST_InsertOrUpdate;
            ParameterList = buildParameter();
            ds = ExecuteDataSetVNA();
            int id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={		
	             Parameter("@VN",VNA_WORKLIST.VN),
                 Parameter("@REG_ID",VNA_WORKLIST.REG_ID),
                 Parameter("@ORG_ID",VNA_WORKLIST.ORG_ID),
                 Parameter("@ENC_ID",VNA_WORKLIST.ENC_ID),
                 Parameter("@ENC_TYPE",VNA_WORKLIST.ENC_TYPE),
                 Parameter("@SDLOC_ID",VNA_WORKLIST.SDLOC_ID),
                 Parameter("@INSURANCE",VNA_WORKLIST.INSURANCE),
                 Parameter("@EFFECTIVE_START_DATE",VNA_WORKLIST.EFFECTIVE_START_DATE),
                 Parameter("@CREATED_BY_UID",VNA_WORKLIST.CREATED_BY_UID),
                 Parameter("@LAST_MODIFIED_BY_UID",VNA_WORKLIST.LAST_MODIFIED_BY_UID),
			};
            return parameters;
        }
    }
}
