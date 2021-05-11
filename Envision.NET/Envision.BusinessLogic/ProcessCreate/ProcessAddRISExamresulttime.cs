using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamresulttime : IBusinessLogic
    {
        public RIS_EXAMRESULTTIME RIS_EXAMRESULTTIME { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddRISExamresulttime()
        {
            RIS_EXAMRESULTTIME = new RIS_EXAMRESULTTIME();
            Transaction = null;
        }
        public ProcessAddRISExamresulttime(DbTransaction tran)
        {
            RIS_EXAMRESULTTIME = new RIS_EXAMRESULTTIME();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
            RISExamresulttimeInsertData _proc = new RISExamresulttimeInsertData();
            _proc.RIS_EXAMRESULTTIME = this.RIS_EXAMRESULTTIME;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
        }
    }
}
