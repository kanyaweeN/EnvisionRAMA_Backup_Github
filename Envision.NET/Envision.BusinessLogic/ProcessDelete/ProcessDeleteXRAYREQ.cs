using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteXRAYREQDTL
    {
        public XRAYREQDTL XRAYREQDTL { get; set; }

        public ProcessDeleteXRAYREQDTL()
        {
            this.XRAYREQDTL = new XRAYREQDTL();
        }

        public void Invoke()
        {
            XRAYREQDTLDeleteData _proc = new XRAYREQDTLDeleteData();
            _proc.XRAYREQDTL = this.XRAYREQDTL;
            _proc.Delete();
        }
    }
}
