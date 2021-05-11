using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLConflictExam : IBusinessLogic
    {

        public RIS_CONFLICTEXAMGROUP RIS_CONFLICTEXAMGROUP { get; set; }
        public DataSet Result { get; set; }
        public ProcessGetONLConflictExam()
        {
            RIS_CONFLICTEXAMGROUP = new RIS_CONFLICTEXAMGROUP();
            Result = new DataSet();
        }

        public void Invoke()
        {

            ONLConflictExamSelectData get = new ONLConflictExamSelectData();
            get.RIS_CONFLICTEXAMGROUP = this.RIS_CONFLICTEXAMGROUP;
            Result = get.Get();
        }
    }
}
