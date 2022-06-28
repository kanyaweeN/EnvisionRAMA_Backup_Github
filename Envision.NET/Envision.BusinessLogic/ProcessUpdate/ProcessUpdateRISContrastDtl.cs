using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISContrastDtl : IBusinessLogic
    {
         public  RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }

         public ProcessUpdateRISContrastDtl()
        {
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
        }

        public void Invoke()
        {
            RISContrastDtlUpdateData _update = new RISContrastDtlUpdateData();
            _update.RIS_CONTRASTDTL = this.RIS_CONTRASTDTL;
            _update.Update();
        }
        public void updateArrival(int order_id, int schedule_id)
        {
            RISContrastDtlUpdateData _update = new RISContrastDtlUpdateData();
            _update.updateArrival(order_id,schedule_id);
        }
    }
}