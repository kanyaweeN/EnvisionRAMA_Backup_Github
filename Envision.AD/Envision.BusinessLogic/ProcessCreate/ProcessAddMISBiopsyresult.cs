//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddMISBiopsyresult : IBusinessLogic
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddMISBiopsyresult()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
            Transaction = null;
		}
		public void Invoke()
		{
			MISBiopsyresultInsertData _proc=new MISBiopsyresultInsertData();
            _proc.MIS_BIOPSYRESULT = this.MIS_BIOPSYRESULT;
			 _proc.Add();
		}
	}
}

