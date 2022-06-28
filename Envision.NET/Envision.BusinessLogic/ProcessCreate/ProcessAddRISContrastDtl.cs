using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISContrastDtl : IBusinessLogic
    {
        public RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }
        public int GetID { get; set; }
        public ProcessAddRISContrastDtl()
        {
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
        }

        public void Invoke()
        {
            RISContrastDtlInsertData _proc = new RISContrastDtlInsertData();
            _proc.RIS_CONTRASTDTL = this.RIS_CONTRASTDTL;

            _proc.Add();
            GetID = _proc.GetID();
        }

    }
}
