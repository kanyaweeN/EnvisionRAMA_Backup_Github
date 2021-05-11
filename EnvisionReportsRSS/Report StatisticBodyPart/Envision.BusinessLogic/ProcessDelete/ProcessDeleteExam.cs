using Envision.Common;
using Envision.DataAccess.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteExam
    {
        private RISExamDeleteData db { get; set; }
        public RIS_EXAM RIS_EXAM { get; set; }

        public ProcessDeleteExam()
        {
            RIS_EXAM = new RIS_EXAM();
            db = new RISExamDeleteData();
        }

        public void Delete()
        {
            db.RIS_EXAM = this.RIS_EXAM;
            db.Delete();
        }

    }
}
