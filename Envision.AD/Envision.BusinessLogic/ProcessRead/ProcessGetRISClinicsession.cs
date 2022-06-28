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
	public class ProcessGetRISClinicsession : IBusinessLogic
	{
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }
		private DataSet result;

		public ProcessGetRISClinicsession()
		{
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISClinicsessionSelectData _proc=new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
			result=_proc.GetData();
		}
        public void InvokeCNMI()
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            result = _proc.GetDataCNMI();
        }
        public DataTable GetClinicSession() {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.GetScheduleSession().Tables[0].Copy();
        }
        public DataTable GetDefaultClinicSessionByModality(int modality_id)
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            return _proc.GetDefaultClinicSessionByModality(modality_id).Tables[0].Copy();
        }
	}
}

