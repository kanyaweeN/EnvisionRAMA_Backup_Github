using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPatientDestination : IBusinessLogic
    {
        public RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetRISPatientDestination()
        {
            this.RIS_PATIENTDESTINATION = new RIS_PATIENTDESTINATION();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RISPatientDestinationSelect processor = new RISPatientDestinationSelect();
            processor.RIS_PATIENTDESTINATION = this.RIS_PATIENTDESTINATION;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
