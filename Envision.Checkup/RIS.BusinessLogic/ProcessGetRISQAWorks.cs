using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISQAWorks : IBusinessLogic
    {
        private RISQaworks _RISQaworks; 
        private DataSet result;
        public ProcessGetRISQAWorks()
        {
            _RISQaworks = new RISQaworks();
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
            _proc.RISQaworks = this.RISQaworks;
            result = _proc.GetData();
        }
        public RISQaworks RISQaworks
        {
            get { return _RISQaworks; }
            set { _RISQaworks = value; }
        }
    }
}
