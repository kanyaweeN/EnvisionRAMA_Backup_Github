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
	public class ProcessAddMISTechniquetype : IBusinessLogic
	{
        public MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddMISTechniquetype()
		{
            MIS_TECHNIQUETYPE = new MIS_TECHNIQUETYPE();
            Transaction = null;

		}
		public void Invoke()
		{
			MISTechniquetypeInsertData _proc=new MISTechniquetypeInsertData();
            _proc.MIS_TECHNIQUETYPE = this.MIS_TECHNIQUETYPE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

