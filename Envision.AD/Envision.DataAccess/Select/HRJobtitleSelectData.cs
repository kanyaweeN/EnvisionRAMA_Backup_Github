using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class HRJobtitleSelectData : DataAccessBase
    {
        public HR_JOBTITLE HR_JOBTITLE { get; set; }
        public HRJobtitleSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_JOBTITLE_Select;
            HR_JOBTITLE = new HR_JOBTITLE();
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                Parameter("@MODE",HR_JOBTITLE.MODE)
                                                ,Parameter("@JOB_TITLE_ID",HR_JOBTITLE.JOB_TITLE_ID)
                                                ,Parameter("@IS_ACTIVE",HR_JOBTITLE.IS_ACTIVE)
                                                ,Parameter("@ORG_ID",HR_JOBTITLE.ORG_ID)
                                       };
            return parameters;
        }
    }
}
