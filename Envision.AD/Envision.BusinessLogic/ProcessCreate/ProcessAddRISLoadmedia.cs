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
	public class ProcessAddRISLoadmedia : IBusinessLogic
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISLoadmedia()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
            Transaction = null;
		}
        public ProcessAddRISLoadmedia(DbTransaction tran)
        {
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
            Transaction = tran;
        }
		public void Invoke()
		{
			RISLoadmediaInsertData _proc=new RISLoadmediaInsertData();
            _proc.RIS_LOADMEDIA = this.RIS_LOADMEDIA;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.RIS_LOADMEDIA.LOAD_ID = _proc.GetID();
		}
	}
}

