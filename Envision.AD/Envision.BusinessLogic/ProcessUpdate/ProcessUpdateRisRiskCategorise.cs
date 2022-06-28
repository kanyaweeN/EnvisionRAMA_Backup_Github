using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.DataAccess.Update;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRisRiskCategorise : IBusinessLogic
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE { get; set; }

        public ProcessUpdateRisRiskCategorise()
        {
            this.RIS_RISKCATEGORISE = new RIS_RISKCATEGORISE();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskCategoriseUpdate processor = new RisRiskCategoriseUpdate();
            processor.RIS_RISKCATEGORISE = RIS_RISKCATEGORISE;
            processor.UpdateData();
        }

        #endregion
    }
}
