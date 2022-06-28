using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGBreastMark : IBusinessLogic
    {
        public string AccessionNo { get; set; }
        public int OrgId { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastMarkSelect processor = new MGBreastMarkSelect();
            this.Result = processor.GetData(this.AccessionNo, this.OrgId);
        }

        #endregion
    }
}
