using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

using System.Data.SqlClient;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateHISRegistration : IBusinessLogic
	{
		private HISRegistration _hisregistration;
        private SqlTransaction tran;

		public ProcessUpdateHISRegistration()
		{
            tran = null;
			_hisregistration = new HISRegistration();
		}
        public ProcessUpdateHISRegistration(SqlTransaction tran)
        {
            this.tran = tran;
            _hisregistration = new HISRegistration();
        }

		public HISRegistration HISRegistration		{
			get{return _hisregistration;}
			set{_hisregistration=value;}
		}
		public void Invoke()
		{
            HISRegistrationUpdateData _proc = new HISRegistrationUpdateData();
            _proc.HISRegistration=this.HISRegistration;
            if (tran == null)
                _proc.Update();
            else
                _proc.Update(tran);
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

