using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGBreastUSMassDetail : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }

        public ProcessGetMGBreastUSMassDetail()
        {
            this.MG_BREASTUSMASSDETAILS = new MG_BREASTUSMASSDETAILS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGBreastUSMassDetailSelect processor = new MGBreastUSMassDetailSelect();
            processor.MG_BREASTUSMASSDETAILS = this.MG_BREASTUSMASSDETAILS;
            this.Result = processor.GetData();
        }

        #endregion
    }
}
