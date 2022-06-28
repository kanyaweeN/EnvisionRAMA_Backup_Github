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
	public class ProcessGetHISRegistration : IBusinessLogic
	{
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        private string reg_uid = string.Empty;
        private int reg_id = 0;
        private int action = 0;
		private DataSet result;

        public ProcessGetHISRegistration()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
        }

        public ProcessGetHISRegistration(int RegID) {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            action = 0;
            reg_id = RegID;
            reg_uid = string.Empty;
        }
		public ProcessGetHISRegistration(string HN)
		{
            HIS_REGISTRATION = new HIS_REGISTRATION();
            action = 0;
            reg_uid = HN;
            reg_id = 0;
		}
        public ProcessGetHISRegistration(string HN, bool getFromHIS) {
            if (getFromHIS) {
                HIS_REGISTRATION = new HIS_REGISTRATION();
                action = 1;
                reg_id = 0;
                reg_uid = HN;
            }
            else {
                HIS_REGISTRATION = new HIS_REGISTRATION();
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
                _proc.HIS_REGISTRATION.REG_ID = reg_id;
                _proc.HIS_REGISTRATION.HN = reg_uid;
            }
            else if (action == 1)
            {
                _proc = new HISRegistrationSelectData(true);
                _proc.HIS_REGISTRATION.REG_ID = reg_id;
                _proc.HIS_REGISTRATION.HN = reg_uid;
            }
            else if (action == 2) {
                _proc = new HISRegistrationSelectData();
                _proc.HIS_REGISTRATION.REG_ID = 0;
                _proc.HIS_REGISTRATION.HN = reg_id.ToString(); ;
            }
            
            result = _proc.GetData();

		}

        public void Invoke_GetDataAll()
        {
            HISRegistrationSelectData _proc = new HISRegistrationSelectData();
            result = _proc.GetDataAll();

        }

        public void Invoke_GetLastRecord()
        {
            HISRegistrationSelectData _proc = new HISRegistrationSelectData();
            result = _proc.GetDataLastRecord();

        }
	}
}

