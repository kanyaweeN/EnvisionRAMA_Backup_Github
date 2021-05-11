using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteONLGroupExam
    {
        public ProcessDeleteONLGroupExam()
        {
        }

        public void delete(int gtype_id)
        {
            ONLGroupExamDeleteData _proc = new ONLGroupExamDeleteData();
            _proc.Delete(gtype_id);
        }
        public void deleteByGExamID(int gexam_id)
        {
            ONLGroupExamDeleteData _proc = new ONLGroupExamDeleteData();
            _proc.DeleteByID(gexam_id);
        }
    }
}