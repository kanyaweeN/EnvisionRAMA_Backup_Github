using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLGrantRole : IBusinessLogic
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGBLGrantRole() {
            GBL_GRANTROLE = new GBL_GRANTROLE();
            Transaction = null;
        }

        public void Invoke()
        {
            GBL_GRANTROLEDeleteData delete = new GBL_GRANTROLEDeleteData();
            delete.GBL_GRANTROLE = GBL_GRANTROLE;
            if (Transaction == null)
                delete.Delete();
            else
                delete.Delete(Transaction);
        }
       
    }
}
