using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISOrder : IBusinessLogic
	{
		private RISOrder _risorder;
        private SqlTransaction tran;

		public ProcessAddRISOrder()
		{
			_risorder = new  RISOrder();
		}
		public RISOrder RISOrder		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public void Invoke()
		{
			RISOrderInsertData _proc=new RISOrderInsertData();
            _proc.RISOrder=this.RISOrder;
            if (tran == null)
                RISOrder.ORDER_ID = _proc.Add();
            else
                RISOrder.ORDER_ID = _proc.Add(tran);
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

