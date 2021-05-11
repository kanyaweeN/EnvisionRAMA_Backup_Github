using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class PatientRegistrationSelectData : DataAccessBase
    {
        HISRegistration _hisRegistration;

        public PatientRegistrationSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Patient_Registration_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet dataset = new DataSet();
            PatientRegistrationSelectDataParameters parameters = new PatientRegistrationSelectDataParameters(HISRegistration);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dataset = dbhelper.Run(this.ConnectionString, parameters.SqlParameters);
            return dataset;
        }

        public HISRegistration HISRegistration
        {
            get { return _hisRegistration; }
            set { _hisRegistration = value; }
        }
    }

    public class PatientRegistrationSelectDataParameters
    {
        SqlParameter[] _sqlParameters;
        HISRegistration _hisRegistration;

        public PatientRegistrationSelectDataParameters(HISRegistration hisRegistration)
        {
            _hisRegistration = hisRegistration;
            Build();
        }

        private void Build()
        {
            SqlParameter[] sqlparameters =  {
                                                new SqlParameter("@REG_ID",HISRegistration.REG_ID),
                                                new SqlParameter("@HN",HISRegistration.HN),
                                            };
            SqlParameters = sqlparameters;
        }

        public SqlParameter[] SqlParameters
        {
            get { return _sqlParameters; }
            set { _sqlParameters = value; }
        }

        public HISRegistration HISRegistration
        {
            get { return _hisRegistration; }
            set { _hisRegistration = value; }
        }
    }
}
