using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPRGrade: IBusinessLogic
    {
        private DataSet _resultset;

        public ProcessGetRISPRGrade()
        {
        }

        public void Invoke()
        {
            RISPRGradeSelectData prc = new RISPRGradeSelectData();
            ResultSet = prc.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}