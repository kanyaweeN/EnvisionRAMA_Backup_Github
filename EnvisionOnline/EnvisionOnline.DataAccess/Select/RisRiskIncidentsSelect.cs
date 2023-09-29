using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RisRiskIncidentsSelect : DataAccessBase
    {
        public RIS_RISKINCIDENTS RIS_RISKINCIDENTS { get; set; }

        public RisRiskIncidentsSelect()
        {
            RIS_RISKINCIDENTS = new RIS_RISKINCIDENTS();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_SELECT;
        }
        public DataSet GetData(int mode, DateTime from, DateTime to)
        {
            DataSet ds = new DataSet();
            ParameterList = this.BuildParameters(mode, from, to);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] BuildParameters(int mode, DateTime fromDt, DateTime toDt)
        {
            DbParameter fromDtParameter;
            if (fromDt == DateTime.MinValue)
                fromDtParameter = Parameter("@FROM_DT", DBNull.Value);
            else
                fromDtParameter = Parameter("@FROM_DT", fromDt);

            DbParameter toDtParameter;
            if (toDt == DateTime.MinValue)
                toDtParameter = Parameter("@TO_DT", DBNull.Value);
            else
                toDtParameter = Parameter("@TO_DT", toDt);

            DbParameter[] parameters = {
                                           Parameter("@ORG_ID", RIS_RISKINCIDENTS.ORG_ID),
                                           Parameter("@INCIDENT_ID", RIS_RISKINCIDENTS.INCIDENT_ID),
                                           Parameter("@MODE", mode),
                                           fromDtParameter,
                                           toDtParameter
                                       };
            return parameters;
        }

        public DataTable getDataByRegID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_SELECTbyREG_ID;
            ParameterList = this.BuildParametersByRegID();
            return ExecuteDataTable();
        }
        private DbParameter[] BuildParametersByRegID()
        {

            DbParameter[] parameters = {
                                           Parameter("@REG_ID", RIS_RISKINCIDENTS.REG_ID),
                                       };
            return parameters;
        }
        public DataTable getDataByScheduleID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_SELECTbyScheduleID;
            ParameterList = this.BuildParametersByScheduleID();
            return ExecuteDataTable();
        }
        public DataTable getDataByXrayReqID()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTS_SELECTbyXRAYREQID;
            ParameterList = this.BuildParametersByXrayreqID();
            return ExecuteDataTable();
        }
        private DbParameter[] BuildParametersByScheduleID()
        {

            DbParameter[] parameters = {
                                           Parameter("@SCHEDULE_ID", RIS_RISKINCIDENTS.SCHEDULE_ID),
                                       };
            return parameters;
        }
        private DbParameter[] BuildParametersByXrayreqID()
        {

            DbParameter[] parameters = {
                                           Parameter("@XRAYREQ_ID", RIS_RISKINCIDENTS.XRAYREQ_ID),
                                       };
            return parameters;
        }
    }
}
