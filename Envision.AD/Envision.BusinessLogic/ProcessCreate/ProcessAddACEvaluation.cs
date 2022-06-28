using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddACEvaluation : IBusinessLogic
    {
          public AC_EVALUATION AC_EVALUATION { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddACEvaluation()
        {
            AC_EVALUATION = new AC_EVALUATION();
            Transaction = null;
        }
        public ProcessAddACEvaluation(DbTransaction tran)
        {
            AC_EVALUATION = new AC_EVALUATION();
            Transaction = tran;
        }
        public void Invoke()
        {
            //ACYearInsertData _or
             ACEvaluationInsertData _proc = new ACEvaluationInsertData();
            _proc.AC_EVALUATION = this.AC_EVALUATION;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.AC_EVALUATION.EVALUATION_ID = _proc.GetID();
        }
    }
}
