using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionInterface.DataAccess.Select;

namespace EnvisionInterface.BusinessLogic.ProcessRead
{
    public class ProcessGetMammoICheckup 
    {
        private DataSet result;

        public ProcessGetMammoICheckup()
        {
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void getData(string hn, string enc_id, string enc_type)
        {
            RISMammoICheckupSelectData _proc = new RISMammoICheckupSelectData();
            result = _proc.GetData(hn, enc_id, enc_type);
        }
        public void getDataByDate(string Result_Date)
        {
            RISMammoICheckupSelectData _proc = new RISMammoICheckupSelectData();
            result = _proc.GetDataByDate(Result_Date);
        }
    }
}
