using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISSF09 : IBusinessLogic
    {
        public RISSF09Data RISSF09Data { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISSF09()
        {
            RISSF09Data = new RISSF09Data();
            Transaction = null;
        }

        public void Invoke()
        {
            RISSF09InsertData indata = new RISSF09InsertData();
            indata.RISSF09Data = RISSF09Data;
            indata.Add();
        }
    }
}
