using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
    public class ProcessGetRISAcr
    {
        private DataSet result;

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RIS_ACR_SelectData _proc = new RIS_ACR_SelectData();
            result = _proc.GetData();
        }
    }
}
