using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISModalityexam : IBusinessLogic
	{
		private DataSet result;
        private int action;
        private int modalityID;

		public ProcessGetRISModalityexam(){
            action = 0;
        }
        public ProcessGetRISModalityexam(bool selectAll) {
            action = selectAll ? 1 : 0;
        }
        public ProcessGetRISModalityexam(int modalityID) {
            action = 2;
            this.modalityID = modalityID; 
        }


		public DataSet Result
		{
			get{return result;}
			set{result=value;}
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
			result=_proc.GetData();
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
	}
}

