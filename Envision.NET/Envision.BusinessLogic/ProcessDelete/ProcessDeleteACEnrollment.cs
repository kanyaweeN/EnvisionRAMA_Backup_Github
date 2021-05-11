using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteACEnrollment : IBusinessLogic
    {
        public AC_ENROLLMENT AC_ENROLLMENT { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteACEnrollment()
		{
            AC_ENROLLMENT = new AC_ENROLLMENT();
            Transaction = null;
		}
		
		public void Invoke()
		{
            ACEnrollmentDeleteData proc = new ACEnrollmentDeleteData();
            proc.AC_ENROLLMENT = AC_ENROLLMENT;
            proc.Delete();
		}
    }
}
