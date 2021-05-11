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
    public class ProcessModalityLoad : IBusinessLogic
    {
        private DataSet _resultset;

        public void Invoke()
        {
            
        }

        public void Invoke(int _sptype, DateTime _scdate)
        {
            ModalityLoadSelectData _load = new ModalityLoadSelectData();
            _resultset = _load.Get(_sptype, _scdate);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }




    }
}
