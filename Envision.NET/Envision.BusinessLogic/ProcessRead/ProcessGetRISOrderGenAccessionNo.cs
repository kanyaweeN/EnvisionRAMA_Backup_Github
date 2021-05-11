using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderGenAccessionNo : IBusinessLogic
    {
        public int MODALITY_ID { get; set; }
        public int REF_UNIT_ID { get; set; }
        public string ACCESSION_ON { get; set; }
        public DbTransaction Transaction { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISOrderGetAcceessionNo processor = new RISOrderGetAcceessionNo();
            if (this.Transaction != null)
                processor.Transaction = this.Transaction; 
            this.ACCESSION_ON = processor.GetAccessoionNo(this.MODALITY_ID, this.REF_UNIT_ID);
        }

        #endregion
    }
}
