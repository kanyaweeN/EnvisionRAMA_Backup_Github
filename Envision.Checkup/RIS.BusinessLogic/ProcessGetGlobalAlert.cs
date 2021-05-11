using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.DataAccess.Select;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ProcessGetGlobalAlert : IBusinessLogic
    {
        private GBLAlert _gblalert;
        private DataSet _resultset;


        public ProcessGetGlobalAlert()
        {

        }

        public void Invoke()
        {
            GlobalAlertSelectData alertdata = new GlobalAlertSelectData();
            alertdata.GBLAlert = this.GBLAlert;
            ResultSet = alertdata.Get();

        }

     
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }        

    }
}
