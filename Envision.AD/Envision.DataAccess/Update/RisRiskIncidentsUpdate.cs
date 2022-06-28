using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RisRiskIncidentsUpdate : DataAccessBase
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public RisRiskIncidentsUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_UPDATE;
        }
        public void UpdateData(DbTransaction tran)
        {
            Transaction = tran;
            UpdateData();
        }
        public void UpdateData()
        {
            ParameterList = this.BuildParameters();
            ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            //DbParameter incidentDtParameter;
            //if (RIS_RISKINCIDENTS.INCIDENT_DT == DateTime.MinValue)
            //    incidentDtParameter = Parameter("@INCIDENT_DT", DBNull.Value);
            //else
            //    incidentDtParameter = Parameter("@INCIDENT_DT", RIS_RISKINCIDENTS.INCIDENT_DT);
            
            DbParameter[] parameters = {
                                           Parameter("@INCIDENT_UID", RIS_RISKINCIDENTS.INCIDENT_UID),
                                           //incidentDtParameter,
                                           Parameter("@RISK_CAT_ID", RIS_RISKINCIDENTS.RISK_CAT_ID),
                                           Parameter("@INCIDENT_SUBJ", RIS_RISKINCIDENTS.INCIDENT_SUBJ),
                                           Parameter("@INCIDENT_DESC", RIS_RISKINCIDENTS.INCIDENT_DESC),
                                           //Parameter("@COMMENT_ID", RIS_RISKINCIDENTS.COMMENT_ID),
                                           Parameter("@ORG_ID", RIS_RISKINCIDENTS.ORG_ID),
                                           Parameter("@LAST_MODIFIED_BY", RIS_RISKINCIDENTS.LAST_MODIFIED_BY),
                                           Parameter("@INCIDENT_ID", RIS_RISKINCIDENTS.INCIDENT_ID),
                                           Parameter("@PRIORITY", RIS_RISKINCIDENTS.PRIORITY)
                                       };
            return parameters;
        }
        public void UpdateOrderIdByScheduleId(DbTransaction tran)
        {
            Transaction = tran;
            UpdateOrderIdByScheduleId();
        }
        public void UpdateOrderIdByScheduleId()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_UpdateOrderIdByScheduleId;
            DbParameter[] parameters = {
                                           Parameter("@SCHEDULE_ID", RIS_RISKINCIDENTS.SCHEDULE_ID),
                                           Parameter("@ORG_ID", RIS_RISKINCIDENTS.ORG_ID),
                                           Parameter("@LAST_MODIFIED_BY", RIS_RISKINCIDENTS.LAST_MODIFIED_BY),
                                           Parameter("@ORDER_ID", RIS_RISKINCIDENTS.ORDER_ID),
                                       };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}
