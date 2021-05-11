using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACFinalizePrivilege : IBusinessLogic
    {
        public AC_FINALIZEPRIVILEGE AC_FINALIZEPRIVILEGE { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddACFinalizePrivilege()
        {
            AC_FINALIZEPRIVILEGE = new AC_FINALIZEPRIVILEGE();
            Transaction = null;
        }
        public ProcessAddACFinalizePrivilege(DbTransaction tran)
        {
            AC_FINALIZEPRIVILEGE = new AC_FINALIZEPRIVILEGE();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
            ACFinalizePrivilegeInsertData _proc = new ACFinalizePrivilegeInsertData();
            _proc.AC_FINALIZEPRIVILEGE = this.AC_FINALIZEPRIVILEGE;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_FINALIZEPRIVILEGE.FINALIZEPRIVILEGE_ID = _proc.GetID();
        }
    }
}
