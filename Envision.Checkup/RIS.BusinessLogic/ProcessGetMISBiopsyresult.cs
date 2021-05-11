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
	public class ProcessGetMISBiopsyresult : IBusinessLogic
	{
		private DataSet result;
		private MISBiopsyresult _misbiopsyresult;
		public ProcessGetMISBiopsyresult()
		{
			_misbiopsyresult = new  MISBiopsyresult();
		}
		public MISBiopsyresult MISBiopsyresult
		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISBiopsyresultSelectData _proc=new MISBiopsyresultSelectData();
			_proc.MISBiopsyresult=this.MISBiopsyresult;
			result=_proc.GetData();
		}
	}
}

