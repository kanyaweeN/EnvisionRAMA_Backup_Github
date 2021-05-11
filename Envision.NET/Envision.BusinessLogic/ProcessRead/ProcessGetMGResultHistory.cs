using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGResultHistory : IBusinessLogic
    {
        public int RegId { get; set; }
        public DataSet Result { get; set; }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGResultHistorySelect processor = new MGResultHistorySelect();
            this.Result = processor.GetData(this.RegId);
        }

        #endregion
    }
}
