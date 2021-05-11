using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionHelpdesk.DataAccess.Select
{
    public class HelpdeskPatientDetailSelectData : DataAccessBase
    {
        public HelpdeskPatientDetailSelectData()
        {
        }
        public DataSet getDatabyHN(string hn)
        {
            DataSet ds = new DataSet();
            StoreProcedureName = StoreProcedure.Prc_Helpdesk_PatientDetail_Select.ToString();
            ParameterList = buildParameter(hn);
            ds = ExecuteDataSet();
            ds.DataSetName = "PatientDetail";
            return ds;
        }
        private DbParameter[] buildParameter(string hn)
        {
            DbParameter[] parameters = { 
                                          Parameter("@HN"	, hn  )
                                       };
            return parameters;
        }
    }
}
