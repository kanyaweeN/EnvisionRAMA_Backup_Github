/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeletePatient : IBusinessLogic
    {
        private RISPatstatus _patient;

        public ProcessDeletePatient()
        {

        }

        public void Invoke()
        {
            PatientDeleteData patientdata = new PatientDeleteData();
            patientdata.RISPatstatus = this.RISPatstatus;
            patientdata.Delete();

        }

        public RISPatstatus RISPatstatus
        {
            get { return _patient; }
            set { _patient = value; }
        }
    }
}
