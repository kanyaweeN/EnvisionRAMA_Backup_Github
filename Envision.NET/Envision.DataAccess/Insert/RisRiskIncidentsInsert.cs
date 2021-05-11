using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RisRiskIncidentsInsert : DataAccessBase
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public RisRiskIncidentsInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_INSERT;
        }
        public void InsertData()
        {
            ParameterList = this.BuildParameters();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ExecuteDataSet();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            this.RIS_RISKINCIDENTS.INCIDENT_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["INCIDENT_ID"]);
                        }
                        catch (Exception) { this.RIS_RISKINCIDENTS.INCIDENT_ID = -1; }
                    }
                }
            }
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter incidentDtParameter;
            if (RIS_RISKINCIDENTS.INCIDENT_DT == DateTime.MinValue)
                incidentDtParameter = Parameter("@INCIDENT_DT", DBNull.Value);
            else
                incidentDtParameter = Parameter("@INCIDENT_DT", RIS_RISKINCIDENTS.INCIDENT_DT);

            DbParameter commentIdParameter;
            if (RIS_RISKINCIDENTS.COMMENT_ID == -1)
                commentIdParameter = Parameter("COMMENT_ID", DBNull.Value);
            else
                commentIdParameter = Parameter("@COMMENT_ID", RIS_RISKINCIDENTS.COMMENT_ID);
            
            DbParameter[] parameters = {
                                           Parameter("@INCIDENT_UID", RIS_RISKINCIDENTS.INCIDENT_UID),
                                           incidentDtParameter,
                                           Parameter("@RISK_CAT_ID", RIS_RISKINCIDENTS.RISK_CAT_ID),
                                           Parameter("@INCIDENT_SUBJ", RIS_RISKINCIDENTS.INCIDENT_SUBJ),
                                           Parameter("@INCIDENT_DESC", RIS_RISKINCIDENTS.INCIDENT_DESC),
                                           commentIdParameter,
                                           Parameter("@ORG_ID", RIS_RISKINCIDENTS.ORG_ID),
                                           Parameter("@CREATED_BY", RIS_RISKINCIDENTS.CREATED_BY),
                                           Parameter("@PRIORITY", RIS_RISKINCIDENTS.PRIORITY),
                                           Parameter("@REG_ID", RIS_RISKINCIDENTS.REG_ID),
                                           Parameter("@ORDER_ID", RIS_RISKINCIDENTS.ORDER_ID),
                                           Parameter("@SCHEDULE_ID", RIS_RISKINCIDENTS.SCHEDULE_ID),
                                           Parameter("@XRAYREQ_ID", RIS_RISKINCIDENTS.XRAYREQ_ID),
                                           Parameter("@INCIDENT_CHOOSED", RIS_RISKINCIDENTS.INCIDENT_CHOOSED),
                                       };
            return parameters;
        }
    }
}
