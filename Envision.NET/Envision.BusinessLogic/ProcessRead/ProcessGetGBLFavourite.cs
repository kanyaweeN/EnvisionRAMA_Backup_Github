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
