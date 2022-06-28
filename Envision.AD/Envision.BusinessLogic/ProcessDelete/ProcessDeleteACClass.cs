using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteACClass : IBusinessLogic
    {
        public AC_CLASS AC_CLASS { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteACClass()
		{
            AC_CLASS = new AC_CLASS();
            Transaction = null;
		}
		
		public void Invoke()
		{
            ACClassDeleteData proc = new ACClassDeleteData();
            proc.AC_CLASS = AC_CLASS;
            proc.Delete();
		}
    }
}
