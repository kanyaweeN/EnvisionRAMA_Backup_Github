using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteACGrade : IBusinessLogic
    {
        public AC_GRADE AC_GRADE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteACGrade()
		{
            AC_GRADE = new AC_GRADE();
            Transaction = null;
		}
		
		public void Invoke()
		{
            ACGradeDeleteData proc = new ACGradeDeleteData();
            proc.AC_GRADE = AC_GRADE;
            proc.Delete();
		}
    }
}
