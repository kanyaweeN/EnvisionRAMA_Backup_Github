using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinicalIndicationType : IBusinessLogic
    {
        private DataSet _dataresult;
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public ProcessGetRISClinicalIndicationType()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {

            RISClinicalIndicationTypeSelectData data = new RISClinicalIndicationTypeSelectData();
            data.RIS_CLINICALINDICATIONTYPE = RIS_CLINICALINDICATIONTYPE;
            Result = data.GetData();
        }
        public DataSet GetDataCovid()
        {
            RISClinicalIndicationTypeSelectData data = new RISClinicalIndicationTypeSelectData();
            data.RIS_CLINICALINDICATIONTYPE = RIS_CLINICALINDICATIONTYPE;
            return data.GetDataCovid();
        }
        public DataSet GetDataWithParameter(string param)
        {
            RISClinicalIndicationTypeSelectData data = new RISClinicalIndicationTypeSelectData();
            return data.GetDataWithParameter(param);
        }
        public int get_CI_TYPE_ID(string ci_desc, string parent_desc,string mode)
        {
            int ciid = 0;

            RISClinicalIndicationTypeSelectData data = new RISClinicalIndicationTypeSelectData();
            DataSet ds = data.GetCI_TYPE_ID(ci_desc, parent_desc,mode);
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                    ciid = Convert.ToInt32(ds.Tables[0].Rows[0]["CI_TYPE_ID"]);
            return ciid;
        }
        public DataSet Result
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}
