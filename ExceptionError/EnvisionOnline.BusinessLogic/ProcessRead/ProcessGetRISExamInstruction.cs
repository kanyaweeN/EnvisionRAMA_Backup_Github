using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamInstruction: IBusinessLogic
    {
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }
        public ProcessGetRISExamInstruction()
        {
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
        }

        public DataSet getNavigation(int exam_id)
        {
            RISExamInstraction get = new RISExamInstraction();
            get.RIS_EXAMINSTRUCTION = this.RIS_EXAMINSTRUCTION;
            return get.getNavigateInstruction(exam_id); 
        }
        public void Invoke()
        {
           
        }
    }
}
