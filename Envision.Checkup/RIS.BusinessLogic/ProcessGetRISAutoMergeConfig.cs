using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISAutoMergeConfig : IBusinessLogic
    {
        private DataSet result;
        public DataSet Result
        {
            get { return result; }
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISAutoMergeConfigSelect proc = new RISAutoMergeConfigSelect();
            proc.Select();
            result = proc.Result;
        }

        #endregion
    }
}
