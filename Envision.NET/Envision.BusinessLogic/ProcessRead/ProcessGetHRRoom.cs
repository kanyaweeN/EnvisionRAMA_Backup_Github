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
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetHRRoom : IBusinessLogic
	{
		private DataSet result;
        public ProcessGetHRRoom()
		{
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            HRRoomSelectData _proc = new HRRoomSelectData();
			result=_proc.GetData();
		}
	}
}

