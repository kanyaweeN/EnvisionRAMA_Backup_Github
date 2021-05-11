using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.DataAccess.Insert;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRisRiskCategorise : IBusinessLogic
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE { get; set; }

        public ProcessAddRisRiskCategorise()
        {
            this.RIS_RISKCATEGORISE = new RIS_RISKCATEGORISE();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RisRiskCategoriseInsert processor = new RisRiskCategoriseInsert();
            processor.RIS_RISKCATEGORISE = RIS_RISKCATEGORISE;
            processor.InsertData();
        }

        #endregion
    }
}
