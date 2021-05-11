using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISSF02 : IBusinessLogic
    {
        public RISSF02Data RISSF02Data { get; set; }

        public ProcessUpdateRISSF02()
        {
            RISSF02Data = new RISSF02Data();
        }

        public void Invoke()
        {
            RISSF02UpdateData objdata = new RISSF02UpdateData();
            objdata.RISSF02Data = this.RISSF02Data;
            objdata.Add();

        }
    }
}
