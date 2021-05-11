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
    public class ProcessGetRadiologistAuthLevel : IBusinessLogic
    {
        public static int _empid=0;
        private DataSet _resultset;

        public ProcessGetRadiologistAuthLevel()
        {

        }
        public void Invoke()
        {
        }
        public void AuthLevel(int emp)
        {
            _empid = emp;
            AuthLevelSelectData envdata = new AuthLevelSelectData();
            ResultSet = envdata.Get(_empid);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
