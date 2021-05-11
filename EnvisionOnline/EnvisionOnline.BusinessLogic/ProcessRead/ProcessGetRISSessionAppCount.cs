using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISSessionAppCount : IBusinessLogic
    {
        private DataSet result;
        private string Query;
        private DateTime DateStart,DateEnd;
        public ProcessGetRISSessionAppCount(string query, DateTime date_start, DateTime date_end)
        {
            Query = query;
            DateStart = date_start;
            DateEnd = date_end;
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISSessionAppCountSelectData _proc = new RISSessionAppCountSelectData();
            result = _proc.GetData(Query,DateStart,DateEnd);
        }
    }
}
