using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISInsurancetype : IBusinessLogic
    {
        public RIS_INSURANCETYPE RIS_INSURANCETYPE { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddRISInsurancetype()
        {
            RIS_INSURANCETYPE = new RIS_INSURANCETYPE();
            Transaction = null;
        }
        public void Invoke()
        {
            RISInsurancetypeInsertData _proc = new RISInsurancetypeInsertData();
            _proc.RIS_INSURANCETYPE = this.RIS_INSURANCETYPE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
        }
    }
}
