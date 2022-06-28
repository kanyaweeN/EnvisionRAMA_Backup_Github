using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACYear : IBusinessLogic
    {
        public AC_YEAR AC_YEAR { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddACYear()
		{
            AC_YEAR = new AC_YEAR();
            Transaction = null;
		}
        public ProcessAddACYear(DbTransaction tran)
        {
            AC_YEAR = new AC_YEAR();
            Transaction = tran;
        }
		public void Invoke()
		{
            //ACYearInsertData _or
            ACYearInsertData _proc = new ACYearInsertData();
            _proc.AC_YEAR = this.AC_YEAR;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_YEAR.YEAR_ID = _proc.GetID();
		}
    }
}
