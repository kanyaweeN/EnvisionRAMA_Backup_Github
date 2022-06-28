using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACAssignment
    {
         public AC_ASSIGNMENT AC_ASSIGNMENT { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddACAssignment()
        {
            AC_ASSIGNMENT = new AC_ASSIGNMENT();
            Transaction = null;
        }
        public ProcessAddACAssignment(DbTransaction tran)
        {
            AC_ASSIGNMENT = new AC_ASSIGNMENT();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
            ACAssignmentInsertData _proc = new ACAssignmentInsertData();
            _proc.AC_ASSIGNMENT = this.AC_ASSIGNMENT;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_ASSIGNMENT.ASSIGNEMENT_ID = _proc.GetID();
        }
    }
}
