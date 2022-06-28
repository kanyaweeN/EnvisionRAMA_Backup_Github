using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISNursesDataDtl : IBusinessLogic
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessAddRISNursesDataDtl()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
            Transaction = null;
		}
        public ProcessAddRISNursesDataDtl(DbTransaction tran)
        {
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
            Transaction = tran;
        }
		public void Invoke()
		{
            RISNursesDataDtlInsertData _proc = new RISNursesDataDtlInsertData();
            _proc.RIS_NURSESDATADTL = this.RIS_NURSESDATADTL;
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
