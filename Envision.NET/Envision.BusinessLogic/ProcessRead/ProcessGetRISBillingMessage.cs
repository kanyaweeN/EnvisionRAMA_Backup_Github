using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISBillingMessage : IBusinessLogic
    {
        public string ACCESSION_NO { get; set; }
        public string CREATED_BY { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISBillingMessageSelect processor = new RISBillingMessageSelect();
            this.Result = processor.GetBillingMessage(this.ACCESSION_NO, this.CREATED_BY);
        }

        #endregion
    }
}
