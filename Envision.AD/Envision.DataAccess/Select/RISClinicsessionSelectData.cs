using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class RISClinicsessionSelectData : DataAccessBase 
	{
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }

		public  RISClinicsessionSelectData()
		{
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICSESSION_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetDataCNMI()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet2();
            return ds;
        }
        public DataSet GetScheduleSession() {

            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Session;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@MODALITY_ID",RIS_CLINICSESSION.MODALITY_ID),
                                          Parameter("@WEEKDAY",RIS_CLINICSESSION.WEEKDAYS),
                                          Parameter("@ORG_ID",RIS_CLINICSESSION.ORG_ID),
                                       };
            return parameters;
        }

        public DataSet GetDefaultClinicSessionByModality(int modality_id)
        {

            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SessionByModality;
            DataSet ds = new DataSet();
            ParameterList = buildParameterDefaultClinicSessionByModality(modality_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterDefaultClinicSessionByModality(int modality_id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@MODALITY_ID",modality_id),
                                       };
            return parameters;
        }
	}
}

