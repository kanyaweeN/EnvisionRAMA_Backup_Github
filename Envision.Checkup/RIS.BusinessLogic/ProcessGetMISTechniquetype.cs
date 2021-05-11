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
	public class ProcessGetMISTechniquetype : IBusinessLogic
	{
		private DataSet result;
		private MISTechniquetype _mistechniquetype;
		public ProcessGetMISTechniquetype()
		{
			_mistechniquetype = new  MISTechniquetype();
		}
		public MISTechniquetype MISTechniquetype
		{
			get{return _mistechniquetype;}
			set{_mistechniquetype=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISTechniquetypeSelectData _proc=new MISTechniquetypeSelectData();
			_proc.MISTechniquetype=this.MISTechniquetype;
			result=_proc.GetData();
		}
	}
}

