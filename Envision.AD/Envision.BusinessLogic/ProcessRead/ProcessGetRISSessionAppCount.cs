using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISSessionAppCount : IBusinessLogic
    {
        private DataSet _resultset;
        public RIS_SESSIONAPPCOUNT RIS_SESSIONAPPCOUNT { get; set; }

        public ProcessGetRISSessionAppCount()
        {
            RIS_SESSIONAPPCOUNT = new RIS_SESSIONAPPCOUNT();
        }

        public void Invoke()
        {
            RISSessionAppCountSelectData getData = new RISSessionAppCountSelectData();
            getData.RIS_SESSIONAPPCOUNT = this.RIS_SESSIONAPPCOUNT;
            ResultSet = getData.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
