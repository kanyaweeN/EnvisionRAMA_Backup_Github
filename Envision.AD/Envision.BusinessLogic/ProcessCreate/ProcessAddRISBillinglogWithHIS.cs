using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISBillinglogWithHIS : IBusinessLogic
    {
        public RIS_BILLINGLOG_WITH_HIS RIS_BILLINGLOG_WITH_HIS { get; set; }

        public ProcessAddRISBillinglogWithHIS()
        {
            RIS_BILLINGLOG_WITH_HIS = new RIS_BILLINGLOG_WITH_HIS();
        }
        public void Invoke()
        {
            RISBillinglogWithHISInsertData _proc = new RISBillinglogWithHISInsertData();
            _proc.RIS_BILLINGLOG_WITH_HIS = this.RIS_BILLINGLOG_WITH_HIS;
            _proc.Add();
        }
        public void insertLogByHIS()
        {
            RISBillinglogWithHISInsertData _proc = new RISBillinglogWithHISInsertData();
            _proc.RIS_BILLINGLOG_WITH_HIS = this.RIS_BILLINGLOG_WITH_HIS;
            _proc.insertLogByHIS();
        }
        public void insertLogByHISErrorClinic()
        {
            RISBillinglogWithHISInsertData _proc = new RISBillinglogWithHISInsertData();
            _proc.RIS_BILLINGLOG_WITH_HIS = this.RIS_BILLINGLOG_WITH_HIS;
            _proc.insertLogByHISErrorClinic();
        }
    }
}

