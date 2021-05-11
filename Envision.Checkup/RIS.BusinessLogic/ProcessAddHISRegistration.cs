using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddHISRegistration : IBusinessLogic
	{
		private HISRegistration _hisregistration;
        private SqlTransaction tran = null;
        private int action = 0;
        private bool link = true;
		public ProcessAddHISRegistration()
		{
            tran = null;
			_hisregistration = new  HISRegistration();
            action = 0;
		}
        public ProcessAddHISRegistration(bool linkDown)
        {
            tran = null;
            _hisregistration = new HISRegistration();
            action = 1;
            link = linkDown;
        }
        public ProcessAddHISRegistration(SqlTransaction tran)
        {
            _hisregistration = new HISRegistration();
            this.tran = tran;
            action = 2;
        }

		public HISRegistration HISRegistration		{
			get{return _hisregistration;}
			set{_hisregistration=value;}
		}
		public void Invoke()
		{
            HISRegistrationInsertData _proc = new HISRegistrationInsertData();
            _proc.HISRegistration = _hisregistration;
            if (action == 0)
                _hisregistration.REG_ID = _proc.Add();
            else if (action == 1)
            {
                _proc = new HISRegistrationInsertData(link);
                _proc.HISRegistration = _hisregistration;
                _hisregistration.REG_ID = _proc.Add();
            }
            else if (action == 2) 
           {
               _hisregistration.REG_ID = _proc.Add(tran);

           }
		}
        public SqlTransaction UseTransaction
        {
            set
            {
                tran = value;
            }
        }

        //public int CheckHISData(string HN) {
        //    HISRegistrationInsertData _proc = new HISRegistrationInsertData();
        //    return _proc.CheckHISData(HN);
        //}
        public int CheckHISData(HISRegistration his) {
            HISRegistrationInsertData _proc = new HISRegistrationInsertData();
            return _proc.CheckHISData(his);
            
        }
	}
}

