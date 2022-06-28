//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class ProcessAddRISLoadmediadtl : IBusinessLogic
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISLoadmediadtl()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
            Transaction = null;
		}
        public ProcessAddRISLoadmediadtl(DbTransaction tran)
        {
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
            Transaction = tran;
        }
		public void Invoke()
		{
			RISLoadmediadtlInsertData _proc=new RISLoadmediadtlInsertData();
            _proc.RIS_LOADMEDIADTL = this.RIS_LOADMEDIADTL;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
		}
	}
}

