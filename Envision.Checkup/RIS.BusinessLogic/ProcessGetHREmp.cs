//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    16/06/2009 04:23:18
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
	public class ProcessGetHREmp : IBusinessLogic
	{
		private DataSet result;
		private HREmp _hremp;
		public ProcessGetHREmp()
		{
			_hremp = new  HREmp();
		}
		public HREmp HREmp
		{
			get{return _hremp;}
			set{_hremp=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			HREmpSelectData _proc=new HREmpSelectData();
			_proc.HREmp=this.HREmp;
			result=_proc.GetData();
		}
	}
}

