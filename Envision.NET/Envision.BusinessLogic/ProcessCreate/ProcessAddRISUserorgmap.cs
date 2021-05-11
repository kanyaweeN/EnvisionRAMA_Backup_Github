//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/02/2009 11:11:57
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
	public class ProcessAddRISUserorgmap : IBusinessLogic
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISUserorgmap()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
            Transaction = null;
		}
		public void Invoke()
		{
			RISUserorgmapInsertData _proc=new RISUserorgmapInsertData();
            _proc.RIS_USERORGMAP = this.RIS_USERORGMAP;
            if (Transaction == null)
                _proc.Add();
		}
	}
}

