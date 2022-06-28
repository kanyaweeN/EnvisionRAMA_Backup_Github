using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISContrastLot : IBusinessLogic
    {
        private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetRISContrastLot()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            RISContrastLotSelectData _select = new RISContrastLotSelectData();
            ResultSet = _select.SelectAll();
        }
        public DataSet getMappingByLotId(int lotId)
        {
            RISContrastLotSelectData _select = new RISContrastLotSelectData();
            return _select.getMappingByLotId(lotId);
        }
    }
}
