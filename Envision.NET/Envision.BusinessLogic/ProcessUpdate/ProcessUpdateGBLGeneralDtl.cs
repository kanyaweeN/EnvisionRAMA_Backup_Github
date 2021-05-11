using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLGeneralDtl: IBusinessLogic
    {
        public GBL_GENERALDTL GBL_GENERALDTL { get; set; }

        public ProcessUpdateGBLGeneralDtl()
        {
            GBL_GENERALDTL = new GBL_GENERALDTL();
        }

        public void Invoke()
        {
            GBLGeneralDtlUpdateData upData = new GBLGeneralDtlUpdateData();
            upData.GBL_GENERALDTL = this.GBL_GENERALDTL;
            upData.Add();

        }
    }
}
