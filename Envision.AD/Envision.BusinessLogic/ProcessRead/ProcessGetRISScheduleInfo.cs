using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISScheduleInfo : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public int SCHEDULE_ID { get; set; }
        public int ORG_ID { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISScheduleInfoSelect processor = new RISScheduleInfoSelect();
            this.Result = processor.GetScheduleInfo(this.SCHEDULE_ID, this.ORG_ID);
        }

        #endregion
    }
}
