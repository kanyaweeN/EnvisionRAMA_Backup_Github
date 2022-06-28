using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetGBLHospital : IBusinessLogic
	{
		private DataSet result;
		private GBLHospital _gblhospital;
		public ProcessGetGBLHospital()
		{
			_gblhospital = new  GBLHospital();
		}
		public GBLHospital GBLHospital
		{
			get{return _gblhospital;}
			set{_gblhospital=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLHospitalSelectData _proc=new GBLHospitalSelectData();
			_proc.GBLHospital=this.GBLHospital;
            result = _proc.GetDataAll();
		}
        public DataTable GetMappingHOS() {
            GBLHospitalSelectData _proc = new GBLHospitalSelectData();
            _proc.GBLHospital = this.GBLHospital;
            DataSet ds = _proc.GetMappingHosID();
            DataTable dtt = null;
            if (ds != null)
                if (ds.Tables.Count > 0)
                {
                    dtt = ds.Tables[0].Copy();
                    dtt.Columns.Add("IS");
                    foreach (DataRow dr in dtt.Rows)
                        dr["IS"] = "Y";
                }
            return dtt;
        }
	}
}

