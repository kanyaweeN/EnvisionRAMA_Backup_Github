using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISBpview : IBusinessLogic
	{
		private RISBpview _risbpview;
		public ProcessDeleteRISBpview()
		{
			_risbpview = new  RISBpview();
		}
		public RISBpview RISBpview		{
			get{return _risbpview;}
			set{_risbpview=value;}
		}
		public void Invoke()
		{
			RISBpviewDeleteData _proc=new RISBpviewDeleteData();
			_proc.RISBpview=this.RISBpview;
			_proc.Delete();
		}
	}
}

