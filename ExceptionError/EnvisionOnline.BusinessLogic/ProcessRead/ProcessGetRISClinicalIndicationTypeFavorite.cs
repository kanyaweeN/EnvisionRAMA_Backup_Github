using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.DataAccess.Select;
using System.Data;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinicalIndicationTypeFavorite : IBusinessLogic
    {
        private DataSet _dataresult;
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public ProcessGetRISClinicalIndicationTypeFavorite()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {

            RISClinicalIndicationTypeFavoriteSelectData data = new RISClinicalIndicationTypeFavoriteSelectData();
            data.RIS_CLINICALINDICATIONTYPE = RIS_CLINICALINDICATIONTYPE;
            Result = data.GetData();
        }

        public DataSet Result
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}
