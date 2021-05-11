using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPatientdestination : IBusinessLogic
    {
        public RIS_PATIENTDESTINATION RIS_PATIENTDESTINATION { get; set; }
        private DataSet _resultset;

        public ProcessGetRISPatientdestination()
        {
            RIS_PATIENTDESTINATION = new RIS_PATIENTDESTINATION();
        }

        public void Invoke()
        {
            RISPatientinationSelectData envdata = new RISPatientinationSelectData();
            ResultSet = envdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        public DataTable getDataMapping(int unit_id, int clinic_type_id)
        {
            RISPatientinationSelectData envdata = new RISPatientinationSelectData();
            return envdata.getDataMapping(unit_id, clinic_type_id).Tables[0];
        }
        public DataTable getFlagCTMR(int pat_dest_id)
        {
            RISPatientinationSelectData envdata = new RISPatientinationSelectData();
            return envdata.getFlagCTMR(pat_dest_id).Tables[0];
        }

    }
}

