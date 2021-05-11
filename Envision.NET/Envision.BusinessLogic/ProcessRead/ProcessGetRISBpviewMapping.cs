using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISBpviewMapping: IBusinessLogic
    {
        private DataSet _resultset;
        public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }

        public ProcessGetRISBpviewMapping()
        {
            RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
        }

        public void Invoke()
        {
            RISBpviewMappingSelectData bpMapping = new RISBpviewMappingSelectData();
            bpMapping.RIS_BPVIEWMAPPING = this.RIS_BPVIEWMAPPING;
            ResultSet = bpMapping.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
