using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISTechconsumption : IBusinessLogic
	{
		private RISTechconsumption _ristechconsumption;
		public ProcessAddRISTechconsumption()
		{
			_ristechconsumption = new  RISTechconsumption();
		}
		public RISTechconsumption RISTechconsumption		{
			get{return _ristechconsumption;}
			set{_ristechconsumption=value;}
		}
		public void Invoke()
		{
			RISTechconsumptionInsertData _proc=new RISTechconsumptionInsertData();
			_proc.RISTechconsumption=this.RISTechconsumption;
			_proc.Add();
		}
	}
}

