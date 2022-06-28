using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessMGGetDemographic : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public string AccessionNo { get; set; }


        #region IBusinessLogic Members

        public void Invoke()
        {
            MGGetDemographic processor = new MGGetDemographic();
            this.Result = processor.GetData(this.AccessionNo);
        }

        #endregion
    }
}
