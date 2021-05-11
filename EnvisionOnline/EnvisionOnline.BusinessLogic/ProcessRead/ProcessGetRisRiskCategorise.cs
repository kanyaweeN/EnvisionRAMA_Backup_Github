using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRisRiskCategorise : IBusinessLogic
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE { get; set; }
        public DataSet Result { get; set; }
        #region IBusinessLogic Members

        public ProcessGetRisRiskCategorise()
        {
            this.RIS_RISKCATEGORISE = new RIS_RISKCATEGORISE();
        }
        public void Invoke()
        {
            RisRiskCategoriseSelect processor = new RisRiskCategoriseSelect();
            processor.RIS_RISKCATEGORISE = RIS_RISKCATEGORISE;
            this.Result = processor.GetData();
        }
        public DataTable getPRECAUTIONData()
        {
            RisRiskCategoriseSelect processor = new RisRiskCategoriseSelect();
            processor.RIS_RISKCATEGORISE = RIS_RISKCATEGORISE;
            return processor.getPRECAUTIONData();
        }
        public DataTable getCONTRAINDICATIONData()
        {
            RisRiskCategoriseSelect processor = new RisRiskCategoriseSelect();
            processor.RIS_RISKCATEGORISE = RIS_RISKCATEGORISE;
            return processor.getCONTRAINDICATIONData();
        }
        #endregion
    }
}
