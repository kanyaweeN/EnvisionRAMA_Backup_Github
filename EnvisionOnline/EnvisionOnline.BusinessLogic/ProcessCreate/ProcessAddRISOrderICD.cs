using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderICD: IBusinessLogic
    {
        
        public RIS_ORDERICD RIS_ORDERICD { get; set; }
        public ProcessAddRISOrderICD()
        {
            RIS_ORDERICD = new RIS_ORDERICD();
        }

        public void Invoke()
        {
            RISOrderICDInsertData add = new RISOrderICDInsertData();
            add.RIS_ORDERICD = RIS_ORDERICD;
            add.Add();
        }
    }
}
