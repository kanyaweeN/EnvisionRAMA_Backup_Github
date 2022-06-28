using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISContrastDtl: IBusinessLogic
    {
        public RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }

        public ProcessDeleteRISContrastDtl()
		{
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
		}
		
		public void Invoke()
		{
            RISContrastDtlDeleteData proc = new RISContrastDtlDeleteData();
            proc.RIS_CONTRASTDTL = RIS_CONTRASTDTL;
            proc.Delete();
		}
    }
}
