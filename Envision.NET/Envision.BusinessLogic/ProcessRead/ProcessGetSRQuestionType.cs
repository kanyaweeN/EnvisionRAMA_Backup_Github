using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetSRQuestionType : IBusinessLogic
    {
        public SR_QUESTIONTYPE SR_QUESTIONTYPE { get; set; }
        public DataSet Result { get; set; }

        public ProcessGetSRQuestionType()
        {
            this.SR_QUESTIONTYPE = new SR_QUESTIONTYPE();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            SrQuestionTypeSelect processor = new SrQuestionTypeSelect();
            processor.SR_QUESTIONTYPE = this.SR_QUESTIONTYPE;
            this.Result = processor.SelectData();
        }

        #endregion

        public DataTable GetData()
        {
            SRQuestionTypeSelectData proc = new SRQuestionTypeSelectData();
            proc.SR_QUESTIONTYPE = SR_QUESTIONTYPE;
            return proc.GetData();
        }

    }
}
