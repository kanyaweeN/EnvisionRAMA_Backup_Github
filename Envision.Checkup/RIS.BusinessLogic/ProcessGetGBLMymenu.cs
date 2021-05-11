//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    06/08/2552 04:53:43
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
	public class ProcessGetGBLMymenu : IBusinessLogic
	{
		private DataSet result;
		private GBLMymenu _gblmymenu;
		public ProcessGetGBLMymenu()
		{
			_gblmymenu = new  GBLMymenu();
		}
		public GBLMymenu GBLMymenu
		{
			get{return _gblmymenu;}
			set{_gblmymenu=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLMymenuSelectData _proc=new GBLMymenuSelectData();
			_proc.GBLMymenu=this.GBLMymenu;
			result=_proc.GetData();
		}
	}
}

