using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetHoliday : IBusinessLogic
    {
        public ProcessGetHoliday()
        {
        }
        public void Invoke()
        {
        }

        public DataSet get()
        {
            HolidaySelectData _proc = new HolidaySelectData();
            return _proc.GetData();
        }
    }
}
