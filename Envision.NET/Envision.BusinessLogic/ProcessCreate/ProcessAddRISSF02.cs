using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISSF02 : IBusinessLogic
    {
        public RISSF02Data RISSF02Data { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISSF02()
        {
            RISSF02Data = new RISSF02Data();
            Transaction = null;
        }

        public void Invoke()
        {
            RISSF02InsertData indata = new RISSF02InsertData();
            indata.RISSF02Data = RISSF02Data;
            indata.Add();

        }
    }
}
