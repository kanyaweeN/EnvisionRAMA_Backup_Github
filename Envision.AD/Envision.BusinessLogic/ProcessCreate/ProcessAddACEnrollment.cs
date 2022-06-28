using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACEnrollment : IBusinessLogic
    {
        public AC_ENROLLMENT AC_ENROLLMENT { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddACEnrollment()
        {
            AC_ENROLLMENT = new AC_ENROLLMENT();
            Transaction = null;
        }
        public ProcessAddACEnrollment(DbTransaction tran)
        {
            AC_ENROLLMENT = new AC_ENROLLMENT();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
            ACEnrollmentInsertData _proc = new ACEnrollmentInsertData();
            _proc.AC_ENROLLMENT = this.AC_ENROLLMENT;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_ENROLLMENT.ENROLL_ID = _proc.GetID();
        }
    }
}
