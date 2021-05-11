using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinicalIndicationFavorite : IBusinessLogic
    {
        private DataSet _dataresult;
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessGetRISClinicalIndicationFavorite()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {

            RISClinicalIndicationFavoriteSelectData data = new RISClinicalIndicationFavoriteSelectData();
            data.RIS_CLINICALINDICATION = RIS_CLINICALINDICATION;
            Result = data.GetData();
        }

        public DataSet Result
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}
