using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetINVPr : IBusinessLogic
	{
		private DataSet result;
		private INVPr _invpr;
		public ProcessGetINVPr()
		{
			_invpr = new  INVPr();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPrSelectData _proc=new INVPrSelectData();
			result=_proc.GetData();
		}
	}
}

