using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRisvPatienDate : IBusinessLogic
    {
        DataSet _ds;
        DateTime _dt1;
        DateTime _dt2;

        public ProcessGetRisvPatienDate()
        { 
            
        }

        public void Invoke()
        {
            RisvPatienSelectDataDate risv = new RisvPatienSelectDataDate();
            risv.DateTime1 = DateTime1;
            risv.DateTime2 = DateTime2;
            DataResult = risv.Get();
        }

        public DataSet DataResult
        {
            get { return _ds; }
            set { _ds = value; }
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

        public DataTable GetReportDuration(DateTime DtStart, DateTime DtEnd)
        {
            RisvPatienSelectDataDate risv = new RisvPatienSelectDataDate();
            DataTable dtt = risv.GetReportDuration(DtStart, DtEnd);
            return dtt;
        }
    }
}
