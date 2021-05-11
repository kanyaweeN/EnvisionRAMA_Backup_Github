using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISPatstatusN : IBusinessLogic
    {
        private DataSet _resultset;
        private RISPatstatus _rispatstatus;

        public ProcessGetRISPatstatusN()
        {
            _rispatstatus = new RISPatstatus();
        }

        public void Invoke()
        {

            RISPatstatusSeleteDataN patstatus = new RISPatstatusSeleteDataN();
            patstatus.RISPatstatus = this.RISPatstatus;
            ResultSet = patstatus.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public RISPatstatus RISPatstatus
        {
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
        }
    }
}
