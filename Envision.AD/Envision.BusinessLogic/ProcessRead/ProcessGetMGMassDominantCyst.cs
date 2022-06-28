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
    public class ProcessGetMGMassDominantCyst : IBusinessLogic
    {
        public MG_DOMINANT MG_MASSDOMINANTCYST { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetMGMassDominantCyst()
        {
            this.MG_MASSDOMINANTCYST = new MG_DOMINANT();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGDominantSelect processor = new MGDominantSelect();
            processor.MG_DOMINANT = this.MG_MASSDOMINANTCYST;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
