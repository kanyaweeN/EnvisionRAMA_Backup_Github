using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamMapBilling : IBusinessLogic
    {
        private DataSet _dataresult;
        public RIS_EXAMMAPBILLING RIS_EXAMMAPBILLING { get; set; }

        public ProcessGetRISExamMapBilling()
        {
            RIS_EXAMMAPBILLING = new RIS_EXAMMAPBILLING();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {
            RISExamMapBillingSelectData data = new RISExamMapBillingSelectData();
            data.RIS_EXAMMAPBILLING = RIS_EXAMMAPBILLING;
            DataResult = data.Get();
        }

        public DataSet DataResult
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}
