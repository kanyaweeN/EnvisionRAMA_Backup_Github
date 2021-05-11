//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:20:56
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
	public class ProcessGetGBLEnvlog : IBusinessLogic
	{
		private DataSet result;
		private GBLEnvlog _gblenvlog;
		public ProcessGetGBLEnvlog()
		{
			_gblenvlog = new  GBLEnvlog();
		}
		public GBLEnvlog GBLEnvlog
		{
			get{return _gblenvlog;}
			set{_gblenvlog=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLEnvlogSelectData _proc=new GBLEnvlogSelectData();
			_proc.GBLEnvlog=this.GBLEnvlog;
			result=_proc.GetData();
		}
	}
}

