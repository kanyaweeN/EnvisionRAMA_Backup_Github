using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISPaticd : IBusinessLogic
	{
        private RISPaticd _rispaticd;
		private DataSet result;
        private int action;
		public ProcessGetRISPaticd()
		{
            result = null; 
			_rispaticd = new  RISPaticd();
            action = 0;
		}
        public ProcessGetRISPaticd(int orderID)
        {
            result = null;
            _rispaticd = new RISPaticd();
            _rispaticd.ORDER_NO = orderID;
            action = 1;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISPaticdSelectData _proc = null;// new RISPaticdSelectData();
            if (action == 0)
                _proc = new RISPaticdSelectData();
            else if (action == 1)
                _proc = new RISPaticdSelectData(_rispaticd.ORDER_NO);
			result=_proc.GetData();
		}
	}
}

