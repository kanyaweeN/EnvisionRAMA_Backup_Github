using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVPr : IBusinessLogic
	{
		private INVPr _invpr;
        private int id = 0; 
        private SqlTransaction tran = null;
		public ProcessAddINVPr()
		{
			_invpr = new  INVPr();
		}
        public ProcessAddINVPr(SqlTransaction transaction)
        {
            _invpr = new INVPr();
            tran = transaction;
        }
		public INVPr INVPr		{
			get{return _invpr;}
			set{_invpr=value;}
		}
		public void Invoke()
		{
			INVPrInsertData _proc=new INVPrInsertData();
			_proc.INVPr=this.INVPr;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
            this.INVPr.PR_ID = _proc.GetID();
		}
	}
}

