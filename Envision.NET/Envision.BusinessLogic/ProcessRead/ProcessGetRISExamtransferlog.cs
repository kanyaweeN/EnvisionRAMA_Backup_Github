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
	public class ProcessGetRISExamtransferlog : IBusinessLogic
	{
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }
		private DataSet result;
        public ProcessGetRISExamtransferlog()
        {
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
        }
		public ProcessGetRISExamtransferlog(int UserID)
		{
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
            RIS_EXAMTRANSFERLOG.CREATED_BY = UserID;
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamtransferlogSelectData _proc=new RISExamtransferlogSelectData();
            _proc.RIS_EXAMTRANSFERLOG = RIS_EXAMTRANSFERLOG;
			result=_proc.GetData();
		}
        public DataTable getTransferByAccession()
        {
            RISExamtransferlogSelectData _proc = new RISExamtransferlogSelectData();
            _proc.RIS_EXAMTRANSFERLOG = RIS_EXAMTRANSFERLOG;
            return _proc.getTransferByAccession().Tables[0];
        }
        public DataTable getTransferByHN()
        {
            RISExamtransferlogSelectData _proc = new RISExamtransferlogSelectData();
            _proc.RIS_EXAMTRANSFERLOG = RIS_EXAMTRANSFERLOG;
            return _proc.getTransferByHN().Tables[0];
        }
	}
}

