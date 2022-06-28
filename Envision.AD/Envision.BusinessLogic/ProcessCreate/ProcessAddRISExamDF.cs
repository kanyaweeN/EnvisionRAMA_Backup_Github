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
    public class ProcessAddRISExamDF
	{
        public RIS_EXAMDF RIS_EXAMDF { get; set; }

        public ProcessAddRISExamDF()
        {
            RIS_EXAMDF = new RIS_EXAMDF();            
        }

        public void AddData()
        {
            RISExamDFInsertData addData = new RISExamDFInsertData();
            addData.RIS_EXAMDF = this.RIS_EXAMDF;
            addData.AddData();
        }
	}
}

