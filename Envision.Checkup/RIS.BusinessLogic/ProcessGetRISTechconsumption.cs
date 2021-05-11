using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISTechconsumption : IBusinessLogic
	{
        private RISTechconsumption _ristechconsumption;
        private string hn;
		private DataSet result;
		public ProcessGetRISTechconsumption()
		{
			_ristechconsumption = new  RISTechconsumption();
            hn = string.Empty;
		}
        public ProcessGetRISTechconsumption(string HN)
        {
            _ristechconsumption = new RISTechconsumption();
            hn = HN;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
        public RISTechconsumption RISTechconsumption {
            get { return _ristechconsumption; }
            set { _ristechconsumption = value; }
        }
		public void Invoke()
		{
			RISTechconsumptionSelectData _proc=new RISTechconsumptionSelectData();
            _proc.RISTechconsumption = _ristechconsumption;
            if (hn == string.Empty)
                result = _proc.GetData();
            else
                result = _proc.GetData(hn);
		}
	}
}

