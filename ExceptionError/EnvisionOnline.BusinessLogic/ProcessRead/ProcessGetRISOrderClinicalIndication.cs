using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISOrderClinicalIndication : IBusinessLogic
    {
        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }
        private DataSet _resultset;

        public ProcessGetRISOrderClinicalIndication()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
        }

        public void Invoke()
        {
            RISOrderClinicalIndicationSelectData data = new RISOrderClinicalIndicationSelectData();
            data.RIS_ORDERCLINICALINDICATION = this.RIS_ORDERCLINICALINDICATION;
            ResultSet = data.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

    }
}
