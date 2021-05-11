using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetHRJobtitle : IBusinessLogic
    {
        public HR_JOBTITLE HR_JOBTITLE { get; set; }
        public DataSet ResultSet { get; set; }

        public ProcessGetHRJobtitle()
        {
            HR_JOBTITLE = new HR_JOBTITLE();
        }

        public void Invoke()
        {
            HRJobtitleSelectData getdata = new HRJobtitleSelectData();
            getdata.HR_JOBTITLE = this.HR_JOBTITLE;
            ResultSet = getdata.GetData();
        }
    }
}
