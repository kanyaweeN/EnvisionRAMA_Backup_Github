using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACClass : IBusinessLogic
    {
        public AC_CLASS AC_CLASS { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddACClass()
        {
            AC_CLASS = new AC_CLASS();
            Transaction = null;
        }
        public ProcessAddACClass(DbTransaction tran)
        {
            AC_CLASS = new AC_CLASS();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
            ACClassInsertData _proc = new ACClassInsertData();
            _proc.AC_CLASS = this.AC_CLASS;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_CLASS.CLASS_ID = _proc.GetID();
        }
    }
}
