using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RisRiskIncidentsDelete : DataAccessBase
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }
        public RisRiskIncidentsDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_DELETE;
        }
        public void DeleteData()
        {
            ParameterList = this.BuildParameters();
            ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("@INCIDENT_ID", RIS_RISKINCIDENTS.INCIDENT_ID)
                                       };
            return parameters;
        }
        public void DeleteRegID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_DELETEbyREG_ID;
            ParameterList = this.BuildParametersDeleteRegID();
            ExecuteNonQuery();
        }
        private DbParameter[] BuildParametersDeleteRegID()
        {
            DbParameter[] parameters = {
                                           Parameter("@REG_ID", RIS_RISKINCIDENTS.REG_ID)
                                       };
            return parameters;
        }

        public void DeleteScheduleID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_DELETEbyScheduleID;
            ParameterList = this.BuildParametersDeleteScheduleID();
            ExecuteNonQuery();
        }
        private DbParameter[] BuildParametersDeleteScheduleID()
        {
            DbParameter[] parameters = {
                                           Parameter("@SCHEDULE_ID", RIS_RISKINCIDENTS.SCHEDULE_ID)
                                       };
            return parameters;
        }
        public void DeleteOrderID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_DELETEbyOrderID;
            ParameterList = this.BuildParametersDeleteOrderID();
            ExecuteNonQuery();
        }
        private DbParameter[] BuildParametersDeleteOrderID()
        {
            DbParameter[] parameters = {
                                           Parameter("@ORDER_ID", RIS_RISKINCIDENTS.ORDER_ID)
                                       };
            return parameters;
        }
        public void DeleteXrayreqID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_DELETEbyXrayreqID;
            ParameterList = this.BuildParametersDeleteXrayreqID();
            ExecuteNonQuery();
        }
        private DbParameter[] BuildParametersDeleteXrayreqID()
        {
            DbParameter[] parameters = {
                                           Parameter("@XRAYREQ_ID", RIS_RISKINCIDENTS.XRAYREQ_ID)
                                       };
            return parameters;
        }
    }
}
