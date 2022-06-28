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
	public class ProcessAddMISLesiontype : IBusinessLogic
	{
        public MIS_LESIONTYPE MIS_LESIONTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddMISLesiontype()
		{
            MIS_LESIONTYPE = new MIS_LESIONTYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			MISLesiontypeInsertData _proc=new MISLesiontypeInsertData();
            _proc.MIS_LESIONTYPE = this.MIS_LESIONTYPE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

