using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISOrderdtl : IBusinessLogic
	{
		private RISOrderdtl _risorderdtl;
        SqlTransaction tran = null;

		public ProcessAddRISOrderdtl()
		{
			_risorderdtl = new  RISOrderdtl();
		}
		public RISOrderdtl RISOrderdtl		{
			get{return _risorderdtl;}
			set{_risorderdtl=value;}
		}
		public void Invoke()
		{
			RISOrderdtlInsertData _proc=new RISOrderdtlInsertData();
			_proc.RISOrderdtl=this.RISOrderdtl;
            if (tran == null)
                _proc.Add();
            else
                _proc.Add(tran);
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

