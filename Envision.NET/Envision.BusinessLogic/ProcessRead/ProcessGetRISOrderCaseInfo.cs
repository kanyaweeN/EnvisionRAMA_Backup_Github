using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderCaseInfo : IBusinessLogic
    {
        public string ACCESSION_NO { get; set; }
        public int ORG_ID { get; set; }
        public DataSet Result { get; set; }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RISOrderSelectCaseInfo processor = new RISOrderSelectCaseInfo();
            this.Result = processor.GetData(this.ACCESSION_NO, this.ORG_ID);
        }

        #endregion
    }
}
