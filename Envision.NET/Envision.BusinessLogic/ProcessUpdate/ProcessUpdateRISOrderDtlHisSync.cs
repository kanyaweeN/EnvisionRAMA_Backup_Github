using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISOrderDtlHisSync : IBusinessLogic
    {
        public string ACCESSION_NO { get; set; }
        public string HIS_ACK { get; set; }
        public string HIS_SYNC { get; set; }
        public int ORG_ID { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISOrderDtlUpateHISSync processor = new RISOrderDtlUpateHISSync();
            processor.UpdateHisSync(this.ACCESSION_NO, this.HIS_SYNC, this.HIS_ACK, this.ORG_ID);
        }

        #endregion
    }
}
