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
	public class ProcessGetRISReleasemedia : IBusinessLogic
	{
		private DataSet result;
		private RISReleasemedia _risreleasemedia;
		public ProcessGetRISReleasemedia()
		{
			_risreleasemedia = new  RISReleasemedia();
		}
		public RISReleasemedia RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISReleasemediaSelectData _proc=new RISReleasemediaSelectData();
			_proc.RISReleasemedia=this.RISReleasemedia;
			result=_proc.GetData();
		}
	}
}

