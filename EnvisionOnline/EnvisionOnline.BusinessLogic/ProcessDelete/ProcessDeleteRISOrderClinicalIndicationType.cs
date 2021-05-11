using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISOrderClinicalIndicationType: IBusinessLogic
    {
        
        public RIS_ORDERCLINICALINDICATIONTYPE RIS_ORDERCLINICALINDICATIONTYPE { get; set; }

        public ProcessDeleteRISOrderClinicalIndicationType()
        {
            RIS_ORDERCLINICALINDICATIONTYPE = new RIS_ORDERCLINICALINDICATIONTYPE();
        }

        public void Invoke()
        {

            RISOrderClinicalIndicationTypeDeleteData _proc = new RISOrderClinicalIndicationTypeDeleteData();
            _proc.RIS_ORDERCLINICALINDICATIONTYPE = RIS_ORDERCLINICALINDICATIONTYPE;
            _proc.Delete();
        }
    }
}
