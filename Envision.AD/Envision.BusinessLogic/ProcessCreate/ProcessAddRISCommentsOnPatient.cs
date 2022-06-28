using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.DataAccess.Insert;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISCommentsOnPatient : IBusinessLogic
    {
        public RIS_COMMENTSONPATIENT RIS_COMMENTSONPATIENT { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISCommentsOnPatient()
        {
            this.RIS_COMMENTSONPATIENT = new RIS_COMMENTSONPATIENT();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_COMMENTSONPATIENT_INSERT processor = new RIS_COMMENTSONPATIENT_INSERT();
            processor.RIS_COMMENTSONPATIENT = this.RIS_COMMENTSONPATIENT;
            if (this.Transaction == null)
                processor.InsertMasterComment();
            else
                processor.InsertMasterComment(this.Transaction);
        }

        #endregion
    }
}
