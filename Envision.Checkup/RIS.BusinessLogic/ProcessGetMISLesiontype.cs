//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
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
	public class ProcessGetMISLesiontype : IBusinessLogic
	{
		private DataSet result;
		private MISLesiontype _mislesiontype;
		public ProcessGetMISLesiontype()
		{
			_mislesiontype = new  MISLesiontype();
		}
		public MISLesiontype MISLesiontype
		{
			get{return _mislesiontype;}
			set{_mislesiontype=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISLesiontypeSelectData _proc=new MISLesiontypeSelectData();
			_proc.MISLesiontype=this.MISLesiontype;
			result=_proc.GetData();
		}
	}
}

