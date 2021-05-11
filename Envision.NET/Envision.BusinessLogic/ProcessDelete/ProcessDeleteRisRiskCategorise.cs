using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.DataAccess.Delete;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRisRiskCategorise : IBusinessLogic
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE { get; set; }

        public ProcessDeleteRisRiskCategorise()
        {
            this.RIS_RISKCATEGORISE = new RIS_RISKCATEGORISE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskCategoriseDelete processor = new RisRiskCategoriseDelete();
            processor.RIS_RISKCATEGORISE = RIS_RISKCATEGORISE;
            processor.DeleteData();
        }

        #endregion
    }
}
