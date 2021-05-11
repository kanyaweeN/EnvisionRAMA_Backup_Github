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
    public class ProcessGetCountHRUnit : IBusinessLogic
    {
        public HR_UNIT HR_UNIT { get; set; }
        private DataSet result;
        public ProcessGetCountHRUnit()
        {
            HR_UNIT = new HR_UNIT();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            HRUnitCountData _proc = new HRUnitCountData();
            _proc.HR_UNIT = this.HR_UNIT;
            result = _proc.Count();
        }
        }

    }

