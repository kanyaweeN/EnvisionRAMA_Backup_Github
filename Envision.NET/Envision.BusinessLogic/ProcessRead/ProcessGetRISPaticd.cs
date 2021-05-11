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
	public class ProcessGetRISPaticd : IBusinessLogic
	{
        public RIS_PATICD RIS_PATICD { get; set; }
		private DataSet result;
        private int action;
		public ProcessGetRISPaticd()
		{
            result = null;
            RIS_PATICD = new RIS_PATICD();
            action = 0;
		}
        public ProcessGetRISPaticd(int orderID)
        {
            result = null;
            RIS_PATICD = new RIS_PATICD();
            RIS_PATICD.ORDER_NO = orderID;
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
                _proc = new RISPaticdSelectData(Convert.ToInt32(RIS_PATICD.ORDER_NO));
			result=_proc.GetData();
		}
	}
}

