using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVAuthorization : IBusinessLogic
	{
		private INVAuthorization _invauthorization;
        private SqlTransaction tran = null;
		public ProcessAddINVAuthorization()
		{
			_invauthorization = new  INVAuthorization();
		}
        public ProcessAddINVAuthorization(SqlTransaction transaction)
        {
            _invauthorization = new INVAuthorization();
            tran = transaction;
        }
		public INVAuthorization INVAuthorization		{
			get{return _invauthorization;}
			set{_invauthorization=value;}
		}
		public void Invoke()
		{
			INVAuthorizationInsertData _proc=new INVAuthorizationInsertData();
			_proc.INVAuthorization=this.INVAuthorization;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
		}
	}
}

