using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACGrade : IBusinessLogic
    {
        public AC_GRADE AC_GRADE { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddACGrade()
        {
            AC_GRADE = new AC_GRADE();
            Transaction = null;
        }
        public ProcessAddACGrade(DbTransaction tran)
        {
            AC_GRADE = new AC_GRADE();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
            ACGradeInsertData _proc = new ACGradeInsertData();
            _proc.AC_GRADE = this.AC_GRADE;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_GRADE.GRADE_ID = _proc.GetID();
        }
    }
}
