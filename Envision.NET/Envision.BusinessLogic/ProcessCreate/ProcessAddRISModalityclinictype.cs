//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/04/2009 08:46:09
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
	public class ProcessAddRISModalityclinictype : IBusinessLogic
	{
        public RIS_MODALITYCLINICTYPE RIS_MODALITYCLINICTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISModalityclinictype()
		{
            RIS_MODALITYCLINICTYPE = new RIS_MODALITYCLINICTYPE();
            Transaction = null;
		}
		public void Invoke()
		{

			RISModalityclinictypeInsertData _proc=new RISModalityclinictypeInsertData();
            _proc.RIS_MODALITYCLINICTYPE = this.RIS_MODALITYCLINICTYPE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

