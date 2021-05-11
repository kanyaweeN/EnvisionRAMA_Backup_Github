using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISModalityexam : IBusinessLogic
    {
        private DataSet result;
        private int action;
        private int modalityID;

        public ProcessGetRISModalityexam()
        {
            action = 0;
        }
        public ProcessGetRISModalityexam(bool selectAll)
        {
            action = selectAll ? 1 : 0;
        }
        public ProcessGetRISModalityexam(int modalityID)
        {
            action = 2;
            this.modalityID = modalityID;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISModalityexamSelectData _proc = null;
            if (action == 0)
                _proc = new RISModalityexamSelectData();
            else if (action == 1)
                _proc = new RISModalityexamSelectData(true);
            else
                _proc = new RISModalityexamSelectData(modalityID);
            result = _proc.GetData();
        }
        public DataSet getModalityExamTop10(int unit_id, int lengthByDay)
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData(modalityID);
            return _proc.getModalityExamTop10(unit_id, lengthByDay);
        }
        public DataSet getModalityExamFavorite(int emp_id)
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData(modalityID);
            return _proc.getModalityExamFavorite(emp_id);
        }
        public DataSet getModalityExamByModalityType(int modality_typ)
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData(modalityID);
            return _proc.getModalityExamByModalityType(modality_typ);
        }
        public DataSet rptModalityexam(int UserID)
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData(modalityID);
            return _proc.GetReport_ModalityExam(UserID);
        }
        public DataSet rptModalityexam_Para()
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData();
            return _proc.GetReport_ModalityExam_Para();
        }
        public DataSet getModalityIDByPatDestID(int exam_id, int pat_dest_id)
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData();
            return _proc.getModalityIDByPatDestID(exam_id,pat_dest_id);
        }
        public DataSet getModalityFilter(int exam_id, int pat_dest_id)
        {
            RISModalityexamSelectData _proc = new RISModalityexamSelectData();
            return _proc.getModalityIDByPatDestID(exam_id, pat_dest_id);
        }
    }
}

