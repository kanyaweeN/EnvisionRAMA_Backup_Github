//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    24/04/2009 01:28:08
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
	public class ProcessGetRISExamresultlegacy : IBusinessLogic
	{
		private DataSet result;
		private RISExamresultlegacy _risexamresultlegacy;
		public ProcessGetRISExamresultlegacy()
		{
            _risexamresultlegacy = new RISExamresultlegacy();
		}
		public RISExamresultlegacy RISExamresultlegacy
		{
			get{return _risexamresultlegacy;}
			set{_risexamresultlegacy=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresultlegacySelectData _proc=new RISExamresultlegacySelectData();
			_proc.RISExamresultlegacy=this.RISExamresultlegacy;
			result=_proc.GetData();
		}
	}
}

