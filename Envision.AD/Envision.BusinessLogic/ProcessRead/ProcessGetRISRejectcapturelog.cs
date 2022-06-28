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
    public class ProcessGetRISRejectcapturelog : IBusinessLogic
    {
        private DataSet _resultset;
        public RIS_REJECTCAPTURELOG RIS_REJECTCAPTURELOG { get; set; }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        public void Invoke() { }
        public ProcessGetRISRejectcapturelog()
        {
            _resultset = new DataSet();
            RIS_REJECTCAPTURELOG = new RIS_REJECTCAPTURELOG();
        }

        public DataTable SelectByAccessionNo()
        {
            RISRejectcapturelogSelectData _select = new RISRejectcapturelogSelectData();
            _select.RIS_REJECTCAPTURELOG = RIS_REJECTCAPTURELOG;
            return _select.SelectByAccessionNo();
        }
    }
}
