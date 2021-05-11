using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLGeneralDtl : IBusinessLogic
    {
        public GBL_GENERALDTL GBL_GENERALDTL { get; set; }

        public ProcessDeleteGBLGeneralDtl()
        {
            GBL_GENERALDTL = new GBL_GENERALDTL();
        }
        public void Invoke()
        {
            GBLGeneralDtlDeleteData _proc = new GBLGeneralDtlDeleteData();
            _proc.GBL_GENERALDTL = GBL_GENERALDTL;
            _proc.Delete();
        }
    }
}
