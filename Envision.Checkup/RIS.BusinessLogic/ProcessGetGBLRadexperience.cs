//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:16
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
	public class ProcessGetGBLRadexperience : IBusinessLogic
	{
		private DataSet result;
		private GBLRadexperience _gblradexperience;
		public ProcessGetGBLRadexperience()
		{
			_gblradexperience = new  GBLRadexperience();
		}
		public GBLRadexperience GBLRadexperience
		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLRadexperienceSelectData _proc=new GBLRadexperienceSelectData();
			_proc.GBLRadexperience=this.GBLRadexperience;
			result=_proc.GetData();
		}
	}
}

