using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISOrderimageName : IBusinessLogic
	{
        private int _risordernumber;
		private DataSet result;
		public ProcessGetRISOrderimageName(int number)
        {
            RISOrderNumber = number;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
        public int RISOrderNumber {
            get { return _risordernumber; }
            set { _risordernumber = value; }
        }
		public void Invoke()
		{
            RISOrderimageNameSelectData _proc = new RISOrderimageNameSelectData();
            _proc.RISOrderNumber   = RISOrderNumber;
			result=_proc.GetData();
		}
	}
}

