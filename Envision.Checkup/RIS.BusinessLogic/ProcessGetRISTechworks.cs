using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISTechworks : IBusinessLogic
	{
		private DataSet result;
        RISTechworks _ristechworks;
		public ProcessGetRISTechworks()
		{
			_ristechworks = new  RISTechworks();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
        public RISTechworks RISTechworks {
            get { return _ristechworks; }
            set { _ristechworks = value; }
        }
		public void Invoke()
		{
			RISTechworksSelectData _proc=new RISTechworksSelectData();
            _proc.RISTechworks = _ristechworks;
			result=_proc.GetData();
		}
	}
}

