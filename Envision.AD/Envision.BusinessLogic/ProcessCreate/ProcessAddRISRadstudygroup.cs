//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/04/2009 12:35:35
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
	public class ProcessAddRISRadstudygroup : IBusinessLogic
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISRadstudygroup()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
            Transaction = null;
		}
		public void Invoke()
		{
			RISRadstudygroupInsertData _proc=new RISRadstudygroupInsertData();
            _proc.RIS_RADSTUDYGROUP = this.RIS_RADSTUDYGROUP;
            if (Transaction == null)
                _proc.Add();
		}
        public void Invoke(string Type)
        {
            RISRadstudygroupInsertData _proc = new RISRadstudygroupInsertData();
            _proc.RIS_RADSTUDYGROUP = this.RIS_RADSTUDYGROUP;
            if (Transaction == null)
                _proc.Add(Type);
        }
	}
}

