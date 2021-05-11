using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class DistributionNewUpdateData : DataAccessBase
    {
        private DistributionNew _distributionnew;
        private DistributionNewUpdateDataParameters _distributionnewupdatedataparameters;

        public DistributionNewUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_DistributionNew_Update.ToString();
        }
        public DistributionNew DistributionNew
        {
            get { return _distributionnew; }
            set { _distributionnew = value; }
        }
        public void Update()
        {
            _distributionnewupdatedataparameters = new DistributionNewUpdateDataParameters(DistributionNew);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _distributionnewupdatedataparameters.Parameters);
        }


    }
    public class DistributionNewUpdateDataParameters
    {
        private DistributionNew _distributionnew;
        private SqlParameter[] _parameters;

        public DistributionNewUpdateDataParameters(DistributionNew distributionnew)
        {
            DistributionNew = distributionnew;
            Build();
        }
        private void Build()
        {
            SqlParameter assigned_to = new SqlParameter();
            assigned_to.ParameterName = "@assigned_to";
            if (_distributionnew.assignedTo == 0)
            {
                assigned_to.Value = DBNull.Value;
            }
            else
            {
                assigned_to.Value = _distributionnew.assignedTo;
            }
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@accession_no"         ,  _distributionnew.accessionno  ),
                assigned_to,
                new SqlParameter( "@last_modified_by"     ,  _distributionnew.LAST_MODIFIED_BY),
                new SqlParameter("@priority",_distributionnew.PRIORITY),
                
			};

            Parameters = parameters;
        }

        public DistributionNew DistributionNew
        {
            get { return _distributionnew; }
            set { _distributionnew = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
