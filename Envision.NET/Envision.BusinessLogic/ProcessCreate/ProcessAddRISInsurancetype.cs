//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/05/2552 05:36:57
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
	public class ProcessAddRISInsurancetype : IBusinessLogic
	{
        public RIS_INSURANCETYPE RIS_INSURANCETYPE { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddRISInsurancetype()
		{
            RIS_INSURANCETYPE = new RIS_INSURANCETYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			RISInsurancetypeInsertData _proc=new RISInsurancetypeInsertData();
            _proc.RIS_INSURANCETYPE = this.RIS_INSURANCETYPE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

