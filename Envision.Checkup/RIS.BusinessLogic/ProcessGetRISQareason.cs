//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:30
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISQareason : IBusinessLogic
	{
		private DataSet result;
		private RISQareason _risqareason;
		public ProcessGetRISQareason()
		{
			_risqareason = new  RISQareason();
		}
		public RISQareason RISQareason
		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISQareasonSelectData _proc=new RISQareasonSelectData();
			_proc.RISQareason=this.RISQareason;
			result=_proc.GetData();
		}
	}
}

