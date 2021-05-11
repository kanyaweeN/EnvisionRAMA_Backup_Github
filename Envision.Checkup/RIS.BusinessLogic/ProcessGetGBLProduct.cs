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
    public class ProcessGetGBLProduct : IBusinessLogic
    {
        
        private DataSet _resultset;

        public ProcessGetGBLProduct()
        {

        }

        public void Invoke()
        {
            ProductSelectData proddata = new ProductSelectData();
            ResultSet = proddata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

       

    }
}
