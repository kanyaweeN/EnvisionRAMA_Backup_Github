using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISSF09 : IBusinessLogic
    {
        public RISSF09Data RISSF09Data{get;set;}

        public ProcessUpdateRISSF09()
        {
            RISSF09Data = new RISSF09Data();
        }

        public void Invoke()
        {
            RISSF09UpdateData objdata = new RISSF09UpdateData();
            objdata.RISSF09Data = this.RISSF09Data;
            objdata.Add();

        }
    }
}
