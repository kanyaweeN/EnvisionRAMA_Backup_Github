using Envision.Common;
using Envision.DataAccess.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateExam
    {
        private RISExamUpdateData db { get; set; }
        public RIS_EXAM RIS_EXAM { get; set; }

        public ProcessUpdateExam()
        {
            RIS_EXAM = new RIS_EXAM();
            db = new RISExamUpdateData();
        }

        public void Update()
        {
            db.RIS_EXAM = RIS_EXAM;
            db.Update();
        }
        public void UpdateByCode()
        {
            db.RIS_EXAM = RIS_EXAM;
            db.UpdateByCode();
        }
    }
}
