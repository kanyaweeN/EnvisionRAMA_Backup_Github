using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class DistributionNewSelect : DataAccessBase
    {
        private DistributionNew _worklist;
        private DistributionNewSelectParameters _distributionNewselectparameters;

        public DistributionNewSelect()
            {
                StoredProcedureName = StoredProcedure.Name.Prc_DistributionNew_select.ToString();
                _worklist = new DistributionNew();
            }

            public DataSet Get()
            {
                DataSet ds;
                _distributionNewselectparameters = new DistributionNewSelectParameters(_worklist);
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                ds = dbhelper.Run(base.ConnectionString, _distributionNewselectparameters.Parameters);
                return ds;

            }

        public DistributionNew DistributionNew
            {
                get { return _worklist; }
                set { _worklist = value; }
            }
        }

    public class DistributionNewSelectParameters
        {
            private DistributionNew _worklist;
            private SqlParameter[] _parameters;

            public DistributionNewSelectParameters(DistributionNew worklist)
            {
                _worklist = worklist;
                Build();
            }

            private void Build()
            {
                //datefrom
                SqlParameter datefrom = new SqlParameter();
                datefrom.ParameterName = "@datefrom";
                if (_worklist.datefrom == DateTime.MinValue)
                {
                    datefrom.Value = DBNull.Value;
                }
                else
                {
                    datefrom.Value = _worklist.datefrom;
                }

                //todate
                SqlParameter todate = new SqlParameter();
                todate.ParameterName = "@todate";
                if (_worklist.todate == DateTime.MinValue)
                {
                    todate.Value = DBNull.Value;
                }
                else
                {
                    todate.Value = _worklist.todate;
                }

                SqlParameter[] parameters =
		    {
                new SqlParameter( "@selectcase"     ,_worklist.selectcase),
                datefrom,
                todate,
                new SqlParameter( "@assignname"     ,_worklist.assignname),
				new SqlParameter( "@accessionno"    ,_worklist.accessionno),
                new SqlParameter( "@hn"             ,_worklist.hn),
                new SqlParameter( "@empid"          ,_worklist.EMP_ID)
                				
		    };

                Parameters = parameters;
            }


            public SqlParameter[] Parameters
            {
                get { return _parameters; }
                set { _parameters = value; }
            }
    }
}
