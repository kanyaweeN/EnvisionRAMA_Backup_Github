using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessUpdateRISExamDF
	{
        public RIS_EXAMDF RIS_EXAMDF { get; set; }

        public ProcessUpdateRISExamDF()
        {
            RIS_EXAMDF = new RIS_EXAMDF();            
        }

        public void UpdateData()
        {
            RISExamDFUpdateData addData = new RISExamDFUpdateData();
            addData.RIS_EXAMDF = this.RIS_EXAMDF;
            addData.UpdateData();
        }
        public void UpdateDataIsDeleted()
        {
            RISExamDFUpdateData addData = new RISExamDFUpdateData();
            addData.RIS_EXAMDF = this.RIS_EXAMDF;
            addData.UpdateDataIsDeleted();
        }
	}
}

