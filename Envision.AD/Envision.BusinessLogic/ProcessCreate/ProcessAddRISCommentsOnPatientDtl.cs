using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISCommentsOnPatientDtl : IBusinessLogic
    {
        public RIS_COMMENTSONPATIENTDTL RIS_COMMENTSONPATINETDTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISCommentsOnPatientDtl()
        {
            this.RIS_COMMENTSONPATINETDTL = new RIS_COMMENTSONPATIENTDTL();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_COMMENTSONPATIENTDTL_INSERT processor = new RIS_COMMENTSONPATIENTDTL_INSERT();
            processor.RIS_COMMENTSONPATIENTDTL = this.RIS_COMMENTSONPATINETDTL;
            if (this.Transaction == null)
                processor.InsertDetailComment();
            else
                processor.InsertDetailComment(this.Transaction);
        }

        #endregion
    }
}
