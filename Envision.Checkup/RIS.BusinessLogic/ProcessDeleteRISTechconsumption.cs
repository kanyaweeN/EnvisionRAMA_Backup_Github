using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISTechconsumption : IBusinessLogic
	{
		private RISTechconsumption _ristechconsumption;
		public ProcessDeleteRISTechconsumption()
		{
			_ristechconsumption = new  RISTechconsumption();
		}
		public RISTechconsumption RISTechconsumption		{
			get{return _ristechconsumption;}
			set{_ristechconsumption=value;}
		}
		public void Invoke()
		{
			RISTechconsumptionDeleteData _proc=new RISTechconsumptionDeleteData();
			_proc.RISTechconsumption=RISTechconsumption;
			_proc.Delete();
		}
	}
}

