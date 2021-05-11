using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class Exam
    {
        public RIS_EXAM RIS_EXAM { get; set; }

        public Exam()
        {
            RIS_EXAM = new RIS_EXAM();
        }

        public bool IsDupcliate(string Code, DataTable dtt)
        {
            return true;
        }


        public void Delete()
        {
            ProcessDeleteExam proc = new ProcessDeleteExam();
            proc.RIS_EXAM = this.RIS_EXAM;
            proc.Delete();
           
        }

        public void Update()
        {
            ProcessUpdate.ProcessUpdateExam proc = new ProcessUpdate.ProcessUpdateExam();
            proc.RIS_EXAM = this.RIS_EXAM;
            proc.Update();
        }
        public void Update(string Code)
        {
            ProcessUpdateExam proc = new ProcessUpdateExam();
            proc.RIS_EXAM = this.RIS_EXAM;
            proc.RIS_EXAM.EXAM_CODE = Code;
            proc.UpdateByCode();
        }
    }
}
