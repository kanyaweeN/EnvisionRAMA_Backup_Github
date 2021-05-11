//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/01/2552 03:44:19
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddGBLHospital : IBusinessLogic
	{
        public GBL_HOSPITAL GBL_HOSPITAL { get; set; }
        public RIS_HOSPITAL_MAP_DOCTOR RIS_HOSPITAL_MAP_DOCTOR { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddGBLHospital()
		{
            GBL_HOSPITAL = new GBL_HOSPITAL();
            Transaction = null;
		}
		public void Invoke()
		{
			GBLHospitalInsertData _proc=new GBLHospitalInsertData();
            _proc.GBL_HOSPITAL = this.GBL_HOSPITAL;
            _proc.Add();
		}
        public void Mapping() {
            GBLHospitalMapingDoctorInsertData _proc = new GBLHospitalMapingDoctorInsertData();
            _proc.RIS_HOSPITAL_MAP_DOCTOR = this.RIS_HOSPITAL_MAP_DOCTOR;
            _proc.Mapping();
        }
	}
}

