using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddONLGroupExam 
    {
        public ProcessAddONLGroupExam()
        {
        }

        public void Add(int gExamTypeID, int exam_id)
        {
            ONLGroupExamInsertData insert = new ONLGroupExamInsertData();
            insert.Add(gExamTypeID, exam_id);
        }
    }
}