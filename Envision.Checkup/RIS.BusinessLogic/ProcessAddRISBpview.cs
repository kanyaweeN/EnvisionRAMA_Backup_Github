using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISBpview : IBusinessLogic
	{
		private RISBpview _risbpview;
		public ProcessAddRISBpview()
		{
			_risbpview = new  RISBpview();
		}
		public RISBpview RISBpview		{
			get{return _risbpview;}
			set{_risbpview=value;}
		}
		public void Invoke()
		{
			RISBpviewInsertData _proc=new RISBpviewInsertData();
			_proc.RISBpview=this.RISBpview;
			_proc.Add();
		}
	}
}

