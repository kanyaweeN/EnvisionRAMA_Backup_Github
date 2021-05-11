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
    public class ProcessGetGBLFavourite : IBusinessLogic
    {

        private DataSet _resultset;
        private string sp;

        public ProcessGetGBLFavourite(string a)
        {
            sp = a;
        }

        public void Invoke()
        {
            FavouriteSelectData envdata = new FavouriteSelectData(sp);
            ResultSet = envdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
