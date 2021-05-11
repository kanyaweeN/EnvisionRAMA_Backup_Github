using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinicalIndication : IBusinessLogic
    {
        private DataSet _dataresult;
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessGetRISClinicalIndication()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {

            RISClinicalIndicationSelectData data = new RISClinicalIndicationSelectData();
            data.RIS_CLINICALINDICATION = RIS_CLINICALINDICATION;
            Result = data.GetData();
        }
        public int get_CI_ID(string ci_desc, string parent_desc,string mode)
        {
            int ciid = 0;
            RISClinicalIndicationSelectData data = new RISClinicalIndicationSelectData();
            DataSet ds  = data.GetCI_ID(ci_desc, parent_desc,mode);
            if(ds.Tables.Count>0)
                if(ds.Tables[0].Rows.Count>0)
                    ciid = Convert.ToInt32(ds.Tables[0].Rows[0]["CI_ID"]);
            return ciid;
        }
        public int get_CI_ID(string[] arry_ci_desc)
        {
            int ciid = 0;
            RISClinicalIndicationSelectData data = new RISClinicalIndicationSelectData();
            int i = arry_ci_desc.Length - 1;
            DataTable dtTemp = new DataTable();
            while (i >= 1)
            {
                DataTable dt = data.GetCI_ID(arry_ci_desc[i], arry_ci_desc[i - 1], "Multi").Tables[0];
                if (dt.Rows.Count == 1)
                {
                    if (dtTemp.Rows.Count == 0)
                        ciid = Convert.ToInt32(dt.Rows[0]["CI_ID"]);
                    else
                    {
                        DataRow[] rows = dtTemp.Select("CI_PARENT=" + dt.Rows[0]["CI_ID"].ToString());
                        ciid = Convert.ToInt32(rows[0]["CI_ID"]);
                    }
                    break;
                }
                else
                {
                    dtTemp = dt.Copy();
                }
                i--;
            }

            return ciid;
        }
        public DataSet Result
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}

