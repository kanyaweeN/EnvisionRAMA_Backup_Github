using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetHISRegistration : IBusinessLogic
	{
        private string reg_uid = string.Empty;
        private int reg_id = 0;
        private int action = 0;
		private DataSet result;

        public ProcessGetHISRegistration(int RegID) {
            action = 0;
            reg_id = RegID;
            reg_uid = string.Empty;
        }
		public ProcessGetHISRegistration(string HN)
		{
            action = 0;
            reg_uid = HN;
            reg_id = 0;
		}
        public ProcessGetHISRegistration(string HN, bool getFromHIS) {
            if (getFromHIS) {
                action = 1;
                reg_id = 0;
                reg_uid = HN;
            }
            else {
                action = 2;
                reg_id = 0;
                reg_uid = HN.ToString(); ;
            }
        }

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}

		public void Invoke()
		{

            HISRegistrationSelectData _proc = null;
            if (action == 0)
            {
                _proc = new HISRegistrationSelectData();
                _proc.HISRegistration.REG_ID = reg_id;
                _proc.HISRegistration.HN = reg_uid;
            }
            else if (action == 1)
            {
                _proc = new HISRegistrationSelectData(true);
                _proc.HISRegistration.REG_ID = reg_id;
                _proc.HISRegistration.HN = reg_uid;
            }
            else if (action == 2) {
                _proc = new HISRegistrationSelectData();
                _proc.HISRegistration.REG_ID = 0;
                _proc.HISRegistration.HN = reg_id.ToString(); ;
            
            }
            
            result = _proc.GetData();

		}
	}
}

