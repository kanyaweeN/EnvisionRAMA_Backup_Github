using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPatientPreparation : IBusinessLogic
    {
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISPatientPreparationSelect processor = new RISPatientPreparationSelect();
            this.Result = processor.GetData();
        }

        #endregion
    }
}
