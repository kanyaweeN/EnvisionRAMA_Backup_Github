using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RisvPatienSelectDataDate :DataAccessBase
    {
        DataSet _ds;
        DateTime _dt1;
        DateTime _dt2;

        public RisvPatienSelectDataDate()
        {
            StoredProcedureName = StoredProcedure.Prc_Risv_Patien_SelectDataDate;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(DateTime1, DateTime2);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(DateTime _dt1, DateTime _dt2)
        {
            DbParameter[] parameters ={			
                Parameter(   "@FROM_DATE"   ,    _dt1   ),
                Parameter(   "@TO_DATE"     ,    _dt2   )
			};
            return parameters;
        }

        public DateTime DateTime1
        {
            get { return _dt1; }
            set { _dt1 = value; }
        }

        public DateTime DateTime2
        {
            get { return _dt2; }
            set { _dt2 = value; }
        }

        public DataTable GetReportDuration(DateTime dtStart,DateTime dtEnd) {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_REPORT_DURATION;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_ReportDuration(dtStart, dtEnd, true); 
            ds = ExecuteDataSet();
            return ds.Tables[0];
        }
        private DbParameter[] buildParameter_ReportDuration(DateTime _dt1, DateTime _dt2, bool BuildDuration)
        {
            if (BuildDuration)
            {
                DbParameter[] parameters1 ={			
                Parameter(   "@dtStart"   ,    _dt1   ),
                Parameter(   "@dtEnd"     ,    _dt2   )
                        };
                return parameters1;
            }
            else
            {
                DbParameter[] parameters2 ={			
                        Parameter("@FROM_DATE", _dt1)
                        , Parameter("@TO_DATE", _dt2)
                        };
                return parameters2;
            }
        }
    }
}
