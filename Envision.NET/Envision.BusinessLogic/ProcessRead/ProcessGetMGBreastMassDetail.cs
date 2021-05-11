using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGBreastMassDetail : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }

        public ProcessGetMGBreastMassDetail()
        {
            this.MG_BREASTMASSDETAILS = new MG_BREASTMASSDETAILS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMassDetailSelect processor = new MGBreastMassDetailSelect();
            processor.MG_BREASTMASSDETAILS = this.MG_BREASTMASSDETAILS;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
