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
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessGetPatientReg : IBusinessLogic
    {
        private string _patreg;
        public DataSet _resultset;

        public ProcessGetPatientReg(string patreg)
        {
            _patreg = patreg;
        }

        public void Invoke()
        {
            PatientRegSelectData envdata = new PatientRegSelectData();
            ResultSet = envdata.Get(_patreg);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
