using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISModalitytype : IBusinessLogic
    {
        private DataSet result;
        private bool is_online;
        public ProcessGetRISModalitytype(bool IS_ONLINE) { is_online = IS_ONLINE; }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISModalitytypeSelectData _proc = new RISModalitytypeSelectData(is_online);
            result = _proc.GetData();
        }
    }
}

