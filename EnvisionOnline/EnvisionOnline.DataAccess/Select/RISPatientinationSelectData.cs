using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISPatientinationSelectData : DataAccessBase
    {
        public RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
        public RISPatientinationSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PATIENTDESTINATION_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ORG_ID"	, 1  )
                                       };
            return parameters;
        }
        public DataSet getDataMapping(int unit_id,int clinic_type_id)
        {
            DataSet ds = new DataSet();

            StoredProcedureName = StoredProcedure.Prc_ONL_FILTERDESTINATION_Select;
            ParameterList = buildParameterDataMapping(unit_id, clinic_type_id);
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getFlagCTMR(int pat_dest_id)
        {
            DataSet ds = new DataSet();

            StoredProcedureName = StoredProcedure.Prc_ONL_FILTERDESTINATION_CheckCTMR;
            ParameterList = buildParameterGetFlagCTMR(pat_dest_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterDataMapping(int unit_id, int clinic_type_id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@UNIT_ID"	, unit_id  ),
                                          Parameter("@CLINIC_TYPE_ID"	, clinic_type_id  ),
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterGetFlagCTMR(int pat_dest_id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@PAT_DEST_ID"	, pat_dest_id  )
                                       };
            return parameters;
        }
    }
}
