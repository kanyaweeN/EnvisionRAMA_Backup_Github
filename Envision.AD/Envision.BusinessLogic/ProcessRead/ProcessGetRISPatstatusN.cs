using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPatstatusN : IBusinessLogic
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        private DataSet _resultset;

        public ProcessGetRISPatstatusN()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
        }

        public void Invoke()
        {

            RISPatstatusSeleteDataN patstatus = new RISPatstatusSeleteDataN();
            patstatus.RIS_PATSTATUS = this.RIS_PATSTATUS;
            ResultSet = patstatus.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
