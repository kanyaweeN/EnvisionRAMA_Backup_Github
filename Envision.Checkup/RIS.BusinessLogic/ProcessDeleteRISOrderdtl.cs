using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISOrderdtl : IBusinessLogic
	{
        private SqlTransaction tran;
		private RISOrderdtl _risorderdtl;
		public ProcessDeleteRISOrderdtl()
		{
			_risorderdtl = new  RISOrderdtl();
		}
		public RISOrderdtl RISOrderdtl		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}
		public void Invoke()
		{
			RISOrderdtlDeleteData _proc=new RISOrderdtlDeleteData();
			_proc.RISOrderdtl=this.RISOrderdtl;
            _proc.RISOrderdtl.ORDER_ID = RISOrderdtl.ORDER_ID;
            _proc.RISOrderdtl.EXAM_ID = RISOrderdtl.EXAM_ID;
            if (tran==null)
                _proc.Delete();
            else
                _proc.Delete(tran);
		}
        public SqlTransaction UseTransaction
        {
            set
            {
                tran = value;
            }
        }
	}
}

