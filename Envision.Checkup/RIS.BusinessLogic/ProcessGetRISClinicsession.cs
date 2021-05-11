//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    09/06/2552 02:38:17
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
	public class ProcessGetRISClinicsession : IBusinessLogic
	{
		private DataSet result;
		private RISClinicsession _risclinicsession;
		public ProcessGetRISClinicsession()
		{
			_risclinicsession = new  RISClinicsession();
		}
		public RISClinicsession RISClinicsession
		{
			get{return _risclinicsession;}
			set{_risclinicsession=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISClinicsessionSelectData _proc=new RISClinicsessionSelectData();
			_proc.RISClinicsession=this.RISClinicsession;
			result=_proc.GetData();
		}
        public DataTable GetClinicSession() {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RISClinicsession = this.RISClinicsession;
            return _proc.GetScheduleSession().Tables[0].Copy();
        }
	}
}

