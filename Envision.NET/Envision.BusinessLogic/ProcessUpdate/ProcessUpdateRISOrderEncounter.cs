using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISOrderEncounter : IBusinessLogic
    {
        public RIS_ORDER RIS_ORDER { get; set; }

        public ProcessUpdateRISOrderEncounter()
        {
            RIS_ORDER = new RIS_ORDER();
        }

        public void Invoke()
        {
            RISOrderUpdateDataEncounter update = new RISOrderUpdateDataEncounter();
            update.RIS_ORDER = this.RIS_ORDER;
            update.Update();
        }

        public void InvokeRefUnit()
        {
            RISOrderUpdateDataEncounter update = new RISOrderUpdateDataEncounter();
            update.RIS_ORDER = this.RIS_ORDER;
            update.UpdateRefUnit();
        }

        public void Invoke_ADMISSION_NO()
        {
            RISOrderUpdateDataEncounter update = new RISOrderUpdateDataEncounter();
            update.RIS_ORDER = this.RIS_ORDER;
            update.Update_ADMISSION_NO();
        }
    }
}
