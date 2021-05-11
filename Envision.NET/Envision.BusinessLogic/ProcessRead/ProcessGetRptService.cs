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
    public class ProcessGetRptService : IBusinessLogic
    {
        private DataSet result;
        private string roomID;
        private string fromDate;
        private string toDate;
        private string examType;

        public ProcessGetRptService(string RoomID, string FromDate, string ToDate, string ExamType)
        {
            roomID = RoomID;
            fromDate = FromDate;
            toDate = ToDate;
            examType = ExamType;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptServiceSelectData _proc = null;
            _proc = new RISRptServiceSelectData(roomID, fromDate, toDate, examType);
            result = _proc.Get().Copy();
        }
    }
}
