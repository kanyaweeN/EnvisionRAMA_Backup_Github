using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISOrder : IBusinessLogic
	{
		private RISOrder _risorder;
        SqlTransaction tran = null;
		public ProcessDeleteRISOrder()
		{
			_risorder = new  RISOrder();
		}
		public RISOrder RISOrder		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public void Invoke()
		{
			RISOrderDeleteData _proc=new RISOrderDeleteData();
			_proc.RISOrder=this.RISOrder;
			_proc.Delete();
		}

        public SqlTransaction UseTransaction {
            set
            {
                tran = value;
            }
        }
	}
}

