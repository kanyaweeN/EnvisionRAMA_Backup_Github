//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/04/2009 12:35:35
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
	public class ProcessGetRISRadstudygroup : IBusinessLogic
	{
		private DataSet result;
		private RISRadstudygroup _risradstudygroup;
		public ProcessGetRISRadstudygroup()
		{
			_risradstudygroup = new  RISRadstudygroup();
		}
		public RISRadstudygroup RISRadstudygroup
		{
			get{return _risradstudygroup;}
			set{_risradstudygroup=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISRadstudygroupSelectData _proc=new RISRadstudygroupSelectData();
			_proc.RISRadstudygroup=this.RISRadstudygroup;
			result=_proc.GetData();
		}
	}
}

