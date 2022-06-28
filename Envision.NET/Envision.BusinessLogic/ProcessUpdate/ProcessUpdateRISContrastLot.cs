using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISContrastLot
    {
        public RIS_CONTRASTLOT RIS_CONTRASTLOT { get; set; }

        public ProcessUpdateRISContrastLot()
        {
            RIS_CONTRASTLOT = new RIS_CONTRASTLOT();
        }

        public void Invoke()
        {
            RISContrastLotUpdateData _update = new RISContrastLotUpdateData();
            _update.RIS_CONTRASTLOT = this.RIS_CONTRASTLOT;
            _update.UpdateData();
        }
    }
}
