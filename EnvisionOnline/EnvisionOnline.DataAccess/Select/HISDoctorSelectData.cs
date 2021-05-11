using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class HISDoctorSelectData : DataAccessBase
    {

        public HISDoctor HISDoctor { get; set; }
        private int ORG_ID;
        public HISDoctorSelectData()
        {
            ORG_ID = 1;
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_SelectDoctor;
            HISDoctor = new HISDoctor();
        }
        public HISDoctorSelectData(int org_id)
        {
            ORG_ID = org_id;
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_SelectDoctor;
            HISDoctor = new HISDoctor();
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(ORG_ID);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int org_id)
        {
            DbParameter[] parameters = { 
                                                      //Parameter("@ORG_ID",org_id)
                                       };
            return parameters;
        }
    }
}

