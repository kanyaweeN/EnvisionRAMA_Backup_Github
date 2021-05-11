//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/01/2552 03:44:19
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
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

