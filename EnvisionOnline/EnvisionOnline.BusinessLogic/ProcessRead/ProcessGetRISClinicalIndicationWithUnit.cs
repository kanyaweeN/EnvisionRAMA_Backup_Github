using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
   public class ProcessGetRISClinicalIndicationWithUnit: IBusinessLogic
    {
        private DataSet _dataresult;
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessGetRISClinicalIndicationWithUnit()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {

            RISClinicalIndicationWithUnitSelectData data = new RISClinicalIndicationWithUnitSelectData();
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

