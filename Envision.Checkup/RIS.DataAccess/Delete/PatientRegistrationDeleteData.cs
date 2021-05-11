using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Delete
{
    public class PatientRegistrationDeleteData : DataAccessBase
    {
        HISRegistration _hisreg;

        public PatientRegistrationDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Patient_Registration_Delete.ToString();
        }

        public void Delete()
        {
            PatientRegistrationDeleteDataParameter parameters = new PatientRegistrationDeleteDataParameter(HISRegistration);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.RunScalar(this.ConnectionString, parameters.SqlParameter);
        }

        public HISRegistration HISRegistration
        {
            get { return _hisreg; }
            set { _hisreg = value; }
        }
    }

    public class PatientRegistrationDeleteDataParameter
    {
        HISRegistration _hisreg;
        SqlParameter[] _parameters;

        public PatientRegistrationDeleteDataParameter(HISRegistration hisreg)
        {
            _hisreg = hisreg;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {
                                             new SqlParameter("@REG_ID",_hisreg.REG_ID),
                                        };
            SqlParameter = parameters;
        }

        public SqlParameter[] SqlParameter
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}