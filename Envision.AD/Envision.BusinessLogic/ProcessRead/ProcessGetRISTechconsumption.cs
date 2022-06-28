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
	public class ProcessGetRISTechconsumption : IBusinessLogic
	{
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }
        private string hn;
		private DataSet result;
		public ProcessGetRISTechconsumption()
		{
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
            hn = string.Empty;
		}
        public ProcessGetRISTechconsumption(string HN)
        {
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
            hn = HN;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISTechconsumptionSelectData _proc=new RISTechconsumptionSelectData();
            _proc.RIS_TECHCONSUMPTION = RIS_TECHCONSUMPTION;
            if (hn == string.Empty)
                result = _proc.GetData();
            else
                result = _proc.GetData(hn);
		}
	}
}

