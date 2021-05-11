using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetXrayAndRISScheduleSummary : IBusinessLogic
    {
        public int ID { get; set; }
        public int REG_ID { get; set; }
        public string HN { get; set; }
        public int EXAM_ID { get; set; }
        public int MODE { get; set; }
        public int ORG_ID { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            XrayAndRISScheduleSelectSummary processor = new XrayAndRISScheduleSelectSummary();
            this.Result = processor.GetData(this.REG_ID, this.HN, this.ID, this.EXAM_ID, this.MODE, this.ORG_ID);
        }

        #endregion
    }
}
