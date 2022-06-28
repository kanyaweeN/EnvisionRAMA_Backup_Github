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
	public class ProcessAddRISReleasemedia : IBusinessLogic
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISReleasemedia()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
            Transaction = null;
		}
        public ProcessAddRISReleasemedia(DbTransaction tran)
        {
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
            Transaction = tran;
        }
		public void Invoke()
		{
            RISReleasemediaInsertData _proc = new RISReleasemediaInsertData();
            _proc.RIS_RELEASEMEDIA = this.RIS_RELEASEMEDIA;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.RIS_RELEASEMEDIA.RELEASE_ID = _proc.GetID();
		}
	}
}

