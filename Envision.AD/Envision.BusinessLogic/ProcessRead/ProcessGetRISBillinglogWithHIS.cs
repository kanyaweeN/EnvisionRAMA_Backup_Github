using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISBillinglogWithHIS : IBusinessLogic
    {
        public RIS_BILLINGLOG_WITH_HIS RIS_BILLINGLOG_WITH_HIS { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetRISBillinglogWithHIS(){
            RIS_BILLINGLOG_WITH_HIS = new RIS_BILLINGLOG_WITH_HIS();
        }
        public void Invoke()
        {
            RISBillinglogWithHISSelectData process = new RISBillinglogWithHISSelectData();
            process.RIS_BILLINGLOG_WITH_HIS = this.RIS_BILLINGLOG_WITH_HIS;
            Result = process.GetData();
        }
    }
}
