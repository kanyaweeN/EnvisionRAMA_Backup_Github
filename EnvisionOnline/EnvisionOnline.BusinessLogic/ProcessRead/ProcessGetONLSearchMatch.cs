using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetONLSearchMatch: IBusinessLogic
    {
        public DataSet Result { get; set; }
        public ProcessGetONLSearchMatch()
        {
            Result = new DataSet();
        }

        public void Invoke()
        {
            ONLSearchMatchSelectData get = new ONLSearchMatchSelectData();
            Result = get.GetData();
        }
    }
}