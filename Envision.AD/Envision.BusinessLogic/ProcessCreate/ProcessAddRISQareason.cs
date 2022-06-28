//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:30
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
	public class ProcessAddRISQareason : IBusinessLogic
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISQareason()
		{
            RIS_QAREASON = new RIS_QAREASON();
            Transaction = null;
		}
		public void Invoke()
		{
			RISQareasonInsertData _proc=new RISQareasonInsertData();
            _proc.RIS_QAREASON = this.RIS_QAREASON;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

