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
    public class ProcessGetACEnrollment : IBusinessLogic
    {
        private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetACEnrollment()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            ACEnrollmentSelectData _select = new ACEnrollmentSelectData();
            ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            ACEnrollmentSelectData _select = new ACEnrollmentSelectData();
            ResultSet = _select.SelectByID(_ByID);
        }
        public void SelectEnrollmentResident()
        {
            ACEnrollmentSelectData _select = new ACEnrollmentSelectData();
            ResultSet = _select.SelectEnrollmentResident();
        }
        public void SelectEnrollmentRadiologist()
        {
            ACEnrollmentSelectData _select = new ACEnrollmentSelectData();
            ResultSet = _select.SelectEnrollmentRadiologist();
        }
        public void SelectEnrollmentForAssignment(int _EmpID)
        {
            ACEnrollmentSelectData _select = new ACEnrollmentSelectData();
            ResultSet = _select.SelectEnrollmentForAssignment(_EmpID);
        }
        public void SelectEnrollmentByYear(int _YearID)
        {
            ACEnrollmentSelectData _select = new ACEnrollmentSelectData();
            ResultSet = _select.SelectEnrollmentByYear(_YearID);
        }
    }
}
