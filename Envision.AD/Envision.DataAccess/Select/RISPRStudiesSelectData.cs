using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISPRStudiesSelectData: DataAccessBase
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }
        public RISPRStudiesSelectData()
		{
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
            StoredProcedureName = StoredProcedure.Prc_RIS_PRSTUDIES_SELECTWorklist;
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
            DbParameter[] parameters ={			
                Parameter("@EMP_ID",RIS_PRSTUDIES.RAD_ID)
			};
            return parameters;
        }

        public string getResultText(string accession_no)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_PRSTUDIES_SelectResult;
            ParameterList = new DbParameter[] {			
                Parameter("@ACCESSION_NO",accession_no)
			};
            ds = ExecuteDataSet();


            return ds.Tables[0].Rows[0]["RESULT_TEXT_RTF"].ToString();
        }

        public DataSet GetGroupFromPrStudies(DateTime dtStart, DateTime dtEnd)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_SelectGroupPrStudies;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@ORG_ID"	        , RIS_PRSTUDIES.ORG_ID ),
                                             Parameter( "@dtStart"	        , dtStart ),
                                             Parameter( "@dtEnd"	        , dtEnd ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet getGroupFromPrStudiesByGroupIdAndAlgorithmId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_SelectGroupPrStudiesByGroupIdAndAlgorithmId;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@PR_GROUP_ID"	        , RIS_PRSTUDIES.PR_GROUP_ID ),
                                             Parameter( "@PR_ALGORITHM_ID"	    , RIS_PRSTUDIES.PR_ALGORITHM_ID ),
                                             Parameter( "@ORG_ID"	            , RIS_PRSTUDIES.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
	}
}
