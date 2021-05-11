using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISOrderClinicalIndication: IBusinessLogic
    {
        
        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }

        public ProcessDeleteRISOrderClinicalIndication()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
        }

        public void Invoke()
        {

            RISOrderClinicalIndicationDeleteData _proc = new RISOrderClinicalIndicationDeleteData();
            _proc.RIS_ORDERCLINICALINDICATION = RIS_ORDERCLINICALINDICATION;
            _proc.Delete();
        }
    }
}
