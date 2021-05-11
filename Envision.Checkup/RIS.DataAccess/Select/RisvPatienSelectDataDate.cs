using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Select
{
    public class RisvPatienSelectDataDate :DataAccessBase
    {
        DataSet _ds;
        DateTime _dt1;
        DateTime _dt2;

        public RisvPatienSelectDataDate()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Risv_Patien_SelectDataDate.ToString();
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            RisvPatienSelectDataDateParameter risv = new RisvPatienSelectDataDateParameter(DateTime1, DateTime2);
            DataBaseHelper dbhelp = new DataBaseHelper(StoredProcedureName);
            ds = dbhelp.Run(base.ConnectionString, risv.Parameters);

            return ds;
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
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_REPORT_DURATION.ToString();
            RisvPatienSelectDataDateParameter risv = new RisvPatienSelectDataDateParameter(dtStart, dtEnd, true);
            DataBaseHelper dbhelp = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelp.Run(base.ConnectionString, risv.Parameters);
            DataTable dtt = ds.Tables[0];
            return dtt;
        }
    }

    public class RisvPatienSelectDataDateParameter
    {
        SqlParameter[] _parameters;

        public RisvPatienSelectDataDateParameter(DateTime _dt1, DateTime _dt2)
        {
            SqlParameter[] parameters = 
            {
                new SqlParameter(   "@FROM_DATE"   ,    _dt1   ),
                new SqlParameter(   "@TO_DATE"     ,    _dt2   )
            };

            Parameters = parameters;
        }
        public RisvPatienSelectDataDateParameter(DateTime _dt1, DateTime _dt2,bool BuildDuration)
        {
            SqlParameter[] parameters;
            if (BuildDuration)
                parameters = new SqlParameter[] { new SqlParameter("@dtStart", _dt1), new SqlParameter("@dtEnd", _dt2) };
            else
                parameters = new SqlParameter[] { new SqlParameter("@FROM_DATE", _dt1), new SqlParameter("@TO_DATE", _dt2) };
            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
