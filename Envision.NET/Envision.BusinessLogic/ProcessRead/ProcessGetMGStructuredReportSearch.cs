using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetMGStructuredReportSearch : IBusinessLogic
    {
        public MG_BREASTEXAMRESULT MG_BREASTEXAMRESULT { get; set; }
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }
        public DataSet Result { get; set; }
        public DateTime FROM_DT { get; set; }
        public DateTime TO_DT { get; set; }
        public bool IS_SEARCH_BY_US { get; set; }
        public bool IS_SEATCH_ALL { get; set; }

        public ProcessGetMGStructuredReportSearch()
        {
            this.MG_BREASTEXAMRESULT = new MG_BREASTEXAMRESULT();
            this.MG_BREASTMASSDETAILS = new MG_BREASTMASSDETAILS();
            this.MG_BREASTUSMASSDETAILS = new MG_BREASTUSMASSDETAILS();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            MGStructuredReportSearchSelect processor = new MGStructuredReportSearchSelect();
            processor.MG_BREASTEXAMRESULT = this.MG_BREASTEXAMRESULT;
            processor.MG_BREASTMASSDETAILS = this.MG_BREASTMASSDETAILS;
            processor.MG_BREASTUSMASSDETAILS = this.MG_BREASTUSMASSDETAILS;
            this.Result = processor.GetData(this.FROM_DT, this.TO_DT, this.IS_SEARCH_BY_US, this.IS_SEATCH_ALL);
        }

        #endregion
    }
}
