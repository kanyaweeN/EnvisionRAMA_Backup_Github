using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISBpview : IBusinessLogic
	{
		private RISBpview _risbpview;
		public ProcessUpdateRISBpview()
		{
			_risbpview = new RISBpview();
		}
		public RISBpview RISBpview		{
			get{return _risbpview;}
			set{_risbpview=value;}
		}
		public void Invoke()
		{
			RISBpviewUpdateData _proc=new RISBpviewUpdateData();
			_proc.RISBpview=this.RISBpview;
			_proc.Update();
		}
	}
}

