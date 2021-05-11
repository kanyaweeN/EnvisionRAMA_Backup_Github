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
	public class ProcessGetRISLoadmediadtl : IBusinessLogic
	{
		private DataSet result;
		private RISLoadmediadtl _risloadmediadtl;
		public ProcessGetRISLoadmediadtl()
		{
			_risloadmediadtl = new  RISLoadmediadtl();
		}
		public RISLoadmediadtl RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISLoadmediadtlSelectData _proc=new RISLoadmediadtlSelectData();
			_proc.RISLoadmediadtl=this.RISLoadmediadtl;
			result=_proc.GetData();
		}
	}
}

