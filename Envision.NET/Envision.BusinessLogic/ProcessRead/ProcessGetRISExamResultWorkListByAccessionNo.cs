using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamResultWorkListByAccessionNo : IBusinessLogic
    {
        public string ACCESSION_NO { get; set; }
        public int EMP_ID { get; set; }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISExamResultSelectWorkListByAccessionNo processor = new RISExamResultSelectWorkListByAccessionNo();
            this.Result = processor.GetData(this.ACCESSION_NO, this.EMP_ID);
        }

        #endregion
    }
}
