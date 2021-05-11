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
    public class ProcessGetScheduleCatagory : IBusinessLogic
    {
        private EmpScheduleCatagory _sccatagory;
        private DataSet _resultset;

        public ProcessGetScheduleCatagory()
        {

        }

        public void Invoke()
        {
            ScheduleCatagorySelectData sccat = new ScheduleCatagorySelectData();
            sccat.EmpScheduleCatagory = this.EmpScheduleCatagory;
            ResultSet = sccat.Get();

        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public EmpScheduleCatagory EmpScheduleCatagory
        {
            get { return _sccatagory; }
            set { _sccatagory = value; }
        }



    }
}
