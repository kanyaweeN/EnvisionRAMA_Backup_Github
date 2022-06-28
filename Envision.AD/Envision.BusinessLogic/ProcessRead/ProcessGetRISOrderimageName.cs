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

