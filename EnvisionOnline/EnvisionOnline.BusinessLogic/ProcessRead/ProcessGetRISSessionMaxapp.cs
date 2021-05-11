using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline.Common;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISSessionMaxapp : IBusinessLogic
    {

        private DataSet _resultset;
        public RIS_SESSIONMAXAPP RIS_SESSIONMAXAPP { get; set; }
        public ProcessGetRISSessionMaxapp()
        {
            RIS_SESSIONMAXAPP = new RIS_SESSIONMAXAPP();
        }

        public void Invoke()
        {

            RISSessionMaxappSelectData prodData = new RISSessionMaxappSelectData();
            prodData.RIS_SESSIONMAXAPP = this.RIS_SESSIONMAXAPP;
            ResultSet = prodData.GetData();

        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
