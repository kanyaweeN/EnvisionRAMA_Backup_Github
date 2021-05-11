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
    public class ProcessDeleteGBLAlert : IBusinessLogic
    {
        public DbTransaction Transaction { get; set; }
        public GBL_ALERT GBL_ALERT{get;set;}

        public ProcessDeleteGBLAlert()
        {
            Transaction = null;
            GBL_ALERT = new GBL_ALERT();
        }

        public void Invoke()
        {
            GBL_ALERTDeleteData alertData = new GBL_ALERTDeleteData();
            alertData.GBL_ALERT = GBL_ALERT;
            if (Transaction == null)
                alertData.Delete();
            else
                alertData.Delete(Transaction);

        }

      
    }
}
