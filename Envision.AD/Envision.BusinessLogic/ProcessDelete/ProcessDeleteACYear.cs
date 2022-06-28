using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteACYear : IBusinessLogic
    {
        public AC_YEAR AC_YEAR { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteACYear()
		{
            AC_YEAR = new AC_YEAR();
            Transaction = null;
		}
		
		public void Invoke()
		{
            ACYearDeleteData proc = new ACYearDeleteData();
            proc.AC_YEAR = AC_YEAR;
            proc.Delete();
		}
    }
}
