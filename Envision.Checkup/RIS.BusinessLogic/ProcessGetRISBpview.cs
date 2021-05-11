using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISBpview : IBusinessLogic
	{
		private DataSet result;
		private RISBpview _risbpview;
		public ProcessGetRISBpview()
		{
			_risbpview = new  RISBpview();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISBpviewSelectData _proc=new RISBpviewSelectData();
			result=_proc.GetData();
		}
	}
}

