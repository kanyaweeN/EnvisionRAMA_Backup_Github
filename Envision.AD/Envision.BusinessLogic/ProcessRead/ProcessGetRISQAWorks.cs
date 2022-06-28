using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISQAWorks : IBusinessLogic
    {
        public RIS_QAWORK RIS_QAWORK { get; set; }
        private DataSet result;
        public ProcessGetRISQAWorks()
        {
            RIS_QAWORK = new RIS_QAWORK();
        }
        public DataSet rptQAWorks(DateTime FromDate,DateTime ToDate,int UserID)
        {
            RISQAWorksSelectData _proc = new RISQAWorksSelectData();
            return _proc.GetReport_QAWorks(FromDate, ToDate, UserID);
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISQAWorksSelectData _proc = new RISQAWorksSelectData();
            _proc.RIS_QAWORK = this.RIS_QAWORK;
            result = _proc.GetData();
        }
    }
}
