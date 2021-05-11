//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class ProcessGetRISLoadmedia : IBusinessLogic
	{
		private DataSet result;
		private RISLoadmedia _risloadmedia;
		public ProcessGetRISLoadmedia()
		{
			_risloadmedia = new  RISLoadmedia();
		}
		public RISLoadmedia RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISLoadmediaSelectData _proc=new RISLoadmediaSelectData();
			_proc.RISLoadmedia=this.RISLoadmedia;
			result=_proc.GetData();
		}
	}
}

