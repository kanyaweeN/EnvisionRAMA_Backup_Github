using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISNursesData :  IBusinessLogic
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISNursesData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
            Transaction = null;
		}
        public ProcessAddRISNursesData(DbTransaction tran)
        {
            RIS_NURSESDATA = new RIS_NURSESDATA();
            Transaction = tran;

        }
		public void Invoke()
		{
            RISNursesDataInsertData _proc = new RISNursesDataInsertData();
            _proc.RIS_NURSESDATA = this.RIS_NURSESDATA;
            if (Transaction == null)
            {
                _proc.Add(); 
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.RIS_NURSESDATA.NURSE_DATA_UK_ID = _proc.GetID();
		}
    }
}
