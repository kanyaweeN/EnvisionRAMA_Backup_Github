using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class HISRegistrationSelectData : DataAccessBase
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        private int action = 0;

        public HISRegistrationSelectData()
        {
            action = 0;
            HIS_REGISTRATION = new HIS_REGISTRATION();
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_Select;
        }
        public HISRegistrationSelectData(bool getDataFromHIS)
        {
            if (getDataFromHIS)
            {
                action = 1;
                HIS_REGISTRATION = new HIS_REGISTRATION();
                StoredProcedureName = StoredProcedure.Prc_HIS_SelectFromHIS;
            }
            else
            {
                action = 0;
                HIS_REGISTRATION = new HIS_REGISTRATION();
                StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_Select;
            }
        }

        public DataSet GetData()
        {
            if (action == 0)
                ParameterList = buildParameter();
            else
                ParameterList = buildParameterHIS();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataAll()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_SelectAll;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataLastRecord()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HIS_REGISTRATION_Select_LastRecord;
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@REG_ID",HIS_REGISTRATION.REG_ID)
                                                    , Parameter("@HN",HIS_REGISTRATION.HN)
                                                    //, Parameter("@ORG_ID", 1)//HIS_REGISTRATION.ORG_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterHIS()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@HN",HIS_REGISTRATION.HN)
                                       };
            return parameters;
        }
    }
}
