using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderClinicalIndicationType: IBusinessLogic
    {
        public RIS_ORDERCLINICALINDICATIONTYPE RIS_ORDERCLINICALINDICATIONTYPE { get; set; }
        private DataSet _resultset;

        public ProcessGetRISOrderClinicalIndicationType()
        {
            RIS_ORDERCLINICALINDICATIONTYPE = new RIS_ORDERCLINICALINDICATIONTYPE();
        }

        public void Invoke()
        {
            RISOrderClinicalIndicationTypeSelectData data = new RISOrderClinicalIndicationTypeSelectData();
            data.RIS_ORDERCLINICALINDICATIONTYPE = this.RIS_ORDERCLINICALINDICATIONTYPE;
            ResultSet = data.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

    }
}
