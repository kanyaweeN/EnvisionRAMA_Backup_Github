using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class DistributionNewSelect : DataAccessBase
    {
            public DistributionNew DistributionNew { get; set; }

            public DistributionNewSelect()
            {
                StoredProcedureName = StoredProcedure.Prc_DistributionNew_select;
                DistributionNew = new DistributionNew();
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
                //datefrom
                DbParameter datefrom =  Parameter();
                datefrom.ParameterName = "@datefrom";
                if (DistributionNew.datefrom == DateTime.MinValue)
                {
                    datefrom.Value = DBNull.Value;
                }
                else
                {
                    datefrom.Value = DistributionNew.datefrom;
                }

                //todate
                DbParameter todate =  Parameter();
                todate.ParameterName = "@todate";
                if (DistributionNew.todate == DateTime.MinValue)
                {
                    todate.Value = DBNull.Value;
                }
                else
                {
                    todate.Value = DistributionNew.todate;
                }
                DbParameter[] parameters = { 
                                                Parameter( "@selectcase"     ,DistributionNew.selectcase),
                                                datefrom,
                                                todate,
                                                Parameter( "@assignname"     ,DistributionNew.assignname),
				                                Parameter( "@accessionno"    ,DistributionNew.accessionno),
                                                Parameter( "@hn"             ,DistributionNew.hn),
                                                Parameter( "@empid"          ,DistributionNew.EMP_ID)
                                       };
                return parameters;
            }
    }
}
